using Commons.Components;
using Godot;
using System;

namespace Platformer.Enemies
{
	public partial class TestEnemy : CharacterBody2D, IEnemy
	{
		[Export]
		public HealthComponent HealthComp { get; private set; }
		public void OnStompAreaAreaEntered(Area2D area)
		{
			HealthComp.TakeDamage();

		}
		public void Death()
		{
			GD.Print("Fuck the player cheating man!");
			QueueFree();
		}
		public override void _Ready()
		{
			HealthComp.OnDeath += Death;

		}
	}
}
