﻿using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace _3902_Project
{
    public class LinkCollisionHandler : ICollisionHandler
    {
        private LinkManager _link;

        public LinkCollisionHandler() { }

        public void LoadAll(LinkManager link)
        {
            _link = link;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            bool isCollidable = objectA.IsCollidable && objectB.IsCollidable;
            if (isCollidable && objectB is EnemyCollisionBox)
                HandleEnemyCollision(objectA, objectB, side);
            else if (isCollidable && objectB is EnemyProjCollisionBox)
                HandleEnemyProjCollision(objectA, objectB, side);
            else if (isCollidable && objectB is BlockCollisionBox)
                HandleBlockCollision(objectA, objectB, side);
            else if (isCollidable && objectB is ItemCollisionBox)
                HandleItemCollision(objectA, objectB, side);
        }


        private void HandleEnemyCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // if link is NOT in damage state, activate the state and remove health from link
            if (_link.IsLinkDamaged == false)
            {
                objectA.Health -= objectB.Damage;
                _link.IsLinkDamaged = true;
            }
        }

        private void HandleEnemyProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // if link is NOT in damage state, activate the state and remove health from link
            if (_link.IsLinkDamaged == false)
            {
                objectA.Health -= objectB.Damage;
                _link.IsLinkDamaged = true;
            }
        }


        private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB.IsCollidable)
            {
                // Handle player collision with block
                Rectangle BoundsA = objectA.Bounds;
                Rectangle BoundsB = objectB.Bounds;

                switch (side)
                {
                    case CollisionData.CollisionType.BOTTOM:
                        BoundsA.Y = BoundsB.Top - BoundsA.Height; break;    // Move player above the block
                    case CollisionData.CollisionType.TOP:
                        BoundsA.Y = BoundsB.Bottom; break;                  // Move player below the block
                    case CollisionData.CollisionType.RIGHT:
                        BoundsA.X = BoundsB.Left - BoundsA.Width; break;    // Move player to the left of the block
                    case CollisionData.CollisionType.LEFT:
                        BoundsA.X = BoundsB.Right; break;                   // Move player to the right of the block
                    default: break;
                }

                objectA.Bounds = BoundsA;
            }
        }

        private void HandleItemCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // add the item to links inventory
        }
    }
}