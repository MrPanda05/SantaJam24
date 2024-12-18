using Godot;
using Platformer;
using Platformer.LePlayer2D;
using System;

namespace Commons.Singletons
{
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        private Player2d _player2d;

        public SpawnPoint LeSpawnPoint;
        public override void _Ready()
        {
            if(Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            Player2d.OnPlayerDeath += KillPlayer;
        }
        public override void _PhysicsProcess(double delta)
        {
            //Change this later
            if (Input.IsActionJustPressed("Respaw") && !_player2d.Visible)
            {
                RespawnPlayer();
            }
        }
        public void SetSpawnPoint(SpawnPoint spawn)
        {
            LeSpawnPoint = spawn;
        }
        public void SetPlayer(Player2d player)
        {
            _player2d = player;
        }
        public void KillPlayer()
        {
            _player2d ??= (Player2d)GetTree().GetFirstNodeInGroup("Player2D");
            CallDeferred("DisablePlayer");
        }
        public void RespawnPlayer()
        {
            GD.Print("RESPAWN");

            _player2d ??= (Player2d)GetTree().GetFirstNodeInGroup("Player2D");
            _player2d.GlobalPosition = LeSpawnPoint.GlobalPosition;
            CallDeferred("EnablePlayer");
        }
        public Vector2 GetPlayerGlobalPos()
        {
            _player2d ??= (Player2d)GetTree().GetFirstNodeInGroup("Player2D");
            return _player2d.GlobalPosition;
        }
        private void DisablePlayer()
        {
            _player2d.Visible = false;
            _player2d.ProcessMode = ProcessModeEnum.Disabled;
        }
        private void EnablePlayer()
        {
            _player2d.Visible = true;
            _player2d.ProcessMode = ProcessModeEnum.Inherit;
        }

    }
}
