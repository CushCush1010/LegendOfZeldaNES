using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        /// <summary>
        /// sets the renderers, so they can be used in the METHODS
        /// </summary>
        public void SetRenderers()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    _rendDownUp = _rendererList[0];
                    _rendRightLeft = _rendererList[1];
                    break;
                case RendOrder.Size3DownUp:
                    _rendDownUp = _rendererList[0];
                    _rendRight = _rendererList[1];
                    _rendLeft = _rendererList[2];
                    break;
                case RendOrder.Size3RightLeft:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRightLeft = _rendererList[2];
                    break;
                case RendOrder.Size4:
                    _rendDown = _rendererList[0];
                    _rendUp = _rendererList[1];
                    _rendRight = _rendererList[2];
                    _rendLeft = _rendererList[3];
                    break;
            }
        }

        /// <returns>the list of renderers</returns>
        public Renderer[] GetList() { return _rendererList; }

        /// <summary>
        /// used in int[] directionArray formula, and also in other areas to set the direction
        /// </summary>
        /// <param name="directionValue">the value that represents the correct DIRECTION enum</param>
        public void SetDirection(Renderer.DIRECTION directionValue) { 
            _direction = directionValue;
            switch(_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2Flip:
                case RendOrder.Size2RightLeftFlip:
                    _rendDownUp.SetDirection(directionValue);
                    _rendRightLeft.SetDirection(directionValue);
                break;

                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip:
                    _rendDown.SetDirection(directionValue);
                    _rendUp.SetDirection(directionValue);
                    _rendRightLeft.SetDirection(directionValue);
                break;


                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _rendRightLeft.SetDirection(directionValue);
                    _rendDown.SetDirection(directionValue);
                    _rendUp.SetDirection(directionValue);
                break;

                case RendOrder.Size4:
                    _rendRight.SetDirection(directionValue);
                    _rendLeft.SetDirection(directionValue);
                    _rendUp.SetDirection(directionValue);
                    _rendDown.SetDirection(directionValue);

                    break;

            }
        
        }

        /// <summary>
        /// used in int[] directionArray formula, and also in other areas to set the direction
        /// </summary>
        /// <param name="directionValue">the value, in int, that represents the correct DIRECTION enum: 0: DOWN, 1: UP, 2: RIGHT, 3: LEFT</param>
        public void SetDirection(int directionValue) { _direction = (Renderer.DIRECTION)directionValue; }

        public Renderer.DIRECTION GetDirection() {  return _direction; }

        /// <returns>the rectangle position of the current sprite needed</returns>
        public Rectangle GetOneRectanglePosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                        return _rendDownUp.GetRectanglePosition();
                    else 
                        return _rendRightLeft.GetRectanglePosition();
                case RendOrder.Size3DownUp:
                    if (_direction == Renderer.DIRECTION.RIGHT) { return _rendRight.GetRectanglePosition(); }
                    else if (_direction == Renderer.DIRECTION.LEFT) { return _rendLeft.GetRectanglePosition(); }
                    else { return _rendDownUp.GetRectanglePosition(); }
                case RendOrder.Size3RightLeft:
                    if (_direction == Renderer.DIRECTION.DOWN) { return _rendDown.GetRectanglePosition(); }
                    else if (_direction == Renderer.DIRECTION.UP) { return _rendUp.GetRectanglePosition(); }
                    else { return _rendRightLeft.GetRectanglePosition(); }
                case RendOrder.Size4:
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN: return _rendDown.GetRectanglePosition(); 
                        case Renderer.DIRECTION.UP: return _rendUp.GetRectanglePosition();
                        case Renderer.DIRECTION.RIGHT: return _rendRight.GetRectanglePosition();
                        case Renderer.DIRECTION.LEFT: return _rendLeft.GetRectanglePosition();
                        default: throw new ArgumentException("Invalid current direction for RednererList");
                    }
                default: throw new ArgumentException("Invalid current direction for RednererList");
            }
        }

        /// <returns>the vector2 position of the current sprite needed</returns>
        public Vector2 GetVectorPosition()
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    if (_direction == Renderer.DIRECTION.DOWN || _direction == Renderer.DIRECTION.UP)
                        return _rendDownUp.GetVectorPosition();
                    else
                        return _rendRightLeft.GetVectorPosition();
                case RendOrder.Size3DownUp:
                    if (_direction == Renderer.DIRECTION.RIGHT) { return _rendRight.GetVectorPosition(); }
                    else if (_direction == Renderer.DIRECTION.LEFT) { return _rendLeft.GetVectorPosition(); }
                    else { return _rendDownUp.GetVectorPosition(); }
                case RendOrder.Size3RightLeft:
                    if (_direction == Renderer.DIRECTION.DOWN) { return _rendDown.GetVectorPosition(); }
                    else if (_direction == Renderer.DIRECTION.UP) { return _rendUp.GetVectorPosition(); }
                    else { return _rendRightLeft.GetVectorPosition(); }
                case RendOrder.Size4:
                    switch (_direction)
                    {
                        case Renderer.DIRECTION.DOWN: return _rendDown.GetVectorPosition();
                        case Renderer.DIRECTION.UP: return _rendUp.GetVectorPosition();
                        case Renderer.DIRECTION.RIGHT: return _rendRight.GetVectorPosition();
                        case Renderer.DIRECTION.LEFT: return _rendLeft.GetVectorPosition();
                        default: throw new ArgumentException("Invalid current direction for RednererList");
                    }
                default: throw new ArgumentException("Invalid current direction for RednererList");
            }
        }

        /// <summary>
        /// sets the positions of all the renderers in the list
        /// </summary>
        /// <param name="position">the position on screen</param>
        public void SetPositions(Vector2 position)
        {
            switch (_rendListType)
            {
                case RendOrder.Size2:
                    _rendDownUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case RendOrder.Size3DownUp:
                    _rendDownUp.SetPosition(position);
                    _rendRight.SetPosition(position);
                    _rendLeft.SetPosition(position);
                    break;
                case RendOrder.Size3RightLeft:
                    _rendDown.SetPosition(position);
                    _rendUp.SetPosition(position);
                    _rendRightLeft.SetPosition(position);
                    break;
                case RendOrder.Size4:
                    _rendDown.SetPosition(position);
                    _rendUp.SetPosition(position);
                    _rendRight.SetPosition(position);
                    _rendLeft.SetPosition(position);
                    break;
                default: break;
            }
        }
    }
}