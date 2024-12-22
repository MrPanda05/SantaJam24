using Godot;
using System;

namespace Platformer.Levels
{
	public partial class EndScreen : Control
	{
		
		public void OnButtonButtonDown()
		{
            GetTree().Quit();
        }

    }
}
