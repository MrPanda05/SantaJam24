using Godot;
using System;

namespace Platformer
{
    public partial class Explosionparti : Node2D
    {
        [Export]
        private GpuParticles2D _particles;

        public void Restart()
        {
            _particles.Restart();
        }
    }
}
