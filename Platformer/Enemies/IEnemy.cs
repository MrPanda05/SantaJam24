using Commons.Components;
using Godot;
using System;

namespace Platformer.Enemies
{

    public interface IEnemy
    {
        HealthComponent HealthComp { get; }
        void Death();

    }
}
