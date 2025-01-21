using Commons.Singletons;
using Godot;
using System;

namespace Platformer
{
    public partial class SpawnPoint : Area2D
    {

        [Export]
        private Vector2 SpawPoint;

        [Export]
        private AudioStreamPlayer _soundFX;

        public void OnAreaEntered(Area2D area)
        {
            if (GameManager.Instance.LeSpawnPoint == this) return;
            _soundFX?.Play();
            GameManager.Instance.SetSpawnPoint(this);
            //Play anim
        }
    }
}

