using Godot;
using System;

namespace Platformer
{
    public partial class PlayParticle : Node2D
    {
        [Export]
        public PackedScene particles;

        [Export]
        public Node2D posNode;

        [Export]
        public Vector2 posVec;

        //public void PlayParticlesPosNode()
        //{
        //    var newParticles = particles.Instantiate() as GpuParticles2D;
        //    AddChild(newParticles);
        //    newParticles.GlobalPosition = posNode.Position;
        //    GD.Print("Particle pos: " + newParticles.GlobalPosition);
        //    GD.Print("Target pos: " + posNode.Position);
        //    newParticles.Emitting = true;
        //}
        //public void PlayParticlesPosVec()
        //{
        //    var newParticles = particles.Instantiate() as GpuParticles2D;
        //    AddChild(newParticles);
        //    newParticles.GlobalPosition = posVec;
        //    GD.Print("Particle pos: " + newParticles.GlobalPosition);
        //    GD.Print("Target pos: " + posVec);
        //    newParticles.Emitting = true;
        //}
        //public void PlayParticlesPosNode(Node2D node)
        //{
        //    var newParticles = particles.Instantiate() as GpuParticles2D;
        //    AddChild(newParticles);
        //    newParticles.GlobalPosition = node.Position;
        //    GD.Print("Particle pos: " + newParticles.GlobalPosition);
        //    GD.Print("Target pos: " + node.Position);
        //    newParticles.Emitting = true;
        //}
        //public void PlayParticlesPosVec(Vector2 pos)
        //{
        //    var newParticles = particles.Instantiate() as GpuParticles2D;
        //    AddChild(newParticles);
        //    newParticles.GlobalPosition = pos;
        //    GD.Print("Particle pos: " + newParticles.GlobalPosition);
        //    GD.Print("Target pos: " + pos);
        //    newParticles.Emitting = true;
        //}
    }
}
