﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Wizzrope, Proto, Darknut }

        // enemy dictionary/inventory
        private List<ISprite> _runningEnemies = new List<ISprite>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        public List <ICollisionBox> collisionBoxes { get; private set; }
        private int _currentEnemyIndex = 0;


        // constructor
        public EnemyManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;

            collisionBoxes = new List<ICollisionBox>();
            PlaceEnemy(EnemyNames.BrownSlime, new Vector2(300, 200));
        }


        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }


        public void PlaceEnemy(EnemyNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateEnemy(name);

            //hardcoded for now for demo purposes - assumes it is a brown slime CHANGE LATER PLEASE
            Vector2 xy = ((BrownSlime)currentSprite).GetPosition();
            ICollisionBox collision = new EnemyCollisionBox(new Rectangle((int)xy.X, (int)xy.Y, 64, 64), true, 100, 10);
            collisionBoxes.Add(collision);

            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);
        }


        public void UnloadAllEnemies() { _runningEnemies.Clear(); collisionBoxes.Clear(); }

        // Draw the current enemy
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Draw(_spriteBatch);
            }
        }
        public void UpdateBounds(EnemyCollisionBox collisionBox, Rectangle newBounds)
        {
            int i = collisionBoxes.IndexOf(collisionBox);
            collisionBoxes[i].Bounds = newBounds;
            _runningEnemies[i].SetPosition(new Vector2(newBounds.X, newBounds.Y));

        }

        public void Update()
        {
            int i = 0;
            foreach (ISprite enemy in _runningEnemies)
            {
                enemy.Update();

                Vector2 xy = enemy.GetPosition();
                collisionBoxes[i].Bounds = new Rectangle((int)xy.X, (int)xy.Y, 64, 64);
                i++;

            }
        }
    }
}
