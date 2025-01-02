using Godot;
using System;

namespace Commons.Colectables
{
    public interface IColectable
    {
        void OnColect();
        AudioStreamPlayer SoundFX { get; set; }
    }
}
