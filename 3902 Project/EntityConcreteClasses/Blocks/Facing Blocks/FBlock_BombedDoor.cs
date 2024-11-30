﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_BombedDoor : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spriteDownPosition = new (914, 11, 32, 32);
        private Rectangle _spriteUpPosition = new (914, 110, 32, 32);
        private Rectangle _spriteRightPosition = new (914, 44, 32, 32);
        private Rectangle _spriteLeftPosition = new (914, 77, 32, 32);

        // create a Renderer object
        private RendererLists _rendererList;
        private bool _isCentered = false;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FBlock_BombedDoor(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer blockDown = new(spriteSheet, _spriteDownPosition, printScale);
            Renderer blockUp = new(spriteSheet, _spriteUpPosition, printScale);
            Renderer blockRight = new(spriteSheet, _spriteRightPosition, printScale);
            Renderer blockLeft = new(spriteSheet, _spriteLeftPosition, printScale);
            Renderer[] rendererListSetArray = { blockDown, blockUp, blockRight, blockLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size4);
            _rendererList.IsCentered = _isCentered;
            // set correct direciton
            _rendererList.Direction = facingDirection;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _rendererList.DestinationRectangle; }
            set { _rendererList.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _rendererList.PositionOnWindow; }
            set { _rendererList.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.Draw(spriteBatch); }
    }
}