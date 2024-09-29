﻿using _3902_Project.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        // Game objects and managers
        internal LinkPlayer Player { get; private set; }  // Player object
        internal BlockManager BlockManager { get; private set; }  // Block manager
        internal ItemManager ItemManager { get; private set; }  // Item manager
        internal EnemyManager EnemyManager { get; private set; }  // Enemy manager
        internal ProjectileManager ProjectileManager { get; private set; } //projectile manager FOR LINK'S PROJECTILES ONLY

        // Input controller
        private IController keyboardController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the game objects and input system
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);


            // Initialize the block and item manager
            BlockManager = new BlockManager(Content, _spriteBatch);
            ItemManager = new ItemManager(Content, _spriteBatch);
            ProjectileManager = new ProjectileManager(Content, _spriteBatch);

            // Initialize the player and character state
            Player = new LinkPlayer(_spriteBatch, Content, ProjectileManager);

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput

            // TODO: use this.Content to load your game content here
            // Block and Item Texture Loading
            BlockManager.LoadAllTextures();
            ItemManager.LoadAllTextures();
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Player.Update();
            ItemManager.Update();

            ProjectileManager.Update();

            // Update input controls
            keyboardController.Update();

            // TODO: Add your update logic here (e.g., update player, blocks, etc.)
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Player.Draw();

            BlockManager.Draw();
            ItemManager.Draw();

            ProjectileManager.Draw();

            base.Draw(gameTime);
        }

        // Exiting the game logic
        internal void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
