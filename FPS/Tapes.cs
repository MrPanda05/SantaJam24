using Commons.Singletons;
using FPS.Dialogue;
using Godot;
using Platformer.Levels;
using System;
using System.Collections.Generic;

namespace FPS
{
    //show tapes
    public partial class Tapes : Node3D
    {
        [Export]
        private Cassettap _tape1, _tape2, _tape3;


        private List<Cassettap> _tapes = new List<Cassettap>();


        [Export]
        private Fadeblack _fadeToBlackUI;

        [Export]
        private DialogueUi _dialogueUi;

        private int _tapesColected = 0;
        public override void _Ready()
        {
            _tapes = [_tape1, _tape2, _tape3];
            EndScreen.OnGameFinished += SetTapesVisble;
            Cassettap.OnTapePicked += DisableOtherTapes;
            DisableTapes();
        }

        public override void _ExitTree()
        {
            EndScreen.OnGameFinished -= SetTapesVisble;
            Cassettap.OnTapePicked -= DisableOtherTapes;
        }
        public async void OnAnimationPlayerAnimationFinished(string anim)
        {
            if (anim == "GameEnded")
            {
                if (_tapesColected <= 0)
                {
                    await _dialogueUi.ShowDialogue("Very well... thanks for your cooperation");
                    _fadeToBlackUI.FadeToBlack();
                    return;
                }
                await _dialogueUi.ShowDialogue("Choose one...");
                EnableTapes();
            }
        }

        public void DisableOtherTapes(int index)
        {
            for (int i = 0; i < _tapes.Count; i++)
            {
                if (i != index)
                {
                    GameManager.SetNodeProcessMode(_tapes[i], ProcessModeEnum.Disabled);
                }
            }
        }

        public void EnableTapes()
        {
            for (int i = 0; i < _tapes.Count; i++)
            {
                GameManager.SetNodeProcessMode(_tapes[i], ProcessModeEnum.Inherit);
            }
        }
        public void DisableTapes()
        {
            for (int i = 0; i < _tapes.Count; i++)
            {
                GameManager.SetNodeProcessMode(_tapes[i], ProcessModeEnum.Disabled);
            }
        }
        private void SetTapesVisble()
        {
            for (int i = 0; i < _tapes.Count; i++)
            {
                _tapes[i].Visible = GameManager.Instance.tapesColected[i];
                if (GameManager.Instance.tapesColected[i])
                {
                    _tapesColected++;
                }
            }
            GD.Print(_tapesColected);
            
        }
    }
}
