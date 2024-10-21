﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace _3902_Project
{
    class EnvironmentFactory : IEnvironmentFactory
    {

        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;

        private int _level;
        private int _prevLevel = -1; // -1 is a stand in for a null value

        private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        public EnvironmentFactory(BlockManager block, ItemManager item, EnemyManager enemy) 
        {
            _blockManager = block;
            _itemManager = item;
            _enemyManager = enemy;

            _level = 0;

            _csvTranslationsBlock = new Dictionary<string, BlockManager.BlockNames>();
            _csvTranslationsEnemy = new Dictionary<string, EnemyManager.EnemyNames>();
            _csvTranslationsItem = new Dictionary<string, ItemManager.ItemNames>();
            generateTranslations();
        }

        private List<List<string>> ReadCsvFile(string filePath)
        {
            var matrix = new List<List<string>>();

            // Use StreamReader to read the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split each line by commas (or other delimiter)
                    var values = line.Split(',');

                    // Add the row (as a list of strings) to the matrix
                    matrix.Add(new List<string>(values));
                }
            }

            return matrix;
        }

        private void generateTranslations()
        {
            _csvTranslationsBlock.Add("-", BlockManager.BlockNames.Tile);
            _csvTranslationsBlock.Add("s", BlockManager.BlockNames.Square);
            _csvTranslationsBlock.Add("d", BlockManager.BlockNames.Dirt);

            _csvTranslationsEnemy.Add("g", EnemyManager.EnemyNames.GreenSlime);
            _csvTranslationsEnemy.Add("w", EnemyManager.EnemyNames.Wizzrope);
            _csvTranslationsEnemy.Add("b", EnemyManager.EnemyNames.BrownSlime);
            _csvTranslationsEnemy.Add("d", EnemyManager.EnemyNames.Darknut);
            
            _csvTranslationsItem.Add("fs", ItemManager.ItemNames.FlashingScripture);
            _csvTranslationsItem.Add("fp", ItemManager.ItemNames.FlashingPotion);
            _csvTranslationsItem.Add("bk", ItemManager.ItemNames.BossKey);
            _csvTranslationsItem.Add("c", ItemManager.ItemNames.Compass);

        }

        // This method must be refactored
        public Dictionary<BlockManager.BlockNames, List<Rectangle>> getCollidables()
        {
            Dictionary<BlockManager.BlockNames, List<Rectangle>> result = new Dictionary<BlockManager.BlockNames, List<Rectangle>>();

            // List the collidables
            HashSet<BlockManager.BlockNames> collidables = new HashSet<BlockManager.BlockNames>();
            collidables.Add(BlockManager.BlockNames.Square);

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToCheck = _environment[i][j];
                    if (collidables.Contains(_csvTranslationsBlock[blockToCheck]))
                    {
                        //Add collidable to dictionary
                        if (!result.ContainsKey(_csvTranslationsBlock[blockToCheck]))
                        {
                            result[_csvTranslationsBlock[blockToCheck]] = new List<Rectangle>();
                        }
                        result[_csvTranslationsBlock[blockToCheck]].Add(new Rectangle(128 + (j * 64), 128 + (i * 64), 64, 64));
                    }
                }
            }

            return result;
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

            _blockManager.PlaceBlock(BlockManager.BlockNames.Environment, new Vector2(0, 0));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN, new Vector2(448, 0));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT, new Vector2(0, 414));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_UP, new Vector2(576, 700));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT, new Vector2(1024, 286));

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];
                    _blockManager.PlaceBlock(_csvTranslationsBlock[blockToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)));
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

                    if (enemyToPlace != "-")
                    {
                        _enemyManager.PlaceEnemy(_csvTranslationsEnemy[enemyToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)));
                    }
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

                    if (itemToPlace != "-")
                    {
                        _itemManager.PlaceItem(_csvTranslationsItem[itemToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)));
                    }
                }
            }
        }

        public void loadLevel()
        {
            loadBlocks();
            loadEnemies();
            loadItems();
        }

        public void incrementLevel()
        {
            if (_level < 2) { _level++; }
        }

        public void decrementLevel()
        {
            if (_level > 0) { _level--; }
        }

        public void Update()
        {
            if ( _prevLevel != -1 && _prevLevel != _level)
            {
                _enemyManager.UnloadAllEnemies();
                _itemManager.UnloadAllItems();
                _blockManager.UnloadAllBlocks();

                loadLevel();
            }
            
            _prevLevel = _level;
        }
    }
}
