using Godot;
using System;

namespace Platformer
{
    public partial class ParticlesTest : Node2D
    {
        [Export]
        private PlayParticle DeathParticle;
        [Export]
        private GpuParticles2D particles2;

        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("test"))
            {
                DeathParticle.PlatParticleAt(Position, particles2);
                DeathParticle.PlatParticleAt(Position + new Vector2(15, 10), particles2);

            }
        }
    }
}
