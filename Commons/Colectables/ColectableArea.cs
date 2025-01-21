using Commons.Singletons;
using Godot;
using System;

namespace Commons.Colectables
{
    public partial class ColectableArea : Area2D
    {

        public void DisableArea(ProcessModeEnum mode)
        {
            GameManager.SetNodeProcessMode(this, mode);
        }
    }
}

