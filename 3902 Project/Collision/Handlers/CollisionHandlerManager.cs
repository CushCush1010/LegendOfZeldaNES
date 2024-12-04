using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private LinkCollisionHandler _linkCollisionHandler = new ();
        private EnemyCollisionHandler _enemyCollisionHandler = new();
        private BlockCollisionHandler _blockCollisionHandler = new();
        private ItemCollisionHandler _itemCollisionHandler = new();
        private ProjectileCollisionHandler _projectileCollisionHandler = new();


        /// <summary>
        /// Constructor that creates the class, nothing more
        /// </summary>
        public CollisionHandlerManager() { }

        /// <summary>
        /// Takes and then loads all managers for the collision handlers
        /// </summary>
        /// <param name="link">LinkManager</param>
        /// <param name="enemy">EnemyManager</param>
        /// <param name="block">BlockManager</param>
        /// <param name="item">ItemManager</param>
        /// <param name="projectile">ProjectileManager</param>
        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile,EnvironmentFactory _environmentFactory
            )
        {
            _linkCollisionHandler.LoadAll(link);
            _enemyCollisionHandler.LoadAll(enemy);
            _blockCollisionHandler.LoadAll(block, _environmentFactory);
            _itemCollisionHandler.LoadAll(item);
            _projectileCollisionHandler.LoadAll(projectile);


        }

        /// <summary>
        /// Handles the collisions given
        /// </summary>
        /// <param name="collisions">the List of CollisionData that we get current collisions from</param>
        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }
        }

        /// <summary>
        /// Actually sends/handles the current collision
        /// </summary>
        /// <param name="objectA">the first collision box</param>
        /// <param name="objectB">the second collision box</param>
        /// <param name="side">the side in which the collision occured</param>
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // Handle collisions involving Link as ObjectA (highest priority)
            if (objectA is LinkCollisionBox)
            {
                _linkCollisionHandler.HandleCollision(objectA, objectB, side);
                if (objectB is EnemyCollisionBox)
                    _enemyCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is BlockCollisionBox)
                    _blockCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is ItemCollisionBox)
                    _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }

            // Handle collisions involving enemy, but not Link (since Link is already done/will never be ObjectB at this point)
            else if (objectA is EnemyCollisionBox)
            {
                // change enemy based on collisions
                _enemyCollisionHandler.HandleCollision(objectA, objectB, side);
                // when enemy collides with a block, change the block if needed
                if (objectB is BlockCollisionBox)
                    _blockCollisionHandler.HandleCollision(objectB, objectA, side);
                // when enemy collides with a projectile, change the projectile if needed
                else if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);
                // don't need items since enemies can't interact with items
                // else if (objectB is ItemCollisionBox)
                    // _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }

            else if (objectA is BlockCollisionBox) 
            {
                // block is either moved or destroyed
                _blockCollisionHandler.HandleCollision(objectA, objectB, side);
                // when a projectile hits a block, it needs to be destoryed
                if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);

                // don't need items since blocks can't interact with items
                // else if (objectB is ItemCollisionBox)
                // _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }
        }
    }
}