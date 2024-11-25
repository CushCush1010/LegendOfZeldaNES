using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace _3902_Project
{
    class EnvironmentFactory
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
        private int _endLevel = 5;

        private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        private Vector2 _startingPosition = new (0, 200);

        public List<List<ICollisionBox>> _collisionBoxes;
        

        public EnvironmentFactory() { }

        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile)
        {
            _linkManager = link;
            _enemyManager = enemy;
            _blockManager = block;
            _itemManager = item;
            _projectileManager = projectile;

            // Initialize Collision
            _collisionBoxes = new List<List<ICollisionBox>>();
            _collisionHandlerManager.LoadAll(link, enemy, block, item, projectile);

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
            _linkManager.SetLinkPosition(new Vector2(_startingPosition.X + 140, _startingPosition.Y + 310));
            loadBlocks();
            loadEnemies();
            loadItems();
            loadCollisions();
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

            // Detect Collisions
            List<CollisionData> detectedCollisions = CollisionDetector.DetectCollisions(_collisionBoxes);

            // Handle Collisions
            _collisionHandlerManager.HandleCollisions(detectedCollisions);
        }
    }
}