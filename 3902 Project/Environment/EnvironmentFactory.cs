using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace _3902_Project
{
    public class EnvironmentFactory
    {
        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;
        private CollisionHandlerManager _collisionHandlerManager = new ();
        private ProjectileManager _projectileManager;
        private LinkManager _linkManager;
        private CharacterStateManager _characterStateManager;

        private int _level;
        private int _prevLevel = -1; // -1 is a stand in for a null value
        private int _endLevel = 4;

        private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;
        private SpriteBatch _spriteBatch;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        private Vector2 _startingPosition = new (0, 200);

        public List<List<ICollisionBox>> _collisionBoxes;

        private float _fadeAlpha = 1f; // from 1 (full black) to 0 (full transparency)
        private bool _isFading = false;

        private GraphicsDevice _graphicsDevice;
        private Texture2D _whiteTexture;


        public EnvironmentFactory() { }

       

        public void LoadContent()
        {

            _whiteTexture = new Texture2D(_graphicsDevice, 1, 1);
            _whiteTexture.SetData(new Color[] { Color.White });
        }


        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile,SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            _linkManager = link;
            _enemyManager = enemy;
            _blockManager = block;
            _itemManager = item;
            _projectileManager = projectile;
            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;

            // Initialize Collision
            _collisionBoxes = new List<List<ICollisionBox>>();
            _collisionHandlerManager.LoadAll(link, enemy, block, item, projectile, this);
            this.LoadContent();

            _level = 1;

            _csvTranslationsBlock = new Dictionary<string, BlockManager.BlockNames>();
            _csvTranslationsEnemy = new Dictionary<string, EnemyManager.EnemyNames>();
            _csvTranslationsItem = new Dictionary<string, ItemManager.ItemNames>();
            generateTranslations();
        }

        /*public EnvironmentFactory(BlockManager blockManager, ItemManager itemManager, LinkPlayer player, EnemyManager enemyManager, ProjectileManager projectileManager)
        {
            this.blockManager = blockManager;
            this.itemManager = itemManager;
            this.player = player;
            this.enemyManager = enemyManager;
            this.projectileManager = projectileManager;
        }*/

        // Read CSV files
        private List<List<string>> ReadCsvFile(string filePath)
        {
            var matrix = new List<List<string>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    matrix.Add(new List<string>(values));
                }
            }

            return matrix;
        }

        private void generateTranslations()
        {
            _csvTranslationsBlock.Add("-", BlockManager.BlockNames.Tile);
            _csvTranslationsBlock.Add("b", BlockManager.BlockNames.Water);
            _csvTranslationsBlock.Add("p", BlockManager.BlockNames.Square);
            _csvTranslationsBlock.Add("s", BlockManager.BlockNames.StatueDragon_LEFT);
            _csvTranslationsBlock.Add("d", BlockManager.BlockNames.Dirt);

            _csvTranslationsEnemy.Add("g", EnemyManager.EnemyNames.GreenSlime);
            _csvTranslationsEnemy.Add("b", EnemyManager.EnemyNames.BrownSlime);
            _csvTranslationsEnemy.Add("d", EnemyManager.EnemyNames.Darknut);

            _csvTranslationsItem.Add("fs", ItemManager.ItemNames.FlashingScripture);
            _csvTranslationsItem.Add("fl", ItemManager.ItemNames.FlashingLife);
            _csvTranslationsItem.Add("fp", ItemManager.ItemNames.FlashingPotion);
            _csvTranslationsItem.Add("fh", ItemManager.ItemNames.AddLife);
            _csvTranslationsItem.Add("fa", ItemManager.ItemNames.FlashingArrow);
            _csvTranslationsItem.Add("bo", ItemManager.ItemNames.Bomb);
            _csvTranslationsItem.Add("nk", ItemManager.ItemNames.NormalKey);
            _csvTranslationsItem.Add("bk", ItemManager.ItemNames.BossKey);
            _csvTranslationsItem.Add("c", ItemManager.ItemNames.Clock);
            _csvTranslationsItem.Add("m", ItemManager.ItemNames.Meat);
            _csvTranslationsItem.Add("h", ItemManager.ItemNames.Horn);
        }

        public Rectangle getRoomDimensions()
        {
            return new Rectangle(128, 128, 768, 448);
        }

        public int getLevel()
        {
            return _level;
        }

        private void loadBlocks()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Levels/Level" + _level.ToString() + ".csv";
            _environment = ReadCsvFile(filepath);

            _blockManager.AddBlock(BlockManager.BlockNames.Environment, new Vector2((int)_startingPosition.X, (int)_startingPosition.Y), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_UP, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y + 576), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT, new Vector2((int)_startingPosition.X, (int)_startingPosition.Y + 288), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT, new Vector2((int)_startingPosition.X + 1024 - 128, (int)_startingPosition.Y + 288), 4F);

            //adjust boundary
            Rectangle topLeftInvisible = new((int)(_startingPosition.X + 128), (int)(_startingPosition.Y + 78), (int)(_startingPosition.X + 448) - (int)(_startingPosition.X + 128), 50);
            Rectangle topRightInvisible = new Rectangle((int)(_startingPosition.X + 576), (int)(_startingPosition.Y + 78),(int)(_startingPosition.X + 1024 - 128) - (int)(_startingPosition.X + 576), 50);
            Rectangle rightTopInvisible = new Rectangle((int)(_startingPosition.X + 896),(int)(_startingPosition.Y + 78),50,(int)(_startingPosition.Y + 288) - (int)(_startingPosition.Y + 78));
            Rectangle rightBottomInvisible = new Rectangle((int)(_startingPosition.X + 896), (int)(_startingPosition.Y + 416),50, (int)(_startingPosition.Y + 768) - (int)(_startingPosition.Y + 576));
            Rectangle bottomRightInvisible = new Rectangle((int)(_startingPosition.X + 576),(int)(_startingPosition.Y + 576),(int)(_startingPosition.X + 1024 - 128) - (int)(_startingPosition.X + 576),50);
            Rectangle bottomLeftInvisible = new Rectangle((int)(_startingPosition.X + 128),(int)(_startingPosition.Y + 576),(int)(_startingPosition.X + 448) - (int)(_startingPosition.X + 128),50);
            Rectangle leftBottomInvisible = new Rectangle((int)(_startingPosition.X + 78),(int)(_startingPosition.Y + 416), 50, (int)(_startingPosition.Y + 768) - (int)(_startingPosition.Y + 576));
            Rectangle leftTopInvisible = new Rectangle((int)(_startingPosition.X + 78), (int)(_startingPosition.Y + 78),50,(int)(_startingPosition.Y + 288) - (int)(_startingPosition.Y + 78));

            //add block
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, topLeftInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, topRightInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, rightTopInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, rightBottomInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, bottomRightInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, bottomLeftInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, leftBottomInvisible, 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, leftTopInvisible, 4F);

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];

                    if (_csvTranslationsBlock.ContainsKey(blockToPlace))
                    {
                        _blockManager.AddBlock(_csvTranslationsBlock[blockToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + (i * 64)), 4F);
                    }
                }
            }
        }

        private void loadEnemies()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Enemies/Enemy" + _level.ToString() + ".csv";
            _enemies = ReadCsvFile(filepath);

            for (int i = 0; i < _enemies.Count; i++)
            {
                for (int j = 0; j < _enemies[i].Count; j++)
                {
                    string enemyToPlace = _enemies[i][j];

                    if (_csvTranslationsEnemy.ContainsKey(enemyToPlace))
                        _enemyManager.AddEnemy(_csvTranslationsEnemy[enemyToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + (i * 64)), 4F);
                }
            }
        }

        private void loadItems()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Items/Item" + _level.ToString() + ".csv";
            _items = ReadCsvFile(filepath);

            for (int i = 0; i < _items.Count; i++)
            {
                for (int j = 0; j < _items[i].Count; j++)
                {
                    string itemToPlace = _items[i][j];

                    if (_csvTranslationsItem.ContainsKey(itemToPlace))
                    {
                        _itemManager.AddItem(_csvTranslationsItem[itemToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + (i * 64)), 4F);
                    }
                }
            }
        }

        // expects this to be called AFTER everything else has loaded so collision boxes can be correctly added 
        public void loadCollisions()
        {
            _collisionBoxes.Clear();

            // add the collision boxes IN ORDER (VERY IMPORTANT)
            List<ICollisionBox> linkCollision = new List<ICollisionBox>();
            linkCollision.Add(_linkManager._collisionBox);

            _collisionBoxes.Add(linkCollision);
            _collisionBoxes.Add(_enemyManager.GetCollisionBoxes());
            _collisionBoxes.Add(_blockManager.GetCollisionBoxes());
            _collisionBoxes.Add(_projectileManager.GetCollisionBoxes());
            _collisionBoxes.Add(_itemManager.GetCollisionBoxes());
        }

        public void loadLevel()
        {
            loadBlocks();
            loadEnemies();
            loadItems();
            loadCollisions();

            // Activate the gradient effect
            _fadeAlpha = 1f;  // black
            _isFading = true;
        }

        public void incrementLevel()
        {
            if (_level < _endLevel) { _level++; }
        }

        public void decrementLevel()
        {
            if (_level > 1) { _level--; }
        }

        public void Update()
        {
            if (_prevLevel != -1 && _prevLevel != _level)
            {
                _enemyManager.UnloadAllEnemies();
                _itemManager.UnloadAllItems();
                _blockManager.UnloadAllBlocks();
                _projectileManager.UnloadAllProjectiles();

                loadLevel();
            }

            _prevLevel = _level;

            // Update the transparency and position if a gradient is being applied
            if (_isFading)
            {
                _fadeAlpha -= 0.03f;  // Reduced transparency value per frame
                if (_fadeAlpha <= 0)
                {
                    _fadeAlpha = 0;
                    _isFading = false;  // finishing gradient
                }
            }

            // Detect Collisions
            List<CollisionData> detectedCollisions = CollisionDetector.DetectCollisions(_collisionBoxes);

            // Handle Collisions
            _collisionHandlerManager.HandleCollisions(detectedCollisions);
        }



        public void Draw()
        {
            _spriteBatch.Begin();

    
            if (_isFading)
            {
                // Black rectangle on the left (moving from left to right)
                float leftWidth = 1024 * 0.5f * _fadeAlpha;
                _spriteBatch.Draw(_whiteTexture, new Rectangle(0, 0, (int)leftWidth, 900), Color.Black);

                // Black rectangle on the right (moving from right to left)
                float rightWidth = 1024 * 0.5f * _fadeAlpha;
                _spriteBatch.Draw(_whiteTexture, new Rectangle(1024 - (int)rightWidth, 0, (int)rightWidth, 900), Color.Black);
            }

            _spriteBatch.End();
        }


    }
}