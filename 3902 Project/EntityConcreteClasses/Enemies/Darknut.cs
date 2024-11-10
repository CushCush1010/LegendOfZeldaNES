using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Darknut : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spriteDownPosition = new (1, 90, 32, 16);
        private Vector2 _spriteDownRowAndColumns = new (1, 2);

        private Rectangle _spriteUpPosition = new (36, 90, 16, 16);
        private Vector2 _spriteUpRowAndColumns = new (1, 1);

        private Rectangle _spriteRightLeftPosition = new (52, 90, 32, 16);
        private Vector2 _spriteRightLeftRowAndColumns = new (1, 2);

        private RendererLists _rendererList;

        // variables for moving the enemy
        private Vector2 _position;
        private Vector2 _updatePosition;
        private int _moveCounter;
        private int _moveTotal = 100;
        private int _frameRate = 12;
        private float _positionSpeed = 2f;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.); takes the Enemy Spritesheet
        /// </summary>
        /// <param name="spriteSheet"></param>
        public Darknut(Texture2D spriteSheet, float printScale)
        {
            // create our renderer list
            Renderer[] rendererListArray = // positions in array correlate to above positions, usually: DOWN, UP, RIGHT, LEFT
            {
                new (spriteSheet, _spriteDownPosition, _spriteDownRowAndColumns, printScale, _frameRate),
                new (spriteSheet, _spriteUpPosition, _spriteUpRowAndColumns, printScale, _frameRate),
                new (spriteSheet, _spriteRightLeftPosition, _spriteRightLeftRowAndColumns, printScale, _frameRate)
            };
            rendererListArray[0].SetAnimationStatus(Renderer.STATUS.RowAndColumnAnimated);
            rendererListArray[1].SetAnimationStatus(Renderer.STATUS.SingleAnimated);
            rendererListArray[2].SetAnimationStatus(Renderer.STATUS.RowAndColumnAnimated);
            // create and assign what type of renderer list it is, and if it is centered
            _rendererList = new RendererLists(rendererListArray, RendererLists.RendOrder.Size3RightLeft);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _rendererList.GetVectorPosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            if (_moveCounter == 0) { _rendererList.CreateSetRandomDirection(); _updatePosition = _rendererList.CreateGetUpdatePosition(_positionSpeed); }
            _moveCounter++;
            if (_moveCounter == _moveTotal) { _moveCounter = 0; }

            // update position and animation
            _position += _updatePosition;
            _rendererList.SetPositions(_position);
            _rendererList.CreateUpdateFrames();
        }

        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, true); }
    }
}
