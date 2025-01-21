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

		[Export]
		private AnimatedSprite2D _sprite;
		[Export]
		private Timer _timer;
		[Export]
		private AnimationPlayer _playerAnim;

		[Export]
		private CollisionShape2D _SolidBox, _StopArea, _HitBox;

        public void OnStompAreaAreaEntered(Area2D area)
		{
			HealthComp.TakeDamage();

		}
		public void OnTimerTimeout()
		{
			GD.Print("killmyself");
			QueueFree();
		}

        public void Death()
		{
            //GD.Print("Fuck the player cheating man!");
            _timer.Start();
            _sprite.Play("Dead");
            _playerAnim.Play("DeathAnim");
            //_SolidBox.SetDeferred("disabled", true);
            _StopArea.SetDeferred("disabled", true);
            _HitBox.SetDeferred("disabled", true);


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
        public override void _ExitTree()
        {
            HealthComp.OnDeath -= Death;
        }
    }
}
