using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        // animation status
        public enum STATUS { Still, SingleAnimated, RowAndColumnAnimated, ReverseRowAndColumnAnimated, SeperatedAnimated };
        private STATUS _status;

        public enum DIRECTION { DOWN, UP, RIGHT, LEFT }
        private DIRECTION _direction;


        // NON-ANIMATED SPRITE


        // create variables
        private Texture2D _spriteSheet;
        private Vector2 _spritePosition;
        private Vector2 _spriteDimensions;
        private Vector2 _spritePrintDimensions;
        private Vector2 _positionOnWindow;


        /// <summary>
        /// constructor for getting information for rendering STILL sprites
        /// </summary>
        /// <param name="status"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="spritePosition"></param>
        /// <param name="spriteDimension"></param>
        /// <param name="spritePrintDimension"></param>
        public Renderer(Texture2D spriteSheet, Rectangle spritePositionAndDimension, float printScale)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;

            // set all positions
            _spritePosition = new (spritePositionAndDimension.X, spritePositionAndDimension.Y);
            _spriteDimensions = new(spritePositionAndDimension.Width, spritePositionAndDimension.Height);
            _spritePrintDimensions = new(spritePositionAndDimension.Width * printScale, spritePositionAndDimension.Height * printScale);
        }


        // ANIMATOR/FRAMERATE


        // item animation requirements
        private Vector2 _rowsAndColumns;
        private int _currentFrame;
        private int _previousFrame;
        private int _reversedFrame;
        private int _totalFrames;

        // frame rate to change speed of animations
        private int _frameRate;
        private int _framesPerSprite;
        private int _framesCounter;
        private int _frameTotalSpriteShift;

        // boolean for AnimatedReversed
        private bool _isReversed = false;


        /// <summary>
        /// constructor for getting information for rendering ANIMATED sprites
        /// </summary>
        /// <param name="spriteSheet"></param>
        /// <param name="rowAndColumn"></param>
        /// <param name="frameRate"></param>
        public Renderer(Texture2D spriteSheet, Rectangle spritePositionAndDimension, Vector2 rowAndColumn, float printScale, int frameRate)
        {
            // set animated state and import spritesheet
            _spriteSheet = spriteSheet;

            // call framerate manager
            _rowsAndColumns = rowAndColumn;
            _frameRate = frameRate;
            _currentFrame = 0;
            SetUpFrames();

            // sprite positioning
            _spritePosition = new(spritePositionAndDimension.X, spritePositionAndDimension.Y);
            _spriteDimensions = new(spritePositionAndDimension.Width, spritePositionAndDimension.Height);
            // needed since dimensions are in terms of the whole row/column
            _spritePrintDimensions = 
                new(
                    (spritePositionAndDimension.Width / _rowsAndColumns.Y) * printScale, 
                    (spritePositionAndDimension.Height / _rowsAndColumns.X) * printScale
                    );
        }


        /// <summary>
        /// sets up frame variables and their values for UpdateFrames()
        /// </summary>
        public void SetUpFrames()
        {
            // rows/columns stuff for sprite animation - if statement needed for Single Animation
            if ((int)_rowsAndColumns.X * (int)_rowsAndColumns.Y == 1) _totalFrames = 2;
            else _totalFrames = (int)_rowsAndColumns.X * (int)_rowsAndColumns.Y;
            // safety measure for if someone enters a value below the available frames: sets it too lowest value = _totalFrames
            if (_frameRate < _totalFrames) _frameRate = _totalFrames;


            // get the total amount of sprite shifts in animation
            _frameTotalSpriteShift = 0;
            while (_framesPerSprite < _frameRate)
            {
                _frameTotalSpriteShift++;
                _framesPerSprite += _frameRate / _totalFrames;
                if (_framesPerSprite > _frameRate)
                    _frameTotalSpriteShift--;
            }

            // if the framerate is not a clean division, fix it by shuffling down the value by the modulo
            if (_frameRate % _frameTotalSpriteShift != 0)
                _frameRate -= (_frameRate % _frameTotalSpriteShift);

            // reset frame rate variables
            _framesCounter = 0;
            _framesPerSprite = _frameRate / _totalFrames;
            _reversedFrame = (_frameTotalSpriteShift - 1);
        }


        /// <summary>
        /// count/reset frames and sprite levels (levels meaning at what stage of animation)
        /// </summary>
        public void UpdateFrames()
        {
            // if crea
            if (_status != STATUS.Still)
            {
                // logic for creating a framerate
                if (_framesCounter < _framesPerSprite)
                {
                    _framesCounter++;
                }
                else if (_framesCounter == _frameRate)
                {
                    _currentFrame = 0;
                    _reversedFrame = (_frameTotalSpriteShift - 1);
                    _framesCounter = 0;
                    _framesPerSprite = _frameRate / _totalFrames;
                }
                else
                {
                    if (_isReversed) { _previousFrame = _reversedFrame; _reversedFrame--; }
                    else if (!_isReversed) { _previousFrame = _currentFrame; _currentFrame++; }
                    _framesPerSprite += _frameRate / _totalFrames;
                }
            }
        }
    }
}