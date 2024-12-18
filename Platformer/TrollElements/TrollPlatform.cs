using Godot;
using System;

namespace Platformer.TrollsElements
{
    public partial class TrollPlatform : Node2D, ITroll
    {
        [Export]
        private bool _Reapear;

        [Export]
        private CollisionShape2D _hitBox;
        [Export]
        private CollisionShape2D _area;

        [Export]
        private Timer timer;
        public void OnBaseTrigger2dAreaEntered(Area2D area)
        {
            TrollMoment();

        }
        public void OnTimerTimeout()
        {
            Visible = true;
            _hitBox.SetDeferred("disabled", false);
            _area.SetDeferred("disabled", false);

        }

        public void TrollMoment()
        {

            Visible = false;
            _hitBox.SetDeferred("disabled", true);
            _area.SetDeferred("disabled", true);
            if (_Reapear)
            {
                //start time
                timer.Start();
            }
        }
    }
}
