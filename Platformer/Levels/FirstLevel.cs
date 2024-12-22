using Godot;
using System;

namespace Platformer.Levels
{
    public partial class FirstLevel : Node2D
    {
        public bool IsInSubViewPort { get; private set; }
        public override void _Ready()
        {
            var paren = GetParent();
            if(paren is SubViewport)
            {
                GD.Print("sUB");
                IsInSubViewPort = true;
            }
            else
            {
                GD.Print("Not sub");
                IsInSubViewPort = false;
            }
            Trophy.OnTrophyColected += CallChangeScene;

        }
        public void ChangeScene()
        {
            var parent = GetParent();
            var newScene = ResourceLoader.Load<PackedScene>("res://Platformer/Levels/Level2.tscn").Instantiate();
            if (IsInSubViewPort)
            {
                parent.AddChild(newScene);
                ///parent.RenderTargetClearMode
                QueueFree();
            }
            else
            {
                //Change this so that it points to an end screen
                GetTree().ChangeSceneToFile("res://Platformer/Levels/EndScreen.tscn");
            }
        }
        private void CallChangeScene()
        {
            CallDeferred("ChangeScene");
        }
    }
}
