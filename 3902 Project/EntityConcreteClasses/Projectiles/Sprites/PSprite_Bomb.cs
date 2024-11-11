using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_Bomb : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteBomb = new (129, 185, 8, 14);

        // create Renderer objects
        private Renderer _bomb;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_Bomb(Texture2D spriteSheet, float printScale)
        {
            // create renders of the bomb projectile
            _bomb = new (spriteSheet, _spriteBomb, printScale);
            _bomb.SetAnimationStatus(Renderer.STATUS.Still);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _bomb.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _bomb.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _bomb.SetPosition(position); }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _bomb.Draw(spriteBatch, true); }
    }
}