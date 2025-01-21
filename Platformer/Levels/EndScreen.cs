using Commons.Singletons;
using Godot;
using System;

namespace Platformer.Levels
{
	public partial class EndScreen : Control
	{

        public static Action OnGameFinished;
        public void OnTimerTimeout()
        {
            //Add event to inform the GameManager or something like that it should change someshit
            GD.Print("Free player");
            OnGameFinished?.Invoke();
            GameManager.SetNodeProcessMode(this, ProcessModeEnum.Disabled);
        }
    }
}
