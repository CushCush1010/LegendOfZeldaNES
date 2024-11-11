using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_SmallExplosion : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteExplode = new (53, 189, 8, 8);

        // create Renderer objects
        private Renderer _explode;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_SmallExplosion(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the small explosion projectile
            _explode = new (spriteSheet, _spriteExplode, printScale);
            _explode.SetDirection(facingDirection);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _explode.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _explode.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _explode.SetPosition(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _explode.Draw(spriteBatch, true); }
    }
}