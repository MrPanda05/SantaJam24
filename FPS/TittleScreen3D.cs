using Godot;
using System;

namespace FPS
{
    public partial class TittleScreen3D : Node3D
    {
        [Export]
        private SubViewport port;
        [Export]
        private Sprite3D tvTexture;

        private MeshInstance3D meshInstance;


        public override void _Ready()
        {
            //port.RenderTargetClearMode = SubViewport.ClearMode.Once;
            tvTexture.Texture = port.GetTexture();
            port.CanvasItemDefaultTextureFilter = Viewport.DefaultCanvasItemTextureFilter.Nearest;
            //meshInstance.MaterialOverride.AlbedoTexture = port.GetTexture();

            //Material mat = meshInstance.MaterialOverride;
        }
        public override void _PhysicsProcess(double delta)
        {
        }
        public override void _UnhandledInput(InputEvent @event)
        {
            port.PushInput(@event);
        }
    }
}
