using Godot;
using System;

namespace Platformer.LePlayer2D
{
    public partial class PlayerSprites : AnimatedSprite2D
    {
        private Player2d _player;

        public override void _Ready()
        {
            _player = GetParent<Player2d>();
        }
        private bool IsNearZero(float value)
        {
            if (value == 0) return true;
            if (value > 0.005f && value < 0.05f)
            {
                return true;
            }
            if (value < -0.005f && value > -0.05f)
            {
                return true;
            }
            return false;
        }
        public override void _PhysicsProcess(double delta)
        {
            if(_player.Velocity.X > 0)
            {
                FlipH = false;
            }
            if( _player.Velocity.X < 0)
            {
                FlipH = true;
            }
            if(_player.Velocity.Y != 0)
            {
                if (Animation != "Jumping") Stop();
                Play("Jumping");
                return;
            }
            if(IsNearZero(_player.Velocity.X) && !_player.Moving)
            {
                if (Animation != "Iddle") Stop();
                Play("Iddle");
                return;
            }
            if((_player.Velocity.X > 0.05f || _player.Velocity.X < -0.05f))
            {
                if (Animation != "Runing") Stop();
                Play("Runing");
                return;
            }
        }
        public override void _Process(double delta)
        {
            if (Input.IsActionPressed("Print"))
            {
                GD.Print(Animation);
            }
        }
    }
}
