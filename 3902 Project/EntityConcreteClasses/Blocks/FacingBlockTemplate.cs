using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class FacingBlockTemplate : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spriteDownPosition = new(0, 0, 0, 0);
        private Rectangle _spriteUpPosition = new(0, 0, 0, 0);
        private Rectangle _spriteRightPosition = new(0, 0, 0, 0);
        private Rectangle _spriteLeftPosition = new(0, 0, 0, 0);

        // create a Renderer object
        private RendererLists _rendererList;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public FacingBlockTemplate(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer blockDown = new(spriteSheet, _spriteDownPosition, printScale);
            Renderer blockUp = new(spriteSheet, _spriteUpPosition, printScale);
            Renderer blockRight = new(spriteSheet, _spriteRightPosition, printScale);
            Renderer blockLeft = new(spriteSheet, _spriteLeftPosition, printScale);
            Renderer[] rendererListSetArray = { blockDown, blockUp, blockRight, blockLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size4);
            _rendererList.CreateSetAnimationStatus(Renderer.STATUS.Still);
            // set correct direciton
            _rendererList.SetDirection(facingDirection);
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
        public void SetPosition(Vector2 position) { _rendererList.SetPositions(position); }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, false); }
    }
}