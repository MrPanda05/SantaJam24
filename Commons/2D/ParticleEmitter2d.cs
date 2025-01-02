using Godot;
using System;

namespace Commons._2D
{
public partial class ParticleEmitter2d : Node2D
    {
        //Good enough for now
        //The reponsability of destroying particles with with the particle itself
        //It could also be done in a way to reuse particles instances, but I don't care for now
        public static void EmitParticles(Node2D currentScene, Vector2 position, string particle)
        {
            var particleScene = GD.Load<PackedScene>(particle);
            var newParticle = particleScene.Instantiate() as GpuParticles2D;
            currentScene.AddChild(newParticle);
            newParticle.GlobalPosition = position;
            newParticle.Restart();
        }
    }
}
