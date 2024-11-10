using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists 
    {
        /// <param name="manager">the projectile manager that stores all current running projectiles</param>
        /// <param name="projectileName">the name associated with the projectile, so it can run in the manager</param>
        /// <param name="timer">the amount of time the projectile will be active on screen</param>
        /// <param name="speed">the speed of the projectile as it moves on screen</param>
        /// <param name="printScale">sprite dimensions * printScale: the scale at which you increase/decrease the print dimensions of the sprite</param>
        /// <param name="frameRanges">
        /// range: [0 -> 1], amountOfInputs = amountOfSprites - 1 AND MUST BE IN ORDER - values inputed are multiplied by timer to produce the
        /// framerates for the sprites being called.
        /// <example>EXAMPLE: if entered [0.5, 0.7] for a 3 sprite projectile: from 0 -> 0.5 (first sprite) to 0.5 -> 0.7 (second sprite) 
        /// to 0.7 -> 1 (third sprite). </example>
        /// </param>
        /// <returns>the projectie that is specifically called in the renderer list</returns>
        public ISprite CreateProjectile(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    return CreateProjectileSize2(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size3DownUp:
                    return CreateProjectileSize3DownUp(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size3RightLeft:
                    return CreateProjectileSize3RightLeft(manager, projectileName, timer, speed, printScale, frameRanges);
                case RendOrder.Size4:
                    return CreateProjectileSize4(manager, projectileName, timer, speed, printScale, frameRanges);
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDraw");
            }
        }

        private ISprite CreateProjectileSize2(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDownUp.GetVectorPosition(), _direction, printScale);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName,_rendDownUp.GetVectorPosition(), _direction, printScale);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetVectorPosition(), _direction, printScale);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetVectorPosition(), _direction, printScale);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize3DownUp(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDownUp.GetVectorPosition(), _direction, printScale);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendDownUp.GetVectorPosition(), _direction, printScale);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRight.GetVectorPosition(), _direction, printScale);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendLeft.GetVectorPosition(), _direction, printScale);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize3RightLeft(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDown.GetVectorPosition(), _direction, printScale);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendUp.GetVectorPosition(), _direction, printScale);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetVectorPosition(), _direction, printScale);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendRightLeft.GetVectorPosition(), _direction, printScale);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private ISprite CreateProjectileSize4(ProjectileManager manager, ProjectileManager.ProjectileNames projectileName, int timer, float speed, float printScale, float[] frameRanges)
        {
            switch ((int)_direction)
            {
                case 0: // spawn DOWN
                    return manager.CallProjectile(projectileName, _rendDown.GetVectorPosition(), _direction, printScale);
                case 1: // spawn UP
                    return manager.CallProjectile(projectileName, _rendUp.GetVectorPosition(), _direction, printScale);
                case 2: // spawn RIGHT
                    return manager.CallProjectile(projectileName, _rendRight.GetVectorPosition(), _direction, printScale);
                case 3: // spawn LEFT
                    return manager.CallProjectile(projectileName, _rendLeft.GetVectorPosition(), _direction, printScale);
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }
    }
}