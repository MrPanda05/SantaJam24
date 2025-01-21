using Godot;
using System;

namespace FPS
{
	public partial class Fadeblack : Control
	{
		[Export]
		private AnimationPlayer player;

        public void FadeToBlack()
		{
            player.Play("Fadeblack");
		}
        public void FadeOut()
        {
            player.Play("Fadeout");
        }
        public void OnAnimationPlayerAnimationFinished(string anim)
		{
            if (anim == "Fadeblack")
            {
                GetTree().ChangeSceneToFile("res://FPS/WatchingScene.tscn");
            }
        }

    }

}
