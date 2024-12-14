using Commons.Colectables;
using Godot;
using System;

namespace Platformer.Colectables
{
    public partial class Coin : Node2D, IColectable
    {
        public static Action OnCoinColected;
        public void OnColect()
        {
            GD.Print("I got coin");
            OnCoinColected?.Invoke();
            QueueFree();
        }
    }
}
