using Godot;
using Platformer.LePlayer2D;
using System;

namespace Commons._2D
{
    public partial class VelocityComponent2d : Node, IVelocityComponent
    {
        [ExportGroup("Propreties")]
        [Export] public float Speed { get; private set; }
        [Export] public float MaxSpeed { get; private set; }
        [Export] public float Acel { get; private set; }
        [Export(PropertyHint.Range, "0,1,")] public float Friction { get; private set; }
        [Export] public float ForceJump { get; private set; }
        [Export] public float MaxForceJump { get; private set; }
        [Export] public float GravityForce { get; private set; }
        [Export] public float TerminalVelocity { get; private set; }
        [Export] public bool ApplyGravity { get; private set; } = true;

    }
}

