﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class PJoiner_FireBall : IPJoiner
    {
        // variables to change based on where your sprite is and what to print out
        private ISprite _fireBall;
        private bool _removable;
        private ISprite _currentSprite;
        private Vector2 _position;

        private ICollisionBox _collisionBox;
        private int _counter;
        private int _counterTotal = 300;

        /// <summary>
        /// constructor for the projectile sprite: <c>Blue Arrow</c>
        /// </summary>
        /// <param name="spriteSheet">texture sheet where sprites are formed from</param>
        /// <param name="direction">
        /// direction the sprite spawn in. EXAMPLE: if facingDirection = DOWN, then the sprite will spawned in facing and moving downwards.
        /// </param>
        /// <param name="printScale">the print scale of the projectile: printScale * spriteDimensions</param>
        public PJoiner_FireBall(Texture2D spriteSheet, Renderer.DIRECTION direction, float printScale)
        {
            _fireBall = new PSprite_FireBall(spriteSheet, direction, printScale);
            _counter = 0;
            _currentSprite = _fireBall;
            RemovableFlip = false;
        }

        public ICollisionBox CollisionBox
        {
            get { return _collisionBox; }
            set { _collisionBox = value; }
        }

        public ISprite CurrentSprite
        {
            get { return _currentSprite; }
            set { _currentSprite = _fireBall; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public bool RemovableFlip
        {
            get { return _removable; }
            set { _removable = value; }
        }

        public void Update()
        {
            _counter++;
            if (_counter >= _counterTotal)
                RemovableFlip = true;
            else if (_collisionBox.Health != 1)
                RemovableFlip = true;
            else
                CurrentSprite = _fireBall;

            CurrentSprite.Update();
            Position = CurrentSprite.GetVectorPosition();
        }
    }
}