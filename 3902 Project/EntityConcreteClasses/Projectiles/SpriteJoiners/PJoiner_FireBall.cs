using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Threading;

namespace _3902_Project
{
    public class PJoiner_FireBall : ISprite
    {
        PSprite_FireBall _fireBall;

        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed = 2f;

        /// <summary>
        /// constructor for the projectile sprite: <c>FireBall</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_FireBall(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the blue arrow projectile
            _fireBall = new PSprite_FireBall(spriteSheet, facingDirection, printScale);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _fireBall.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _fireBall.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _fireBall.SetPosition(position); }


        /// <summary>
        /// Updates the sprite (movement, animation, etc.)
        /// </summary>
        public void Update()
        { _fireBall.Update(); }


        /// <summary>
        /// Draws the sprite in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _fireBall.Draw(spriteBatch); }
    }
}