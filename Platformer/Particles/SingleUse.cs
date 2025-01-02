using Commons;
using Godot;
using System;

namespace Platformer.particles
{
    public partial class SingleUse : GpuParticles2D, IParticles
    {
        public void DestroySelf()
        {
            QueueFree();
        }
        public void OnFinished()
        {
            //GD.Print("PARTICLE FINISHED");
            DestroySelf();
        }
    }
}
