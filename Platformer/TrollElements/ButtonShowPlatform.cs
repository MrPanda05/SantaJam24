using Godot;
using Platformer.Triggers;
using System;

namespace Platformer.TrollsElements
{
    public partial class ButtonShowPlatform : Node2D
    {
        [Export]
        private ButtonTri _myButton;

        [Export]
        private Node2D _myPlatform;

        [Export]
        private ProcessModeEnum _mode;

        private void Something()
        {
            _myPlatform.ProcessMode = _mode;
        }
        private void DoSomething()
        {
            CallDeferred("Something");
        }
        public override void _Ready()
        {
            _myButton.OnButtonPressed += DoSomething;
        }
    }
}
