using Godot;
using System;

namespace Commons.Components
{
    public partial class HealthComponent : Node
    {
        [Export]
        public int Health { get; set; } = 1;
        [Export]
        public int MaxHealth { get; set; } = 1;

        public Action OnDeath;

        public void TakeDamage(int damage = 1)
        {
            Health -= damage;
            if(Health <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            OnDeath?.Invoke();
        }
    }
}
