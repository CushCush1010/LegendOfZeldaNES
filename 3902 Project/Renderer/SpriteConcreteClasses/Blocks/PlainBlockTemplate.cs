﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class PlainBlockTemplate : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(0, 0);
        private Vector2 _spriteDimensions = new Vector2(32, 32);
        private Vector2 _spritePrintDimensions = new Vector2(128, 128);

        // create a Renderer object
        private Renderer _block;


        // constructor for block
        public PlainBlockTemplate(Texture2D spriteSheet, Vector2 spawnPosition)
        {
            _spriteSheet = spriteSheet;
            _position = spawnPosition;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions);
        }

        // general get position method from IPosition
        public Vector2 GetPosition()
        {
            return _position;
        }

        // general set position method from IPosition
        public void SetPosition(Vector2 position)
        {
            _position = position;
        }


        // update the movement for block, used later
        public void Update()
        {
        }


        // draw the block
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR = _block.GetSourceRectangle();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _block.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}