using Commons.Singletons;
using Godot;
using Platformer.LePlayer2D;
using System;

namespace Platformer
{
	public partial class GameUi : CanvasLayer
	{
		[Export]
		private Label deathLabel, coinLabel;

		[Export]
		private Control Tips;
		public override void _Ready()
		{
			GameManager.Instance.inventory.OnInventoryUpdated += UpdateUI;
			Player2d.OnPlayerDeath += EnableTips;
			GameManager.Instance.OnPlayerRespawn += DisableTips;

        }
		public void DisableTips()
		{
			Tips.Visible = false;
		}
		public void EnableTips()
		{
			Tips.Visible = true;
		}
		public void UpdateUI()
		{
            coinLabel.Text = GameManager.Instance.inventory.CoinCount.ToString();
            deathLabel.Text = GameManager.Instance.inventory.DeathCount.ToString();
        }
        public override void _PhysicsProcess(double delta)
        {
			if (Input.IsActionJustPressed("GiveUP") && Tips.Visible)
			{
				GetTree().Quit();
			}
        }
    }
}
