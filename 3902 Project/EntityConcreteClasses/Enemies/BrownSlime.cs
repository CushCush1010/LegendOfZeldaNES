using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class BrownSlime : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spritePosition = new (78, 28, 32, 16);
        private Vector2 _rowAndColumns = new (1, 2);
        private int frames = 12;
        private float _printScale;

        // variables for moving the enemy
        private Vector2 _position;
        private Vector2 _updatePosition;
        private Renderer.DIRECTION _direction;
        private int _moveCounter = 0;
        private int _moveTotal = 30;
        private float _positionSpeed = 2F;

        // variables for shooting projectile
        private ISprite _projectileFireBall;
        private ProjectileManager _projectileManager;

        // create enemy renderer
        private Renderer _enemy;


        /// <summary>
        /// Constructs the enemy (set values, create Rendering, etc.)
        /// </summary>
        /// <param name="spriteSheet"></param>
        public BrownSlime(Texture2D spriteSheet, float printScale, ProjectileManager manager)
        {
            _printScale = printScale;
            _projectileManager = manager;
            _enemy = new(spriteSheet, _spritePosition, _rowAndColumns, printScale, frames);
            _enemy.SetAnimationStatus(Renderer.STATUS.RowAndColumnAnimated);
        }


        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Rectangle GetRectanglePosition() { return _enemy.GetRectanglePosition(); }

        /// <summary>
        /// Passes to the Renderer GetPosition method
        /// </summary>
        public Vector2 GetVectorPosition() { return _enemy.GetVectorPosition(); }


        /// <summary>
        /// Passes to the Renderer SetPosition method
        /// </summary>
        public void SetPosition(Vector2 position) { _position = position; _enemy.SetPosition(position); }


        /// <summary>
        /// Updates the enemy (movement, animation, etc.)
        /// </summary>
        public void Update()
        {
            if (_moveCounter == 0) { _enemy.SetRandomMovement(); _direction = _enemy.GetDirection(); _updatePosition = _enemy.GetUpdatePosition(_positionSpeed); }
            if (_moveCounter == 15) { _projectileManager.CallProjectile(ProjectileManager.ProjectileNames.FireBall, _enemy.GetPositionAhead(), _printScale); }
            _moveCounter++;
            if (_moveCounter == _moveTotal) { _moveCounter = 0; }

            // update position and animation
            _position += _updatePosition;
            _enemy.SetPosition(_position);
            _enemy.UpdateFrames();
        }


        /// <summary>
        /// Draws the enemy in the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { _enemy.Draw(spriteBatch, false); }
    }
}