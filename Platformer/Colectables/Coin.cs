using Commons.Colectables;
using Commons.Singletons;
using Godot;
using System;

namespace Platformer.Colectables
{
    public partial class Coin : Node2D, IColectable
    {
        [Export]
        public AudioStreamPlayer SoundFX { get; set; }
        public static Action OnCoinColected;
        public void OnColect()
        {
            GD.Print("I got coin");
            OnCoinColected?.Invoke();
            SoundFX.Play();
            Visible = false;
        }
        public void OnAudioStreamPlayerFinished()
        {
            QueueFree();
        }
    }
}
