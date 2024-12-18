using Godot;
using System;

namespace Platformer.Killables
{
    public partial class LandMine : Node2D, IKillable
    {
        public void OnKillBoxAreaEntered(Area2D area)
        {
            GD.Print("BOOM");
        }
    }
}
