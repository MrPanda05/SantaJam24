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
        private float _Speed = 200;
        //Entered
        public void OnTriggerAreaEntered(Area2D area)
        {
            _PlayerOnPlatform = true;
        }
        
        //Exits
        public void OnTriggerAreaExited(Area2D area)
        {
            timer.Start();
        }
       public void OnTimerTimeout()
        {
            _PlayerOnPlatform = false;
            _Body2D.GlobalPosition = GlobalPosition;
        }

        public override void _Ready()
        {
            _Body2D = GetNode<AnimatableBody2D>("NormalAnimetedPlatform");
        }
        public override void _PhysicsProcess(double delta)
        {
            if (!_PlayerOnPlatform) return;
            _delta = (float)delta;
            TrollMoment();


        }
        public void TrollMoment()
        {
            _Body2D.Position += new Vector2(0, _Speed) * _delta;
        }
    }
}
