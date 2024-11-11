using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using _3902_Project;
using System;

namespace _3902_Project
{
    public class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Darknut }

        // enemy dictionary/inventory
        private List<ISprite> _runningEnemies = new List<ISprite>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private SpriteBatch _spriteBatch;
        

        public List <ICollisionBox> collisionBoxes { get; private set; }
        private Game1 _game;

        public List<ICollisionBox> _collisionBoxes { get; private set; }
        private int _currentEnemyIndex = 0;

        // constructor
        public EnemyManager()
        {
            _collisionBoxes = new List<ICollisionBox>();
        }


        // Load all of enemies necesities
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, ProjectileManager projectile) 
        {
            _spriteBatch = spriteBatch;
            _factory.LoadAllTextures(content);
            _factory.LoadProjectileManager(projectile); 
        }

        /// <summary>
        /// Add an enemy to the running enemy list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public ISprite AddEnemy(EnemyNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateEnemy(name, printScale);

            //hardcoded for now for demo purposes - assumes it is a brown slime CHANGE LATER PLEASE
            ICollisionBox collision = new EnemyCollisionBox(currentSprite.GetRectanglePosition(), true, 100, 10);
            collisionBoxes.Add(collision);

            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);

            return currentSprite;
        }

        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() 
        { 
            _runningEnemies.Clear(); 
            _collisionBoxes.Clear(); 
        }

        /// <summary>
        /// Draw all enemies in the List
        /// </summary>
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Draw(_spriteBatch);
            }
        }

        public void UpdateBounds(EnemyCollisionBox collisionBox)
        {
            int i = collisionBoxes.IndexOf(collisionBox);
            if (i >= 0)
            {
                collisionBoxes[i].Bounds = collisionBox.Bounds;
                _runningEnemies[i].SetPosition(new Vector2(collisionBox.Bounds.X, collisionBox.Bounds.Y));
            }
        }

        public void Update()
        {
            Random random = new Random();

            foreach (var enemy in _runningEnemies)
            {
                enemy.Update();
            }
        }

        /*
        public void EnemyIsDead(EnemyCollisionBox enemyCollisionBox)
        {
            int index = collisionBoxes.IndexOf(enemyCollisionBox);

            if (index >= 0)
            {
                // Remove collision box and enemy sprite
                collisionBoxes.RemoveAt(index);
                ISprite enemySprite = _runningEnemies[index];
                _runningEnemies.RemoveAt(index);

                collisionBoxes[i].Bounds = enemy.GetRectanglePosition();
                i++;

            }
        }
        */
    }
}
