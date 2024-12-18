using Commons.Components;
using Godot;
using Platformer.Enemies.AI;
using System;

namespace Platformer.Enemies
{
	public partial class TestEnemy : CharacterBody2D, IEnemy
	{
		[Export]
		public HealthComponent HealthComp { get; private set; }

        public IEnemyAI EnemyAI { get; private set; }

		[Export]
		public NodePath path;

        public void OnStompAreaAreaEntered(Area2D area)
		{
			HealthComp.TakeDamage();

		}

        public void Death()
		{
			//GD.Print("Fuck the player cheating man!");
			QueueFree();
		}
		public override void _Ready()
		{
			HealthComp.OnDeath += Death;
			var test = GetNode<Node2D>(path);
            EnemyAI = (IEnemyAI)test;
            //GD.Print(test is IEnemyAI);
            //GD.Print(test.Name);

        }
        public override void _PhysicsProcess(double delta)
        {
			EnemyAI?.Logic(this);
        }
    }
}
