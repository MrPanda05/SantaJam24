using Godot;
using Godot.Collections;
using System;

namespace Commons.Singletons
{
    public partial class SoundManager : Node
    {
        public static SoundManager Instance { get; private set; }
        [Export]
        private Array<AudioStreamPlayer> AudioStreamPlayers;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void PlayExplosion()
        {
            AudioStreamPlayers[0].Play();
        }
        
    }
}
