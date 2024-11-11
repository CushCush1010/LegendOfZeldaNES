using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Color _tint;

        /// <summary>
        /// Draws the specific current sprite based on other methods
        /// </summary>
        /// <param name="spriteBatch">the spritebatch where we draw all sprites</param>
        public void CreateSpriteDraw(SpriteBatch spriteBatch, bool isCentered, Color tint)
        {
            _isCentered = isCentered;
            _tint = tint;
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    CreateSpriteDrawTintSize2(spriteBatch); break;
                case RendOrder.Size2DownUpFlip:
                    CreateSpriteDrawTintSize2DownUpFlip(spriteBatch); break;
                case RendOrder.Size2RightLeftFlip:
                    CreateSpriteDrawTintSize2RightLeftFlip(spriteBatch); break;
                case RendOrder.Size2Flip:
                    CreateSpriteDrawTintSize2Flip(spriteBatch); break;
                case RendOrder.Size3DownUp:
                    CreateSpriteDrawTintSize3DownUp(spriteBatch); break;
                case RendOrder.Size3DownUpFlip:
                    CreateSpriteDrawTintSize3DownUpFlip(spriteBatch); break;
                case RendOrder.Size3RightLeft:
                    CreateSpriteDrawTintSize3RightLeft(spriteBatch); break;
                case RendOrder.Size3RightLeftFlip:
                    CreateSpriteDrawTintSize3RightLeftFlip(spriteBatch); break;
                case RendOrder.Size4:
                    CreateSpriteDrawTintSize4(spriteBatch); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize2(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize2DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize2RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize2Flip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize3DownUp(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize3DownUpFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDownUp.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Vertical, _tint); break;
                case Renderer.DIRECTION.UP: _rendDownUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }


        private void CreateSpriteDrawTintSize3RightLeft(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }

        private void CreateSpriteDrawTintSize3RightLeftFlip(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRightLeft.Draw(spriteBatch, _isCentered, Renderer.DrawFlips.Horizontal, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendRightLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }


        private void CreateSpriteDrawTintSize4(SpriteBatch spriteBatch)
        {
            switch (_direction)
            {
                case Renderer.DIRECTION.DOWN: _rendDown.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.UP: _rendUp.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.RIGHT: _rendRight.Draw(spriteBatch, _isCentered, _tint); break;
                case Renderer.DIRECTION.LEFT: _rendLeft.Draw(spriteBatch, _isCentered, _tint); break;
                default: throw new ArgumentException("Invalid drawing direction for CreateSpriteDrawTint");
            }
        }
    }
}