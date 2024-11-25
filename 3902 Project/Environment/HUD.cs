﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class HUD
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private ItemManager _itemManager;
        private LinkManager _linkManager;
        private SpriteFont _font;

        private int level;
        private int maxLevel = 4;

        private Vector2 _emeraldPos = new Vector2(300, 20);
        private Vector2 _keyPos = new Vector2(300, 80);
        private Vector2 _bombPos = new Vector2(300, 140);
        private Vector2 _boxAPos = new Vector2(480, 100);
        private Vector2 _boxNPos = new Vector2(610, 100);

        private ISprite spriteBoxA;
        private ISprite spriteBoxN;

        private int _emeraldCount = 0;
        private int _keyCount = 0;
        private int _orbCount = 0;

        public HUD() {}
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, LinkManager link, ItemManager item)
        {
            _spriteBatch = spriteBatch;
            _content = content;
            _itemManager = item;
            _linkManager = link;
            level = 1;

            _font = _content.Load<SpriteFont>("Menu");
            addStationary();
        }

        public void incrementLevel() { if (level < maxLevel)  level++;  }
        public void decrementLevel() { if (level > 1) level--; }
        public void incrementEmeralds() { _emeraldCount++; }
        public void decrementEmeralds() { if (_emeraldCount > 0) _emeraldCount--; }
        public void incrementKeys() { _keyCount++; }
        public void decrementKeys() { if (_keyCount > 0) _keyCount--; }
        public void incrementOrbs() { _orbCount++; }
        public void decrementOrbs() { if (_orbCount > 0) _orbCount--; }

        public void addWeaponToA(ItemManager.ItemNames name)
        {
            if (spriteBoxA != null) { _itemManager.UnloadMenuItem(spriteBoxA);}
            spriteBoxA = _itemManager.AddMenuItem(name, _boxAPos, 4F);
        }

        public void addWeaponToB(ItemManager.ItemNames name)
        {
            if (spriteBoxN != null) { _itemManager.UnloadMenuItem(spriteBoxN); }
            spriteBoxN = _itemManager.AddMenuItem(name, _boxNPos, 4F);
        }

        private void addStationary()
        {
            _itemManager.AddMenuItem(ItemManager.ItemNames.Emerald, _emeraldPos, 3F);
            _itemManager.AddMenuItem(ItemManager.ItemNames.NormalKey, _keyPos, 3F);
            _itemManager.AddMenuItem(ItemManager.ItemNames.Bomb, _bombPos, 3F);
        }

        public void Draw()
        {

            //if (_characterState == null)
            //{
            //    throw new InvalidOperationException("CharacterStateManager is not initialized.");
            //}
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _spriteBatch.DrawString(_font, "- LIFE -", new Vector2(700, 30), Color.Red);
            _spriteBatch.End();

            // Draw a heart shape based on the character's HP
            int fullHearts = _linkManager.CollisionBox.Health / 2;
            bool hasHalfHeart = _linkManager.CollisionBox.Health != 0;
            int maxHearts = _linkManager.MaxHealth / 2;

            float heartScale = 4F; // Scaling ratio for heart

            for (int i = 0; i < maxHearts; i++)
            {
                ISprite heartSprite;

                if (i < fullHearts)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartFull, new Vector2(700 + i * 40, 60), heartScale);
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartHalf, new Vector2(700 + i * 40, 60), heartScale);
                }
                else
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartEmpty, new Vector2(700 + i * 40, 60), heartScale);
                }

                heartSprite.Draw(_spriteBatch); 
            }
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            // _spriteBatch.DrawString(_font, "- LIFE -", new Vector2(750, 30), Color.Red);
            _spriteBatch.DrawString(_font, "X" + _emeraldCount, new Vector2(350, 40), Color.White);
            _spriteBatch.DrawString(_font, "X" + _keyCount, new Vector2(350, 100), Color.White);
            _spriteBatch.DrawString(_font, "X" + _orbCount, new Vector2(350, 150), Color.White);
            _spriteBatch.DrawString(_font, "xA", new Vector2(480, 30), Color.White);
            _spriteBatch.DrawString(_font, "xN", new Vector2(620, 30), Color.White);
            _spriteBatch.End();
        }
    }
}