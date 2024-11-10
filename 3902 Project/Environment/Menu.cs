using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace _3902_Project
{
    public class Menu
    {
        ContentManager _content;
        SpriteBatch _batch;
        ItemManager _itemManager;
        CharacterStateManager _characterState;
        SpriteFont _font;

        int level;

        public Menu(ContentManager content, SpriteBatch spriteBatch, ItemManager itemManager, CharacterStateManager characterState)
        {
            _content = content;
            _batch = spriteBatch;
            _itemManager = itemManager;
            _characterState = characterState ?? throw new ArgumentNullException(nameof(characterState));

            level = 1;
        }

        public void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Menu");
        }

        public void incrementLevel() { if (level < 4) level++; }
        public void decrementLevel() { if (level > 1) level--; }



        public void Draw()
        {

            //if (_characterState == null)
            //{
            //    throw new InvalidOperationException("CharacterStateManager is not initialized.");
            //}
            _batch.Begin();
            _batch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _batch.DrawString(_font, "- LIFE -", new Vector2(700, 30), Color.Red);
            _batch.End();

            // Draw a heart shape based on the character's HP
            int fullHearts = _characterState.GetFullHearts();
            bool hasHalfHeart = _characterState.HasHalfHeart();
            int maxHearts = _characterState.MaxHealth / 2;

            float heartScale = 4F; // Scaling ratio for heart

            for (int i = 0; i < maxHearts; i++)
            {
                ISprite heartSprite;

                if (i < fullHearts)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP2, new Vector2(700 + i * 40, 60), heartScale);
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP1, new Vector2(700 + i * 40, 60), heartScale);
                }
                else
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP0, new Vector2(700 + i * 40, 60), heartScale);
                }

                heartSprite.Draw(_batch); 
            }
        }
    }
}