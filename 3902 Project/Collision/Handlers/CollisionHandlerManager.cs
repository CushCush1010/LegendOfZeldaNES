using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private LinkCollisionHandler LinkCollisionHandler;
        private EnemyCollisionHandler EnemyCollisionHandler;
        private ItemCollisionHandler ItemCollisionHandler;
        private BlockCollisionHandler BlockCollisionHandler;
        private ProjectileCollisionHandler ProjectileCollisionHandler;
        private CharacterStateManager characterState;

        public CollisionHandlerManager(LinkManager link, EnemyManager enemyManager, ItemManager itemManager, ProjectileManager projectileManager, CharacterStateManager characterStateManager)
        {
            EnemyCollisionHandler = new EnemyCollisionHandler(enemyManager, characterStateManager);
            LinkCollisionHandler = new LinkCollisionHandler(link, enemyManager, itemManager, characterStateManager);
            ItemCollisionHandler = new ItemCollisionHandler(link, itemManager);
            BlockCollisionHandler = new BlockCollisionHandler();
            ProjectileCollisionHandler = new ProjectileCollisionHandler(projectileManager, enemyManager);
        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            bool isCollidable = objectA.IsCollidable && objectB.IsCollidable;

            // Handle collisions involving projectiles (highest priority given since projectile manager needs these)
            if (objectA is LinkCollisionBox || objectB is LinkCollisionBox)
            {
                LinkCollisionHandler.HandleCollision((LinkCollisionBox)objectA, objectB, side, isCollidable);
            }
            else if (objectA is ProjectileCollisionBox || objectB is ProjectileCollisionBox)
            {
                ProjectileCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }
            else if (objectA is EnemyCollisionBox || objectB is EnemyCollisionBox)
            {
                EnemyCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }
            else if (objectA is BlockCollisionBox || objectB is BlockCollisionBox)
            {
                BlockCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }
            else if (objectA is ItemCollisionBox || objectB is ItemCollisionBox)
            {
                ItemCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }
        }
    }
}