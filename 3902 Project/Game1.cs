using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game objects and managers
        internal LinkManager LinkManager = new();
        internal BlockManager BlockManager = new();
        internal ItemManager ItemManager = new();
        internal EnemyManager EnemyManager = new();
        internal ProjectileManager ProjectileManager = new();
        internal CharacterStateManager CharacterStateManager = new();
        internal EnvironmentFactory EnvironmentFactory = new();
        internal BackgroundMusic BackgroundMusic = new();
        internal HUD Menu = new();

        //private List<ICollisionBox> _EnemyCollisionBoxes;


        Texture2D _outline;
        private bool _drawCollidables = false;
        public bool DoDrawCollisions
        {
            get { return _drawCollidables; }
            set { _drawCollidables = value; }
        }
        //private List<ICollisionBox> _blockCollisionBoxes;
        //private List<ICollisionBox> _itemCollisionBoxes;

        // Input controller
        internal IController keyboardController;
        internal IController mouseController;
        

        public Game1()
        {
            _graphics = new(this)
            {
                PreferredBackBufferWidth = 256 * 4,
                PreferredBackBufferHeight = 900  // (1024, 900)
            };
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

            // Initialize keyboard input controller
            keyboardController = new KeyboardInput(this);  // Pass the Game1 instance to KeyboardInput
            mouseController = new MouseInput(this);

            // Loading all Managers
            BlockManager.LoadAll(_spriteBatch, Content);
            ItemManager.LoadAll(_spriteBatch, Content);
            ProjectileManager.LoadAll(_spriteBatch, Content);
            EnemyManager.LoadAll(_spriteBatch, Content, ProjectileManager);
            LinkManager.LoadAll(_spriteBatch, Content, ProjectileManager,this);
            BackgroundMusic.LoadAll(Content);
            BackgroundMusic.LoadSongs();
            CharacterStateManager.LoadAll(this, 6);
            Menu.LoadAll(_spriteBatch, Content, CharacterStateManager, ItemManager);
            // for the showing of collisions
            _outline = Content.Load<Texture2D>("Dungeon_Block_and_Room_Spritesheet_transparent");

            EnvironmentFactory.LoadAll(LinkManager, EnemyManager, BlockManager, ItemManager, ProjectileManager, _spriteBatch, GraphicsDevice);
            EnvironmentFactory.loadLevel();

            Menu.addWeaponToA(ItemManager.ItemNames.LongSword);
            Menu.addWeaponToB(ItemManager.ItemNames.Bomb);
        }

        protected override void Update(GameTime gameTime)
        {
            CharacterStateManager.UpdateCooldown(gameTime);

            BlockManager.Update();
            ItemManager.Update();
            ProjectileManager.Update();
            EnemyManager.Update(); 
            LinkManager.Update();
            EnvironmentFactory.Update();

            // Update input controls
            keyboardController.Update();
            mouseController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            BlockManager.Draw();
            ItemManager.Draw();
            ProjectileManager.Draw();
            EnemyManager.Draw();
            LinkManager.Draw();
            Menu.Draw();
            EnvironmentFactory.Draw();

            // draw the collisions if the enters "C"
            if (DoDrawCollisions)
                DrawCollisions();

            base.Draw(gameTime);
        }

        public void DrawCollisions()
        {
            List<List<ICollisionBox>> collisions = EnvironmentFactory._collisionBoxes;
            Color color = Color.White;
            int lineWidth = 3;

            _spriteBatch.Begin();
            for (int i = 0; i < collisions.Count; i++)
            {
                //if (i == 1) continue;
                List<ICollisionBox> collisionBoxes = collisions[i];
                foreach (ICollisionBox collisionBox in collisionBoxes)
                {
                    Rectangle bounds = collisionBox.Bounds;
                    if (i == 0) color = Color.White;
                    if (i == 1) color = Color.Red;
                    if (i == 2) color = Color.Green;
                    if (i == 3) color = Color.Blue;
                    if (i == 4) color = Color.Yellow;
                    Rectangle outlineTop =      new (bounds.X, bounds.Y, bounds.Width, lineWidth);
                    Rectangle outlineLeft =     new (bounds.X, bounds.Y, lineWidth, bounds.Height);
                    Rectangle outlineBottom =   new (bounds.X, bounds.Y + (bounds.Height - lineWidth), bounds.Width, lineWidth);
                    Rectangle outlineRight =    new (bounds.X + (bounds.Width - lineWidth), bounds.Y, lineWidth, bounds.Height);
                    Rectangle rectangleSource = new (235, 1213, 8, 8);
                    _spriteBatch.Draw(_outline, outlineTop, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineBottom, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineRight, rectangleSource, color);
                    _spriteBatch.Draw(_outline, outlineLeft, rectangleSource, color);
                }
            }
            _spriteBatch.End();
        }


        public void ResetGame() { Initialize(); }
    }
}