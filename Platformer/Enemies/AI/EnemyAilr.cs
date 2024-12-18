using Commons.Singletons;
using Godot;
using System;

namespace Platformer.Enemies.AI
{
    public partial class EnemyAilr : Node2D, IEnemyAI
    {
        [Export]
        private float _speed;

        public bool Activated { get; set; } = true;

        public void OnArea2dAreaEntered(Area2D area)
        {
            ChangeDir();
        }
        
        public void ChangeDir()
        {
            _speed *= -1;
        }
        public void Logic(CharacterBody2D body)
        {
            if (!Activated) return;
            Vector2 _vel = body.Velocity;
            if (!body.IsOnFloor())
            {
                _vel.Y += 200;
            }
            _vel.X = _speed;
            body.Velocity = _vel;
            body.MoveAndSlide();
        }
    }
}
