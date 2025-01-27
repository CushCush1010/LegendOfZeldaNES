﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SBlock_Teleport : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spritePosition = new (1000, 1000, 16, 16);

        // create a Renderer object
        private Renderer _block;
        private bool _isCentered = false;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public SBlock_Teleport(Texture2D spriteSheet, float printScale)
        {
            // create different facing block sprites for the renderer list
            _block = new(spriteSheet, _spritePosition, printScale);
            _block.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _block.DestinationRectangle; }
            set { _block.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _block.PositionOnWindow; }
            set { _block.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _block.Draw(spriteBatch); }
    }
}