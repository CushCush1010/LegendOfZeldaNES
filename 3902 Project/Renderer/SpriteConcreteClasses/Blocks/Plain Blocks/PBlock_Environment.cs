﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class PBlock_Environment : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(521, 11);
        private Vector2 _spriteDimensions = new Vector2(256, 176);
        private Vector2 _spritePrintDimensions = new Vector2(1024, 700);

        // create a Renderer object
        private Renderer _block;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public PBlock_Environment(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _spritePosition, _spriteDimensions, _spritePrintDimensions);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetPosition()
        {
            return _block.GetPosition();
        }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            _position = position;
            _block.SetPosition(position);
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            _block.Draw(spriteBatch, _block.GetSourceRectangle(), _block.GetDestinationRectangle());
        }
    }
}