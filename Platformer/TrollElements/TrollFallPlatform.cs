using Godot;
using Platformer.LePlayer2D;
using System;

namespace Platformer.TrollsElements
{
    public partial class TrollFallPlatform : Node2D, ITroll
    {
        private bool _PlayerOnPlatform;

        public static Action OnPlayerEnter;

        private AnimatableBody2D _Body2D;

        [Export]
        private Timer timer;


        private float _delta;
        [Export]
        private float _SpeedY = 200;
        [Export]
        private float _SpeedX = 0;
        //Entered
        public void OnTriggerAreaEntered(Area2D area)
        {
            if (area.CollisionLayer == 512)
            {
                _PlayerOnPlatform = true;
            }
            if (area.CollisionLayer == 8192)
            {

                _SpeedX *= -1;
                _SpeedY *= -1;
            }
        }
        
        //Exits
        public void OnTriggerAreaExited(Area2D area)
        {
            if (area.CollisionLayer == 512)
            {
                _PlayerOnPlatform = false;
                timer.Start();
            }
        }
       public void OnTimerTimeout()
        {
            if (_PlayerOnPlatform) return;
            _PlayerOnPlatform = false;//Chante this
            _Body2D.GlobalPosition = GlobalPosition;
        }

        public override void _Ready()
        {
            _Body2D = GetNode<AnimatableBody2D>("NormalAnimetedPlatform");
        }
        public override void _PhysicsProcess(double delta)
        {
            if (!_PlayerOnPlatform && timer.TimeLeft <= 0) return;
            _delta = (float)delta;
            TrollMoment();


        }
        public void TrollMoment()
        {
            _Body2D.Position += new Vector2(_SpeedX, _SpeedY) * _delta;

        }
    }
}
