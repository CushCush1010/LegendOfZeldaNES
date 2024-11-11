using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private float _positionSpeed;

        /// <param name="positionSpeed">the speed at which the update position is set to</param>
        /// <returns>returns the updated position direction of the current renderer in the list</returns>
        public Vector2 CreateGetUpdatePosition(float positionSpeed) { _positionSpeed = positionSpeed; return GetUpdatePosition(); }

        private Vector2 GetUpdatePosition()
        {
            // set the directions
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: return SetDownMovementPosition();         // DOWN Direction
                case Renderer.DIRECTION.UP: return SetUpMovementPosition();             // UP Direciton
                case Renderer.DIRECTION.RIGHT: return SetRightMovementPosition();       // RIGHT Direciton
                case Renderer.DIRECTION.LEFT: return SetLeftMovementPosition();         // LEFT Direciton
                default: throw new ArgumentException("Invalid direction type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetDownMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:           return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:     return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:  return _rendDown.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:               return _rendDown.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");

            }
        }

        private Vector2 SetUpMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendDownUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendUp.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendUp.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetRightMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendRight.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendRight.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }

        private Vector2 SetLeftMovementPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip:               return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:         return _rendLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:      return _rendRightLeft.GetUpdatePosition(_positionSpeed);
                case RendOrder.Size4:                   return _rendLeft.GetUpdatePosition(_positionSpeed);
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }
    }
}