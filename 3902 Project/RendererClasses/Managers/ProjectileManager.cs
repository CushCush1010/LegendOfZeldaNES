using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ProjectileManager
    {
        public enum ProjectileNames
        {
            Bomb, BlueArrow, FireBall
        }

        private List<ISprite> _runningProjectiles = new List<ISprite>();
        private List<ICollisionBox> _projectileCollisionBoxes = new List<ICollisionBox>();
        private ProjectileFactory _factory = ProjectileFactory.Instance;
        private SpriteBatch _spriteBatch;

        // constructor
        public ProjectileManager() { }

        public void LoadAll(SpriteBatch spriteBatch, ContentManager content) { _spriteBatch = spriteBatch; _factory.LoadAllTextures(content); }

        /// <summary>
        /// call the projectile for sprites with only frames, meaning that it is a projectile that is only one animation, and NO direction or NO frame/renderer switching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="direction"></param>
        /// <returns>the sprite added to the list</returns>
        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, Renderer.DIRECTION direction, float printScale)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
            _projectileCollisionBoxes.Add(new ProjectileCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 32, 32), 10, 1));
            return currentSprite;
        }

        /// <summary>
        /// call the projectile for sprites with only frames, meaning that it is a projectile that is only one animation, and NO direction or NO frame/renderer switching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <returns>the sprite added to the list</returns>
        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
            _projectileCollisionBoxes.Add(new ProjectileCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 32, 32), 10, 1));
            return currentSprite;
        }

        public void LoadAllTextures(ContentManager content)
        {
            _factory.LoadAllTextures(content);
        }

        public void UnloadAllTextures(ContentManager content)
        {
            _factory.UnloadAllTextures(content);
        }

        public void UnloadProjectile(ISprite sprite)
        {
            int index = _runningProjectiles.IndexOf(sprite);
            _runningProjectiles.Remove(sprite);
            //_projectileCollisionBoxes.RemoveAt(index);
        }

        public void UnloadAllProjectiles()
        {
            _runningProjectiles.Clear();
            _projectileCollisionBoxes.Clear();
        }


        /// <summary>
        /// Remove/Unload all Projectile Sprites
        /// </summary>
        public void UnloadAllBlocks() { _runningProjectiles = new List<ISprite>(); }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var projectile in _runningProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            int i = 0;
            foreach (ISprite projectile in _runningProjectiles)
            {
                projectile.Update();
            
                var box = _projectileCollisionBoxes[i];
                // Uncomment and update projectile's position as needed.
                //box.Bounds = new Rectangle(projectile.get);

                if (IsOffScreen(box))
                {
                    ProjectileIsDead(box);
                }
                i++;
            }
        }

        /*public void UpdateCollisions(List<ICollisionBox> otherObjects)
        {
            var allObjects = new List<ICollisionBox>(_projectilesCollisions);
            allObjects.AddRange(otherObjects);
            List<CollisionData> collisions = CollisionDetector.DetectCollisions(new List<List<ICollisionBox>> { allObjects });

            foreach (var collision in collisions)
            {
                if ((_projectilesCollisions.Contains(collision.ObjectA as ProjectileCollisionBox) && collision.ObjectA is ProjectileCollisionBox) ||
                    (_projectilesCollisions.Contains(collision.ObjectB as ProjectileCollisionBox) && collision.ObjectB is ProjectileCollisionBox))
                {
                    _collisionHandler.HandleCollision(collision.ObjectA, collision.ObjectB, collision.CollisionSide, true);
                }
            }
        }*/

        public void ProjectileIsDead(ICollisionBox projectile)
        {
            int index = _projectileCollisionBoxes.IndexOf(projectile);
            _projectileCollisionBoxes.Remove(projectile);
            _runningProjectiles.RemoveAt(index);
        }

        private bool IsOffScreen(ICollisionBox projectile)
        {
            // Implement logic to check if the projectile is off-screen
            // Example:
            // return !gameViewport.Bounds.Contains(projectile.Bounds);
            return false;
        }

        public List<ICollisionBox> GetCollisionBoxes()
        {
            return _projectileCollisionBoxes;
        }
    }
}