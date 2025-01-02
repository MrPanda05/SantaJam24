using Commons.Colectables;
using Godot;
using System;

namespace Platformer.Colectables
{
    public partial class Casset : Node2D, IColectable
    {
        public AudioStreamPlayer SoundFX { get; set; }

        public void OnColect()
        {
            GD.Print("Casset player");
            QueueFree();
        }
    }
}
