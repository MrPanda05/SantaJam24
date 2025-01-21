using Commons.Singletons;
using FPS.Dialogue;
using Godot;
using System;

namespace FPS
{
    public partial class Cassettap : Node3D
    {
        private bool _isMouseOn = false;

        public static Action<int> OnTapePicked;

        [Export]
        public int index = 0;

        [Export]
        private DialogueUi _dialogueUi;
        [Export]
        private Fadeblack _fadeToBlackUI;

        private bool _picked;

        public void OnArea3dMouseEntered()
        {
            _isMouseOn = true;
        }
        public void OnArea3dMouseExited()
        {
            _isMouseOn = false;
        }
        public override void _PhysicsProcess(double delta)
        {
            if (_picked) return;
            if (_isMouseOn && Input.IsActionJustPressed("LClick"))
            {
                _picked = true;
                GD.Print("I chose this tape index" + index);
                OnTapePicked?.Invoke(index);
                GameManager.Instance.SetTapeNum(index);
                PickThis();
            }
        }
        public async void PickThis()
        {
            await _dialogueUi.ShowDialogue("Very well... thanks for your cooperation");
            _fadeToBlackUI.FadeToBlack();

        }




        //public void OnArea3dInputEvent(Node Camera, InputEvent @event, Vector3 pos, Vector3 normal, int shape)
        //{
        //    GD.Print("PENIS");
        //}
    }
}
