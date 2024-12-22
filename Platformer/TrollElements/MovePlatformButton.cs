using Godot;
using Platformer.Triggers;
using System;

namespace Platformer
{

    public partial class MovePlatformButton : Node2D
    {
        [Export]
        private ButtonTri _myButton;

        [Export]
        private Vector2 _force;

        [Export]
        private AnimatableBody2D _body;

        [Export]
        private Timer _timer;


        private bool Working;

        private void DoSomething()
        {
            if (_timer.TimeLeft > 0) return;
            Working = true;
            _timer.Start();
            Visible = true;
        }
        public void OnTimerTimeout()
        {
            _body.Position = Vector2.Zero;
            Working = false;
            if (!_myButton.Repeatable)
            {
                _myButton.OnButtonPressed -= DoSomething;
            }
            Visible = false;
        }
        public void MovePlatform(float delta)
        {
            _body.Position += new Vector2(_force.X * delta, _force.Y * delta);
        }

        public override void _Ready()
        {
            _myButton.OnButtonPressed += DoSomething;
            Visible = false;
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Working)
            {
                MovePlatform((float)delta);
            }
        }
    }
}
