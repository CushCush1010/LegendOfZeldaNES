using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        public void SetAnimationStatus(STATUS status) { _status = status; }

        /// <summary>
        /// draws a sourceRectangle in an int array based on what status of animation was selected
        /// </summary>
        /// <returns>the sourceRectangle in an int[] array</returns>
        public int[] GetSourceRectangleArray()
        {
            int[] sourceRectangle = new int[4];

            // logic for seperating sprites into columns/rows to animate
            sourceRectangle[0] = GetSourceRectangle().X;
            sourceRectangle[1] = GetSourceRectangle().Y;
            sourceRectangle[2] = GetSourceRectangle().Width;
            sourceRectangle[3] = GetSourceRectangle().Height;

            return sourceRectangle;
        }


        /// <summary>
        /// draws a sourceRectangle in a Rectangle() based on what status of animation was selected
        /// </summary>
        /// <returns>return the sourceRectangle in a rectangle</returns>
        public Rectangle GetSourceRectangle()
        {
            switch(_status)
            {
                case STATUS.Still: return GetSourceRectangle_Still();
                case STATUS.SingleAnimated: return GetSourceRectangle_SingleAnimated();
                case STATUS.RowAndColumnAnimated: return GetSourceRectangle_RowAndColumnAnimated();
                case STATUS.ReverseRowAndColumnAnimated: return GetSourceRectangle_ReversedRowAndColumnAnimated();
                default: throw new ArgumentException("Invalid STATUS for GetSourceRectangle() in Renderer");
            }
        }

        private Rectangle GetSourceRectangle_Still()
        {
            return new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
        }

        private Rectangle GetSourceRectangle_SingleAnimated()
        {
            if (_currentFrame == 0) return new Rectangle((int)_spritePosition.X, (int)_spritePosition.Y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
            else return new Rectangle((int)_spritePosition.X + (int)_spriteDimensions.X, (int)_spritePosition.Y, -(int)_spriteDimensions.X, (int)_spriteDimensions.Y);
        }

        private Rectangle GetSourceRectangle_RowAndColumnAnimated()
        {
            int width, height, row, column;
            width = (int)_spriteDimensions.X / (int)_rowsAndColumns.Y;      // sprites x dimension / column
            height = (int)_spriteDimensions.Y / (int)_rowsAndColumns.X;     // sprites y dimension / row
            row = _currentFrame / (int)_rowsAndColumns.Y;                   // current frame / column
            column = _currentFrame % (int)_rowsAndColumns.Y;                // current frame % column
            return new Rectangle((width * column) + (int)_spritePosition.X, (height * row) + (int)_spritePosition.Y, width, height);
        }

        private Rectangle GetSourceRectangle_ReversedRowAndColumnAnimated()
        {
            int width, height, row, column;
            if (_previousFrame == (_frameTotalSpriteShift - 1) && _currentFrame == 0)           _isReversed = true;
            else if (_previousFrame == 0 && _reversedFrame == (_frameTotalSpriteShift - 1))     _isReversed = false;

            width = (int)_spriteDimensions.X / (int)_rowsAndColumns.Y;      // sprites x dimension / column
            height = (int)_spriteDimensions.Y / (int)_rowsAndColumns.X;     // sprites y dimension / row

            if (!_isReversed)
            {
                row = _currentFrame / (int)_rowsAndColumns.Y;                   // current frame / column
                column = _currentFrame % (int)_rowsAndColumns.Y;                // current frame % column
            }
            else
            {
                row = _reversedFrame / (int)_rowsAndColumns.Y;                   // current frame / column
                column = _reversedFrame % (int)_rowsAndColumns.Y;                // current frame % column
            }
            // then get the sourceRectangle based on the choice
            return new Rectangle((width * column) + (int)_spritePosition.X, (height * row) + (int)_spritePosition.Y, width, height);
        }

        /// <summary>
        /// get the destinationRectangle of your current sprite
        /// </summary>
        public Rectangle GetDestinationRectangle() { return new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y); }

        /// <summary>
        /// gets current position of sprite in a Rectangle of position and dimensions on screen
        /// </summary>
        public Rectangle GetRectanglePosition() { return new Rectangle((int)_positionOnWindow.X, (int)_positionOnWindow.Y, (int)_spritePrintDimensions.X, (int)_spritePrintDimensions.Y); }

        /// <summary>
        /// gets current position of sprite in a Vector2 of position on screen
        /// </summary>
        public Vector2 GetVectorPosition() { return new Vector2((int)_positionOnWindow.X, (int)_positionOnWindow.Y); }

        /// <summary>
        /// sets current position of sprite
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _positionOnWindow = position; }

        /// <summary>
        /// set the direction of the current "this" sprite
        /// </summary>
        /// <param name="direction">the direction in which you want to move</param>
        public void SetDirection(DIRECTION direction) { _direction = direction; }

        /// <summary>
        /// set the direction of the current "this" sprite
        /// </summary>
        /// <param name="direction">the direction in which you want to move</param>
        public void SetDirection(int direction) { _direction = (DIRECTION)direction; }

        public DIRECTION GetDirection() { return _direction; }
    }
}