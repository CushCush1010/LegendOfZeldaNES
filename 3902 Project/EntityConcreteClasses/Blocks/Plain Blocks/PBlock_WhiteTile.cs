﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class PBlock_WhiteTile : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spritePosition = new (1001, 45, 16, 16);

        // create a Renderer object
        private Renderer _block;
        private bool _isCentered = false;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet and Direction
        /// </summary>
        public PBlock_WhiteTile(Texture2D spriteSheet, float printScale)
        {
            // create different facing block sprites for the renderer list
            _block = new(spriteSheet, _spritePosition, printScale);
            _block.SetAnimationStatus(Renderer.STATUS.Still);
            _block.SetCentered(_isCentered);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _block.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _block.GetVectorPosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _block.SetPosition(position); }


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