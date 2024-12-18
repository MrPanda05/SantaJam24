using Commons;
using Godot;
using System;

namespace Platformer.Triggers
{
    public partial class SpawnCoinTrigger : Node2D, ITriggers
    {
        [Export]
        public bool Repeatable { get; private set; }

        public bool HasBeenUsed { get; private set; } = false;

        public void Action()
        {
            GD.Print("Coin spawned");
            HasBeenUsed = true;
        }

        public void OnBaseTrigger2dAreaEntered(Area2D area)
        {
            if (!Repeatable && HasBeenUsed) return;
            Action();
        }
    }
}
