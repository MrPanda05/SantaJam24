using Godot;
using Platformer.Colectables;
using Platformer.LePlayer2D;
using System;

namespace Commons.Singletons
{
    public partial class Inventory : Node
    {

        public int CoinCount { get; private set; }
        public int DeathCount { get; private set; }

        public Action OnInventoryUpdated;


        public void AddCoin()
        {
            CoinCount++;
            OnInventoryUpdated?.Invoke();
        }
        public void AddDeath()
        {
            DeathCount++;
            OnInventoryUpdated?.Invoke();
        }
        //Add tapes
        public override void _Ready()
        {
            Coin.OnCoinColected += AddCoin;
            Player2d.OnPlayerDeath += AddDeath;
        }
    }
}
