using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SItem_HP2 : ISprite
    {
        // variables for constructor assignments
        private Vector2 _position;

        // variables to change based on where your item is and what to print out
        private Vector2 _spritePosition = new Vector2(0, 0);
        private Vector2 _spriteDimensions = new Vector2(8, 8);

        // create a Renderer object
        private Renderer _item;


        /// <summary>
        /// construct the sprite, pass in spritesheet and print dimension scale
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="printScale"></param>
        public SItem_HP2(Texture2D spriteSheet, float printScale)
        {
            _item = new Renderer(Renderer.STATUS.Still, spriteSheet, _spritePosition, _spriteDimensions, _spriteDimensions * printScale);
        }

        /// <summary>
        /// Get position from sprites renderer position
        /// </summary>
        /// <returns>the position of the </returns>
        public Rectangle GetRectanglePosition() { return _item.GetRectanglePosition(); }

        /// <summary>
        /// Set position in the this method and in the sprites renderer
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position) { _position = position; _item.SetPosition(position); }

        /// <summary>
        /// update the sprite via Renderer method(s)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// draw the sprite via Renderer method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _item.DrawCentered(spriteBatch, _item.GetSourceRectangle()); }
    }
}