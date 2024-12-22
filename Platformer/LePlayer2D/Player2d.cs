using Commons;
using Commons._2D;
using Commons.Components;
using Commons.Singletons;
using Godot;
using Platformer.TrollsElements;
using System;

namespace Platformer.LePlayer2D
{

	public partial class Player2d : CharacterBody2D
	{
        private VelocityComponent2d _velocityComponent;
        [Export]
        private HealthComponent _healthComponent;

        private Vector2 _vel;

        [Export]
        private Timer JumpHeightTimer;
        [Export]
        private Timer CoyoteJumpTimer;
        [Export]
        private Timer BufferTimer;

        private bool _BufferJump;
        private bool _CoyoteTime;


        private bool _WasOnFloor;

        private bool _OnOneWayPlatform;
        public static Action OnPlayerDeath;

        [Export]
        public AnimatedSprite2D sprite;

        public bool isPlayerDead;

        [Export]
        private PlayParticle DeathParticle;

        public bool Moving { get; private set; }

        private bool IsNearZero(float value)
        {
            if (value == 0) return true;
            if(value > 0.05f && value < 0.5f)
            {
                return true;
            }
            if (value < -0.05f && value > -0.5f)
            {
                return true;
            }
            return false;
        }

        #region PlayerMovement
        private void MovePlayer()
        {
            Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
            Moving = Input.IsActionPressed("Left");
            if (direction != Vector2.Zero)
            {
                _vel.X = Mathf.Lerp(_vel.X, direction.X * _velocityComponent.Speed, _velocityComponent.Acel);

            }
            else
            {
                _vel.X = Mathf.Lerp(_vel.X, 0, _velocityComponent.Friction);
                if (IsNearZero(_vel.X)) _vel.X = 0;
            }
        }
        private void Jump()
        {

            _vel.Y = -_velocityComponent.ForceJump;// * (1 + Mathf.Abs(Mathf.Clamp(_vel.X, 0, _vel.X/550))); this is supposed to give a jump heigh bost while runing, does not work
            if (_CoyoteTime) _CoyoteTime = false;
        }
        private void AddGravity(double delta)
        {
            _vel.Y += Mathf.Clamp(_velocityComponent.GravityForce * (float)delta, 0, _velocityComponent.TerminalVelocity);
        }

        public void OnJumpHeightTimeout()
        {
            if (!Input.IsActionPressed("Jump"))
            {
                if (_vel.Y <= -_velocityComponent.MaxForceJump)
                {
                    _vel.Y = -_velocityComponent.MaxForceJump;
                    Velocity = _vel;
                    //GD.Print("Low jump " + _vel.Y);
                }
            }
            else
            {
                //GD.Print("High jump " + _vel.Y);

            }
        }

        public void OnBufferJumpTimerTimeout()
        {
            if (IsOnFloor())
            {
                JumpHeightTimer.Start();
                Jump();
                //GD.Print("Jump was buffered");
                Velocity = _vel;
                MoveAndSlide();
                return;
            }
            _BufferJump = false;
            //GD.Print("Jump Was not buffered");

        }

        public void OnCoyoteTimerTimeout()
        {
            _CoyoteTime = false;
        }

        #endregion

        #region PlayerHitbox
        public void OnPlayerFeetAreaEntered(Area2D area)
        {
            if(_vel.Y > 0)
            {
                //GD.Print("I hit an enemy, please kill yourself enemy");
                _vel.Y = -_velocityComponent.ForceJump/1.3f;
                Velocity = _vel;
                //Add some light timer to avoid player dying just in case
            }
        }

        public void OnPlayerHitboxAreaEntered(Area2D area)
        {
            if(area.CollisionLayer == 1024)//Hit Enemy
            {
                if (_vel.Y > 0) return;
                _healthComponent.TakeDamage();
                return;
            }
            if(area.CollisionLayer == 2048 && !isPlayerDead)//Hit kill area
            {
                GD.Print("I hit a kill barrier");
                _healthComponent.TakeDamage();
                return;
            }
        }
        public void OnPlayerFeetBodyEntered(Node2D body)
        {
            _OnOneWayPlatform = true;
        }
        public void OnPlayerFeetBodyExited(Node2D body)
        {
            _OnOneWayPlatform = false;
        }
        #endregion

        public void PlayerDeath()
        {
            //DeathParticle.PlayParticlesPosNode(this);FCUK
            isPlayerDead = true;
            OnPlayerDeath?.Invoke();
            //ProcessMode = ProcessModeEnum.Disabled; fix this
            //Visible = false;
            //GD.Print("FUCK I DIED FUCK");
        }
        
        public override void _Ready()
        {
            _velocityComponent = GetNode<VelocityComponent2d>("VelocityComponent2D");
            _healthComponent.OnDeath += PlayerDeath;
            GameManager.Instance.SetPlayer(this);
        }

        public override void _PhysicsProcess(double delta)
        {
            _vel = Velocity;
            //Add gravity
            if (!IsOnFloor() && _velocityComponent.ApplyGravity)
            {
                AddGravity(delta);
            }
            //Jump
            if ((Input.IsActionJustPressed("Jump")))
            {
                JumpDecider();
            }
            if(_OnOneWayPlatform && Input.IsActionPressed("Down"))
            {
                var pos = Position;
                pos.Y += 1;
                Position = pos;
            }
            //Movement
            MovePlayer();
            //GD.Print(Velocity.X);
            _WasOnFloor = IsOnFloor();
            Velocity = _vel;
            MoveAndSlide();
            if(_WasOnFloor && !IsOnFloor() && Velocity.Y >= 0)
            {
                _CoyoteTime = true;
                CoyoteJumpTimer.Start();
            }
        }

        private void JumpDecider()
        {
            if (IsOnFloor())
            {
                //GD.Print("Jump");
                JumpHeightTimer.Start();
                Jump();
                return;
            }
            if(!IsOnFloor() && !_CoyoteTime)
            {
                //GD.Print("Buffer the jump");
                BufferTimer.Start();
                return;
            }
            if(!IsOnFloor() && _CoyoteTime)
            {
                //GD.Print("Coyote please!");
                JumpHeightTimer.Start();
                Jump();
                return;
            }
        }
    }
}
