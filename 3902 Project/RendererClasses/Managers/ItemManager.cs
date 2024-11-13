﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // create item names for finding them
        public enum ItemNames
        {
            AddLife, Clock, Meat, Sword, Shield, Bomb, Bow, Horn, Flute, WaterPlate, Ladder, Emerald, LongSword,
            MagicStaff, Game, NormalKey, BossKey, Compass, FlashingLife, DepletingHeart, FlashingEmerald,
            FlashingPotion, FlashingScripture, FlashingSword, FlashingBanana, FlashingArrow,
            FlashingCandle, FlashingRing, FlashingTriForce, HeartEmpty, HeartHalf, HeartFull,
        }

        // item dictionary/inventory
        private List<ISprite> _runningItems = new List<ISprite>();
        private List<ISprite> _menuItems = new List<ISprite>();

        private List<ICollisionBox> _collisionBoxes = new List<ICollisionBox>();

        // create variables for passing
        private ItemSpriteFactory _factory = ItemSpriteFactory.Instance;
        private SpriteBatch _spriteBatch;

        // constructor
        public ItemManager() { }

        // load all textures relating to blocks
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content) { _spriteBatch = spriteBatch; _factory.LoadAllTextures(content); }


        /// <summary>
        /// Add an item to the running item list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        public ISprite AddItem(ItemNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateItem(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningItems.Add(currentSprite);

            // Add item collision box for collision detection
            _collisionBoxes.Add(new ItemCollisionBox(currentSprite));

            return currentSprite;
        }

        public ISprite AddMenuItem(ItemNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateItem(name, printScale);

            currentSprite.SetPosition(placementPosition);
            _menuItems.Add(currentSprite);

            return currentSprite;
        }

        public void UnloadMenuItem(ISprite spriteToRemove)
        {
            _menuItems.Remove(spriteToRemove);
        }

        // remove item after being collected
        public void UnloadItem(ICollisionBox item)
        {
            _runningItems.Remove(item.Sprite);
            _collisionBoxes.Remove(item);
        }

        public void UnloadAllMenuItems() { _menuItems.Clear(); }

        public void UnloadAllItems() { _runningItems.Clear(); _collisionBoxes.Clear(); }


        /// <summary>
        /// Draw all items in the List
        /// </summary>
        public void Draw()
        {
            foreach (var item in _runningItems)
            { item.Draw(_spriteBatch); }

            foreach (var item in _menuItems)
            { item.Draw(_spriteBatch); }
        }


        /// <summary>
        /// Update all items in the List
        /// </summary>
        public void Update()
        {
            foreach (var item in _runningItems)
            { item.Update(); }
        }

        // Method to get collision boxes for all items
        public List<ICollisionBox> GetCollisionBoxes()
        {
            return _collisionBoxes;
        }
    }
}