using Godot;
using System;

namespace FPS
{
    public partial class TittleScrenCamera : Camera3D
    {
        public AnimationPlayer animPlayer;

        public AnimationTree animTree;

        public override void _Ready()
        {
            animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
            animTree = GetNode<AnimationTree>("AnimationTree");

        }
    }
}

