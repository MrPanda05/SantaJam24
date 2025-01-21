using Commons.Singletons;
using Godot;
using System;

namespace FPS
{
    //The class name should've been soemthing like, FPSlevel one or somethin
    public partial class TittleScreen3D : Node3D
    {
        [Export]
        private SubViewport port;
        [Export]
        private Sprite3D tvTexture;

        private MeshInstance3D meshInstance;

        [Export]
        private Node2D Platformer;

        [Export]
        private FPSUImenu _menu;

        public override void _Ready()
        {
            tvTexture.Texture = port.GetTexture();
            port.CanvasItemDefaultTextureFilter = Viewport.DefaultCanvasItemTextureFilter.Nearest;
            _menu.OnAnimationPlatformerEnd += InitializePlatformer;
        }

        private void InitializePlatformer()
        {
            GameManager.SetNodeProcessMode(Platformer, ProcessModeEnum.Inherit);
        }
        public override void _UnhandledInput(InputEvent @event)
        {
            port.PushInput(@event);
        }
        public override void _ExitTree()
        {
            _menu.OnAnimationPlatformerEnd -= InitializePlatformer;

        }
    }
}
