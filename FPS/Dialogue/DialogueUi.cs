using Godot;
using System;
using System.Threading.Tasks;

namespace FPS.Dialogue
{
	public partial class DialogueUi : Control
	{
        [Export]
        private Label _textLabel;

        public Action OnDialoguedEnded;

        private bool _isBeingUsed;

        public override void _Ready()
        {
            Clearlabel();
        }
        public async Task ShowDialogue(string text, float timerSpeed = 0.1f)
        {
            if(_isBeingUsed)
            {
                GD.PushWarning("Dialogue is being used");
                return;
            }
            _isBeingUsed = true;
            foreach (char c in text)
            {
                _textLabel.Text += c;
                await ToSignal(GetTree().CreateTimer(timerSpeed), Timer.SignalName.Timeout);
            }
            await ToSignal(GetTree().CreateTimer(0.5f), Timer.SignalName.Timeout);
            Clearlabel();
            _isBeingUsed = false;
            OnDialoguedEnded?.Invoke();
        }

        public void Clearlabel()
        {
            _textLabel.Text = "";
        }
        public async void ClearLabelAfterTime(float time = 0.5f)
        {
            await ToSignal(GetTree().CreateTimer(time), Timer.SignalName.Timeout);
            _textLabel.Text = "";
        }


    }
}
