using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SItem_WaterPlate : ISprite
    {
        // variables to change based on where your item is and what to print out
        private Rectangle _spritePosition = new (192, 0, 16, 16);

        // create a Renderer object
        private Renderer _item;


        /// <summary>
        /// construct the sprite, pass in spritesheet and print dimension scale
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="printScale"></param>
        public SItem_WaterPlate(Texture2D spriteSheet, float printScale)
        {
            _item = new(spriteSheet, _spritePosition, printScale);
            _item.SetAnimationStatus(Renderer.STATUS.Still);
        }

        /// <summary>
        /// Get position from sprites renderer position
        /// </summary>
        /// <returns>the position of the sprite in Rectangle</returns>
        public Rectangle GetRectanglePosition() { return _item.GetRectanglePosition(); }

        /// <summary>
        /// Get position from sprites renderer position
        /// </summary>
        /// <returns>the position of the sprite in Rectangle</returns>
        public Vector2 GetVectorPosition() { return _item.GetVectorPosition(); }

        /// <summary>
        /// Set position in the this method and in the sprites renderer
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _item.SetPosition(position); }


        /// <summary>
        /// update the sprite via Renderer method
        /// </summary>
        public void Update() { _item.UpdateFrames(); }


        /// <summary>
        /// draw the sprite via Renderer method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _item.Draw(spriteBatch, true); }
    }
}