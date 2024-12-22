using Commons;
using Godot;
using Platformer.LePlayer2D;
using System;

namespace Platformer.TrollsElements
{
    public partial class JumpPad : Node2D, ITriggers
    {
        [Export]
        public bool Repeatable { get; private set; }

        public bool HasBeenUsed { get; private set; } = false;

        [Export]
        private AnimatedSprite2D _sprite2D;

        [Export]
        private Vector2 force;

        public void OnAnimatedSprite2dAnimationFinished()
        {
            if(_sprite2D.Animation == "Pressed")
            {
                _sprite2D.Animation = "Static";
                _sprite2D.Play();
            }
        }
        public void OnBaseTrigger2dAreaEntered(Area2D area)
        {
            GD.Print("HEY");
            if(area.GetParent() is CharacterBody2D body)
            {
                _sprite2D.Animation = "Pressed";
                _sprite2D.Play();
                if(body is Player2d)
                {
                    if (Input.IsActionPressed("Jump"))
                    {
                        GD.Print("Player jumping add force");
                        body.Velocity = new Vector2(force.X * 1.3f, force.Y * 1.3f);
                    }
                    else
                    {
                        GD.Print("Player not jumping");
                        body.Velocity = force;
                    }
                }
                else
                {
                    body.Velocity = force;
                }
                body.MoveAndSlide();
            }
        }
        public void Action()
        {
            throw new NotImplementedException();
        }
    }
}
