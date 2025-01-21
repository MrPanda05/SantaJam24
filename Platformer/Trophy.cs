using Commons.Colectables;
using Commons.Singletons;
using Godot;
using System;

namespace Platformer
{
    public partial class Trophy : Node2D, IColectable
    {
        public static Action OnTrophyColected;

        [Export]
        public AudioStreamPlayer SoundFX { get; set; }

        [Export]
        private Timer timer;

        [Export]
        private Area2D coli;

        [Export]
        public StaticBody2D blockArea;
        private void Disable()
        {
            coli.ProcessMode = ProcessModeEnum.Disabled;
        }
        public void OnColect()
        {
            timer.Start();
            SoundFX.Play();
            GD.Print("You won!");
            Visible = false;
            //CallDeferred("Disable");
            GameManager.SetNodeProcessMode(coli, ProcessModeEnum.Disabled);
            GameManager.SetNodeProcessMode(blockArea, ProcessModeEnum.Inherit);
        }
        public void OnTimerTimeout()
        {
            OnTrophyColected?.Invoke();
        }
    }
}
