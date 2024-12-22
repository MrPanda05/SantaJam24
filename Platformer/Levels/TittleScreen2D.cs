using Godot;
using System;

namespace Platformer.Levels
{
	public partial class TittleScreen2D : Control
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			
		}
		public void OnPlayButtonButtonDown()
		{
			GetTree().ChangeSceneToFile("res://Platformer/Levels/Level1.tscn");
		}
		public void OnExitButtonDown()
		{
            GetTree().Quit();
        }



    }
}
