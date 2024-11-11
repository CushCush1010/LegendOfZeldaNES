using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class CharacterStateManager
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public bool IsDead => Health <= 0;

        private float _damageCooldownTime = 1.0f; 
        private float _currentCooldownTime = 0.0f;

        private Game1 _game;

        private Dictionary<string, int> inventory;

        public CharacterStateManager(int maxHealth, Game1 game)

        {
            _game = game;
            MaxHealth = maxHealth;
            Health = maxHealth;
            inventory = new Dictionary<string, int>();
        }

        public void UpdateCooldown(GameTime gameTime)
        {
            if (_currentCooldownTime > 0)
            {
                _currentCooldownTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public bool CanTakeDamage()
        {
            return _currentCooldownTime <= 0;
        }

        public void DecreaseHealth(int amount)
        {
            if (CanTakeDamage())
            {
                Health -= amount;
                _currentCooldownTime = _damageCooldownTime;

                if (Health < 0) Health = 0;

                if (IsDead)
                {
                    HandleDeath();
                }
            }
        }

        public void IncreaseHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public void AddItem(string itemName)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName]++;
            }
            else
            {
                inventory[itemName] = 1;
            }
        }

        public void UseItem(string itemName)
        {
            if (inventory.ContainsKey(itemName) && inventory[itemName] > 0)
            {
                if (itemName == "HealthPotion")
                {
                    IncreaseHealth(2);
                }
                inventory[itemName]--;

                if (inventory[itemName] == 0)
                {
                    inventory.Remove(itemName);
                }
            }
        }

        public int GetFullHearts()
        {
            return Health / 2; // Each heart represents 2 HP
        }

        public bool HasHalfHeart()
        {
            return Health % 2 != 0; // If the remainder is not 0, it means there is half a heart
        }

        private void HandleDeath()
        {
            if (IsDead)
            {
                _game.ResetGame();
            }
        }
    }
}
