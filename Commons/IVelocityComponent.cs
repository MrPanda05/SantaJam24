using Godot;
using System;

namespace Commons
{
    public interface IVelocityComponent
    {
        float Speed { get; }
        float MaxSpeed { get; }
        float Acel { get; }
        float Friction { get; }
        float ForceJump { get; }
        float MaxForceJump { get; }
        float GravityForce { get; }
        float TerminalVelocity { get; }
        bool ApplyGravity { get;  }

    }
}
