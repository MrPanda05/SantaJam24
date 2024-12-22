using Commons.Colectables;
using Godot;
using System;

namespace Platformer
{
    public partial class Trophy : Node2D, IColectable
    {
        public static Action OnTrophyColected;

        private void ChangeScene()
        {
            GetTree().ChangeSceneToFile("res://Platformer/Levels/Level2.tscn");
        }
        public void OnColect()
        {
            OnTrophyColected?.Invoke();
            GD.Print("You won!");
            //CallDeferred("ChangeScene");
        }
    }
}
