using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <param name="positionSpeed">the speed at which the update moves</param>
        /// <returns>returns the updated position at some randomly generated movement</returns>
        public void CreateSetRandomDirection() { SetRandomDirection(); }

        private void SetRandomDirection()
        {
            int randomValue = _random.Next(4);
            SetDirection(randomValue);
            // Randomly choose a direction:
            switch (randomValue)
            {
                case 0: SetDownDirection(); break;      // DOWN Direction
                case 1: SetUpDirection(); break;        // UP Direciton
                case 2: SetRightDirection(); break;     // RIGHT Direciton
                case 3: SetLeftDirection(); break;      // LEFT Direciton
            }
        }

        private void SetDownDirection()
        {
            switch(_rendListType)
                {
                    case RendOrder.Size2:
                    case RendOrder.Size2DownUpFlip:
                    case RendOrder.Size2RightLeftFlip:
                    case RendOrder.Size2Flip: _rendDownUp.SetDirection(_direction); break;
                    case RendOrder.Size3DownUp:
                    case RendOrder.Size3DownUpFlip: _rendDownUp.SetDirection(_direction); break;
                    case RendOrder.Size3RightLeft:
                    case RendOrder.Size3RightLeftFlip: _rendDown.SetDirection(_direction); break;
                    case RendOrder.Size4: _rendDown.SetDirection(_direction); break;
                }
        }

        private void SetUpDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendDownUp.SetDirection(_direction); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendDownUp.SetDirection(_direction); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendUp.SetDirection(_direction); break;
                case RendOrder.Size4: _rendUp.SetDirection(_direction); break;
            }
        }

        private void SetRightDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendRightLeft.SetDirection(_direction); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendRight.SetDirection(_direction); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendRightLeft.SetDirection(_direction); break;
                case RendOrder.Size4: _rendRight.SetDirection(_direction); break;
            }
        }

        private void SetLeftDirection()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: _rendRightLeft.SetDirection(_direction); break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: _rendLeft.SetDirection(_direction); break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip: _rendRightLeft.SetDirection(_direction); break;
                case RendOrder.Size4: _rendLeft.SetDirection(_direction); break;
            }
        }
    }
}