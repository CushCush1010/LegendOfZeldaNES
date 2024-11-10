using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class LinkActionStanding : ISprite
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteDownPosition = new(107, 11, 16, 16);
        private Rectangle _spriteUpPosition = new(141, 11, 16, 16);
        private Rectangle _spriteRightLeftPosition = new(123, 11, 16, 16);

        // create a Renderer object
        private RendererLists _rendererList;

        private int _currentFrame;


        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkActionStanding(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale)
        {
            // create different facing block sprites for the renderer list
            Renderer linkDown = new(spriteSheet, _spriteDownPosition, printScale);
            Renderer linkUp = new(spriteSheet, _spriteUpPosition, printScale);
            Renderer linkRightLeft = new(spriteSheet, _spriteRightLeftPosition, printScale);
            Renderer[] rendererListSetArray = { linkDown, linkUp, linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
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
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, true); }
    }
}