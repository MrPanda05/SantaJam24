using Commons.Singletons;
using Godot;
using System;

namespace Platformer
{
    public partial class SpawnPoint : Area2D
    {

        [Export]
        private Vector2 SpawPoint;

        public void OnAreaEntered(Area2D area)
        {
            if (GameManager.Instance.LeSpawnPoint == this) return;
            GameManager.Instance.SetSpawnPoint(this);
            //Play anim
        }
    }
}

