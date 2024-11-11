using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PJoiner_Bomb : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private PSprite_Bomb _bomb;
        private PSprite_Fire _bombFire;
        private PSprite_BombCloud _bombCloud;

        public enum STATUS { Bomb, BombFire, BombCloud }

        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_Bomb(Texture2D spriteSheet, float printScale)
        {
            _bomb = new (spriteSheet, printScale);
            _bombFire = new(spriteSheet, printScale);
            _bombCloud = new(spriteSheet, printScale);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition()  {  return new Rectangle(0, 0, 0, 0);  }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return new Vector2(0, 0); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { /*_rendererList.SetPositions(position);*/ }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            //_rendererList.SetPositions(_position);
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { //_rendererList.CreateSpriteDraw(spriteBatch, true);
                                                    }
    }
}