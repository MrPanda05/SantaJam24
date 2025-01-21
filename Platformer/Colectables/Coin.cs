using Commons.Colectables;
using Commons.Singletons;
using Godot;
using System;

namespace Platformer.Colectables
{
    public partial class Coin : Node2D, IColectable
    {
        [Export]
        public AudioStreamPlayer SoundFX { get; set; }

        private ColectableArea area;

        public static Action OnCoinColected;

        public override void _Ready()
        {
            area = GetNode<ColectableArea>("ColectableArea");
        }
        public void OnColect()
        {
            GD.Print("I got coin");
            OnCoinColected?.Invoke();
            SoundFX.Play();
            Visible = false;
            //GameManager.SetNodeProcessMode(area, ProcessModeEnum.Disabled);
            area.DisableArea(ProcessModeEnum.Disabled);
        }
        public void OnAudioStreamPlayerFinished()
        {
            QueueFree();
        }
    }
}
