using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class PSprite_BlueArrow : ISprite
    {
        // variables to change based on where your sprite is and what to print out
        private Rectangle _spriteUpDownArrow = new (29, 185, 5, 16);
        private Rectangle _spriteRightLeftArrow = new (36, 190, 16, 5);

        private RendererLists _rendererList;

        // create timers, movement and speed variables
        private Vector2 _position;
        private Vector2 _updatePosition;
        private float _positionSpeed = 2f;

        /// <summary>
        /// constructor for the projectile sprite: <c>Bomb</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="facingDirection">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PSprite_BlueArrow(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create renders of the blue arrow projectile
            Renderer upDownArrow = new (spriteSheet, _spriteUpDownArrow, printScale);
            Renderer rightLeftArrow = new (spriteSheet, _spriteRightLeftArrow, printScale);
            Renderer[] _rendererListArray = { upDownArrow, rightLeftArrow };
            _rendererList = new RendererLists(_rendererListArray, RendererLists.RendOrder.Size2DownUpFlip);
            _rendererList.CreateSetAnimationStatus(Renderer.STATUS.Still);
            _rendererList.SetDirection(facingDirection);
            // only need to update position once
            _updatePosition = _rendererList.CreateGetUpdatePosition(_positionSpeed);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _rendererList.GetOneRectanglePosition(); }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _rendererList.GetVectorPosition(); }

        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            // set positions at every update
            _rendererList.SetPositions(_position);

            // update position and movement counter
            _position += _updatePosition;
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, true); }
    }
}