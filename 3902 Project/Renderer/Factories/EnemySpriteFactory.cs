﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Position that all enemies will initially be placed at 
        private Vector2 _position = new Vector2(480, 300);

        // Create a singleton instance of EnemySpriteFactory
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        // Constructor to initialize the factory instance
        private EnemySpriteFactory()
        {
            EnemySpriteFactory.instance = this;
        }

        // Load all necessary textures (both enemy sprites and bullet textures for shooters)
        public void LoadAllTextures(ContentManager content)
        {
            // Load the enemy spritesheet
            _enemySpritesheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");
        }

        // Create an instance of Green Monster 1 with shooting capability
        public ISprite CreateHolsteringEnemy_GreenSlime() { return new GreenSlime(_enemySpritesheet, _position); }


        // Create an instance of Green Monster 2 without shooting capability
        public ISprite CreateHolsteringEnemy_BrownSlime() { return new BrownSlime(_enemySpritesheet, _position); }

        // Create an instance of Rope1 without shooting capability
        public ISprite CreateHolsteringEnemy_Wizzrope() { return new Wizzrope(_enemySpritesheet, _position); }

        // Create an instance of Rope2 without shooting capability
        public ISprite CreateHolsteringEnemy_Proto() { return new Proto(_enemySpritesheet, _position); }

        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}
