using Godot;
using System;

namespace Commons
{
    public interface ITriggers
    {
        void Action();//What should happen when it is trigger! Sucess case only
        bool Repeatable { get; }
        bool HasBeenUsed { get; }
    }
}
