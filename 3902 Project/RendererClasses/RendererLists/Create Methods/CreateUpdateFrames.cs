using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <summary>
        /// calls the specific type of rendereList and then updates its sprites/renderers
        /// </summary>
        public void CreateUpdateFrames()
        {
            switch(_rendListType)
            {
                case RendOrder.Size2:
                    CreateUpdateFramesSize2(); break;
                case RendOrder.Size2DownUpFlip:
                    CreateUpdateFramesSize2(); break;
                case RendOrder.Size2RightLeftFlip:
                    CreateUpdateFramesSize2(); break;
                case RendOrder.Size2Flip:
                    CreateUpdateFramesSize2(); break;
                case RendOrder.Size3DownUp:
                    CreateUpdateFramesSize3DownUp(); break;
                case RendOrder.Size3DownUpFlip:
                    CreateUpdateFramesSize3DownUp(); break;
                case RendOrder.Size3RightLeft:
                    CreateUpdateFramesSize3RightLeft(); break;
                case RendOrder.Size3RightLeftFlip:
                    CreateUpdateFramesSize3RightLeft(); break;
                case RendOrder.Size4:
                    CreateUpdateFramesSize4(); break;
                default: throw new ArgumentException("Invalid direction for CreateProjectile");
            }
        }

        private void CreateUpdateFramesSize2()
        {
            if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                _rendDownUp.UpdateFrames();
            else
                _rendRightLeft.UpdateFrames();
        }

        private void CreateUpdateFramesSize3DownUp()
        {
            if (_direction == Renderer.DIRECTION.RIGHT)
                _rendRight.UpdateFrames();
            else if (_direction == Renderer.DIRECTION.LEFT)
                _rendLeft.UpdateFrames();
            else
                _rendDownUp.UpdateFrames();
        }

        private void CreateUpdateFramesSize3RightLeft()
        {
            if (_direction == Renderer.DIRECTION.DOWN)
                _rendDown.UpdateFrames();
            else if (_direction == Renderer.DIRECTION.UP)
                _rendUp.UpdateFrames();
            else
                _rendRightLeft.UpdateFrames();
        }

        private void CreateUpdateFramesSize4()
        {
            if (_direction == Renderer.DIRECTION.DOWN)
                _rendDown.UpdateFrames();
            else if (_direction == Renderer.DIRECTION.UP)
                _rendUp.UpdateFrames();
            else if (_direction == Renderer.DIRECTION.RIGHT)
                _rendRight.UpdateFrames();
            else
                _rendLeft.UpdateFrames();
        }
    }
}