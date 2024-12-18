using Godot;
using System;

namespace Platformer.Enemies.AI
{

    public interface IEnemyAI
    {
        void Logic(CharacterBody2D body);

        bool Activated { get; set; }
    }
}
