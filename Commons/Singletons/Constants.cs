using Godot;
using System;

namespace Commons.Singletons
{
    public partial class Constants : Node
    {
        public static Constants Instance { get; private set; }

        #region particlesScenesStrings
        public const string ExplosionParticles = "res://Platformer/Particles/Explosion.tscn";
        #endregion
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }
    }
}
