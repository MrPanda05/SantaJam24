using Godot;
using System;

namespace Commons.Colectables
{
    public partial class Colector : Area2D
    {
        public void OnAreaEntered(Area2D area)
        {
            if(area is not ColectableArea) return;
            if(area.GetParent() is IColectable colectable)
            {
                colectable.OnColect();
            }
        }
    }
}
