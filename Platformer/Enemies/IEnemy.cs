using Commons.Components;
using Godot;
using Platformer.Enemies.AI;
using System;

namespace Platformer.Enemies
{
    /// <summary>
    /// Interface for enemies, things the player can kill
    /// </summary>
    public interface IEnemy
    {
        HealthComponent HealthComp { get; }

        IEnemyAI EnemyAI { get; }
        void Death();//How the enemy dies

    }
}
