using Commons;
using Commons._2D;
using Commons.Components;
using Godot;
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
        public static Action OnPlayerDeath;


        #region PlayerMovement
        private void MovePlayer()
        {
            Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
            if (direction != Vector2.Zero)
            {
                _vel.X = Mathf.Lerp(_vel.X, direction.X * _velocityComponent.Speed, _velocityComponent.Acel);

            }
            else
            {
                _vel.X = Mathf.Lerp(_vel.X, 0, _velocityComponent.Friction);
                if (Mathf.IsEqualApprox(_vel.X, 0)) _vel.X = 0;
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
                    GD.Print("Low jump " + _vel.Y);
                }
            }
            else
            {
                GD.Print("High jump " + _vel.Y);

            }
        }

        public void OnBufferJumpTimerTimeout()
        {
            if (IsOnFloor())
            {
                JumpHeightTimer.Start();
                Jump();
                GD.Print("Jump was buffered");
                Velocity = _vel;
                MoveAndSlide();
                return;
            }
            _BufferJump = false;
            GD.Print("Jump Was not buffered");

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
                GD.Print("I hit an enemy, please kill yourself enemy");
                _vel.Y = -_velocityComponent.ForceJump/1.3f;
                Velocity = _vel;
                //Add some light timer to avoid player dying just in case
            }
        }

        public void OnPlayerHitboxAreaEntered(Area2D area)
        {
            if (_vel.Y > 0) return;
            GD.Print("Fuck! I got hit");
            _healthComponent.TakeDamage();//Add way detect when player dies
        }
        #endregion

        public void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
            //ProcessMode = ProcessModeEnum.Disabled; fix this
            //Visible = false;
            GD.Print("FUCK I DIED FUCK");
        }

        public override void _Ready()
        {
            _velocityComponent = GetNode<VelocityComponent2d>("VelocityComponent2D");
            _healthComponent.OnDeath += PlayerDeath;
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
                IWantToJump();
            }
            //Movement
            MovePlayer();
            _WasOnFloor = IsOnFloor();
            Velocity = _vel;
            MoveAndSlide();
            if(_WasOnFloor && !IsOnFloor() && Velocity.Y >= 0)
            {
                _CoyoteTime = true;
                CoyoteJumpTimer.Start();
            }
        }

        private void IWantToJump()
        {
            if (IsOnFloor())
            {
                GD.Print("Jump");
                JumpHeightTimer.Start();
                Jump();
                return;
            }
            if(!IsOnFloor() && !_CoyoteTime)
            {
                GD.Print("Buffer the jump");
                BufferTimer.Start();
                return;
            }
            if(!IsOnFloor() && _CoyoteTime)
            {
                GD.Print("Coyote please!");
                JumpHeightTimer.Start();
                Jump();
                return;
            }
        }
    }
}
