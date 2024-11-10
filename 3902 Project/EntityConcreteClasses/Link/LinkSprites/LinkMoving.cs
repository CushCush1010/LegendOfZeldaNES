using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class LinkMoving : ISprite
    {
        // variables for link in frame 1 of the moving link sprite animation
        private Rectangle _spriteDownPosition = new(0, 11, 32, 16);
        private Rectangle _spriteUpPosition = new(69, 11, 32, 16);
        private Rectangle _spriteRightLeftPosition = new(34, 11, 32, 16);

        private Vector2 _spriteRowAndColumn = new(1, 2);
        private int _framerate = 12;


        // create a Renderer object
        private RendererLists _rendererList;
        private ProjectileManager _manager;

        /// <summary>
        /// Constructs the block (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public LinkMoving(Texture2D spriteSheet, Renderer.DIRECTION facingDirection, float printScale, ProjectileManager manager)
        {
            _manager = manager;
            // create different facing block sprites for the renderer list
            Renderer linkDown = new(spriteSheet, _spriteDownPosition, _spriteRowAndColumn, printScale, _framerate);
            Renderer linkUp = new(spriteSheet, _spriteUpPosition, _spriteRowAndColumn, printScale, _framerate);
            Renderer linkRightLeft = new(spriteSheet, _spriteRightLeftPosition, _spriteRowAndColumn, printScale, _framerate);
            Renderer[] rendererListSetArray = { linkDown, linkUp, linkRightLeft };
            // create renderer list
            _rendererList = new RendererLists(rendererListSetArray, RendererLists.RendOrder.Size3RightLeft);
            _rendererList.CreateSetAnimationStatus(Renderer.STATUS.RowAndColumnAnimated);
            // set correct direciton
            _rendererList.SetDirection(facingDirection);
        }

        /// <summary>
        /// Passes to the Renderer GetRectanglePosition method
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
        public void Update() {
            float positionSpeed = 4f;
            Vector2 updatePosition = _rendererList.CreateGetUpdatePosition(positionSpeed);
            //Console.WriteLine("renderer direction: " + _rendererList.GetDirection().ToString());
            //Console.WriteLine("updatePosition: " +  updatePosition);
            Vector2 currentPosition = _rendererList.GetVectorPosition() + updatePosition;
            _rendererList.SetPositions(currentPosition);
            _rendererList.CreateUpdateFrames(); 
        }


        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _rendererList.CreateSpriteDraw(spriteBatch, false); }
    }
}