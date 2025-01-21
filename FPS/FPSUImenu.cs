using Godot;
using Platformer.Levels;
using System;

namespace FPS
{
    public partial class FPSUImenu : Node3D
    {
        [Export]
        private Control _mainMenu;
        [Export]
        private Control _settings;

        public Action OnAnimationPlatformerEnd;

        [Export]

        private TittleScrenCamera camera;

        [Export]
        private Timer timer;
        public override void _Ready()
        {
            EndScreen.OnGameFinished += FreePlayer;
        }
        public override void _ExitTree()
        {
            EndScreen.OnGameFinished -= FreePlayer;

        }
        private void FreePlayer()
        {
            camera.animPlayer.Play("GameEnded");
        }
        public void OnStartButtonDown()
        {
            //animPlayer.Play("PlayGame");
            camera.animPlayer.Play("PlayGame");
            //camera.animTree.Set("parameters/conditions/PlayGame", true);
            _mainMenu.Visible = false;
            _settings.Visible = false;
        }
        public void OnSettingsButtonDown()
        {
            //camera.animTree.Set("parameters/conditions/Settings", true);
            camera.animPlayer.Play("GoingSettings");

            _mainMenu.Visible = false;

        }
        public void OnReturnButtonDown()
        {
            //camera.animTree.Set("parameters/conditions/ReturnMenu", true);
            camera.animPlayer.Play("Iddle");
            _settings.Visible = false;
        }
        public void OnAnimationPlayerAnimationFinished(string anim)
        {
            if (anim == "PlayGame")
            {
                OnAnimationPlatformerEnd?.Invoke();
                return;
            }
            if (anim == "GoingSettings")
            {
                _settings.Visible = true;
            }
            if(anim == "GameEnded")
            {
                GD.Print("Choose tape");
            }
        }

        public void OnAnimationPlayerCurrentAnimationChanged(string anim)
        {
            if (anim == "Iddle")
            {
                //_mainMenu.Visible = true;
                timer.Start();
                //camera.animTree.Set("parameters/conditions/Iddle", true);
            }
        }
        public void OnTimerTimeout()
        {
            _mainMenu.Visible = true;
        }
        private float PercentToDB(float percent)
        {
            float scale = 20f;
            float divisor = 50f;
            return MathF.Log10(percent / divisor) * scale;
        }
        public void OnMasterVolumeValueChanged(float value)
        {
            int index = AudioServer.GetBusIndex("Master");
            if (value == 0)
            {
                AudioServer.SetBusMute(index, true);
                return;
            }
            if (AudioServer.IsBusMute(index))
            {
                AudioServer.SetBusMute(index, false);
            }
            float decibels = PercentToDB(value);
            AudioServer.SetBusVolumeDb(index, decibels);
        }
        public void OnSoundFxVolumeValueChanged(float value)
        {
            int index = AudioServer.GetBusIndex("SFX");
            if (value == 0)
            {
                AudioServer.SetBusMute(index, true);
                return;
            }
            if (AudioServer.IsBusMute(index))
            {
                AudioServer.SetBusMute(index, false);
            }
            float decibels = PercentToDB(value);
            AudioServer.SetBusVolumeDb(index, decibels);
        }
        public void OnMusicVolumeValueChanged(float value)
        {
            int index = AudioServer.GetBusIndex("Music");
            if (value == 0)
            {
                AudioServer.SetBusMute(index, true);
                return;
            }
            if (AudioServer.IsBusMute(index))
            {
                AudioServer.SetBusMute(index, false);
            }
            float decibels = PercentToDB(value);
            AudioServer.SetBusVolumeDb(index, decibels);
        }
    }
}
