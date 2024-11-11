using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

namespace _3902_Project
{
    public class PJoiner_BlueArrow : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private PSprite_BlueArrow _blueArrow;
        private PSprite_SmallExplosion _smallExplosion;

        public enum STATUS { BlueArrow, SmallExplosion }
        private STATUS _status;

        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_BlueArrow(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            _blueArrow = new (spriteSheet, facingDirection, printScale);
            _smallExplosion = new(spriteSheet, facingDirection, printScale);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition()  
        { 
            if (_status == STATUS.BlueArrow) return _blueArrow.GetRectanglePosition();
            else return _smallExplosion.GetRectanglePosition();
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition()
        {
            if (_status == STATUS.BlueArrow) return _blueArrow.GetVectorPosition();
            else return _smallExplosion.GetVectorPosition();
        }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position)
        {
            if (_status == STATUS.BlueArrow) _blueArrow.SetPosition(position);
            else _smallExplosion.SetPosition(position);
        }

        public void SetStatus(STATUS status) { _status = status; }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            if (_status == STATUS.BlueArrow) _blueArrow.Update();
            else _smallExplosion.Update();
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_status == STATUS.BlueArrow) _blueArrow.Draw(spriteBatch);
            else _smallExplosion.Draw(spriteBatch);
        }
    }
}