using Commons.Colectables;
using Commons.Singletons;
using Godot;
using System;

namespace Platformer.Colectables
{
    public partial class Casset : Node2D, IColectable
    {
        [Export]
        public AudioStreamPlayer SoundFX { get; set; }

        private ColectableArea area;

        [Export]
        public int tapeIndex;

        public override void _Ready()
        {
            area = GetNode<ColectableArea>("ColectableArea");
        }

        public void OnColect()
        {
            //GameManager.Instance.tapesColected.ForEach(x => GD.Print(x));
            GameManager.Instance.tapesColected[tapeIndex] = true;
            GD.Print("Casset player");
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
