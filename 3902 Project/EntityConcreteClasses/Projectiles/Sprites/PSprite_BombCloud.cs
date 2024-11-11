using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_BombCloud : ISprite
    {
        // variables to change based on where your projectile is and what to print out
        private Rectangle _spriteBombCloud = new (138, 185, 48, 16);
        private Vector2 _spriteRowAndColumn = new Vector2(1, 3);

        private int _bombCloudFrames = 30;
        private Renderer _bombCloud;


        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_BombCloud(Texture2D spriteSheet, float printScale)
        {
            _bombCloud = new (spriteSheet, _spriteBombCloud, _spriteRowAndColumn, printScale, _bombCloudFrames);
            _bombCloud.SetAnimationStatus(Renderer.STATUS.RowAndColumnAnimated);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _bombCloud.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _bombCloud.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _bombCloud.SetPosition(position); }


        /// <summary>
        /// Updates the projectile (movement, animation, etc.)
        /// </summary>
        public void Update() { _bombCloud.UpdateFrames(); }


        /// <summary>
        /// Draws the projectile in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"
        public void Draw(SpriteBatch spriteBatch) { _bombCloud.Draw(spriteBatch, true); }
    }
}