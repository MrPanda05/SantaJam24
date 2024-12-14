using Godot;
using System;

namespace Platformer.LePlayer2D
{
	public partial class PlayerCamera : Camera2D
	{
		[Export]
		private Player2d _player;
        public override void _Ready()
        {
            //Position = _player.Position;

        }
        public override void _Process(double delta)
        {
            //Position = _player.Position;
            ///
        }
    }
}
