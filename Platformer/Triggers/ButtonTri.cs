using Commons;
using Godot;
using System;

namespace Platformer.Triggers 
{ 
    public partial class ButtonTri : Node2D, ITriggers
    {
        [Export]
        public bool Repeatable { get; private set; }

        public bool HasBeenUsed { get; private set; } = false;

        [Export]
        private Sprite2D _sprite;

        [Export]
        private Texture2D _pressedButtonSprite, _unpressedButtonSprite;

        public Action OnButtonPressed;

        public void Action()
        {
            OnButtonPressed?.Invoke();
        }

        public void OnBaseTrigger2dAreaEntered(Area2D area)
        {
            if(!HasBeenUsed || Repeatable)
            {
                HasBeenUsed = true;
                Action();
                _sprite.Texture = _pressedButtonSprite;
            }
        }
        public void OnBaseTrigger2dAreaExited(Area2D area)
        {

            if (Repeatable)
            {
                _sprite.Texture = _unpressedButtonSprite;
            }
        }
    }
}
