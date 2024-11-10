using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class Renderer
    {
        private Random _random = new Random();

        /// <summary>
        /// the updated position increasing in a RANDOM direction by given positionSpeed
        /// </summary>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>returns updated position that was randomly chosen</returns>
        public void SetRandomMovement()
        {
            int randomValue = _random.Next(4);
            SetDirection(randomValue);
        }

        /// <summary>
        /// the updated position increasing in direction by positionSpeed
        /// </summary>
        /// <param name="direction">the direction this is facing</param>
        /// <param name="positionSpeed">the rate at which the position updates</param>
        /// <returns>the updated position to be added to position</returns>
        public Vector2 GetUpdatePosition(float positionSpeed)
        {
            //Console.WriteLine("renderer helper methods: " + _direction.ToString());
            // movement variables
            switch (_direction)
            {
                case DIRECTION.DOWN:    return new Vector2(0, Math.Abs(positionSpeed));
                case DIRECTION.UP:      return new Vector2(0, -(Math.Abs(positionSpeed)));
                case DIRECTION.RIGHT:   return new Vector2(Math.Abs(positionSpeed), 0);
                case DIRECTION.LEFT:    return new Vector2(-(Math.Abs(positionSpeed)), 0);
                default: throw new ArgumentException("Invalid direction type for updatePosition");
            }
        }

        public Vector2 GetPositionAhead()
        {
            Rectangle dS = GetDestinationRectangle();
            switch (_direction)
            {
                case DIRECTION.DOWN:    return new Vector2((int)dS.X, (int)dS.Y + (int)dS.Height);
                case DIRECTION.UP:      return new Vector2((int)dS.X, (int)dS.Y - (int)dS.Height);
                case DIRECTION.RIGHT:   return new Vector2((int)dS.X + (int)dS.Width, (int)dS.Y);
                case DIRECTION.LEFT:    return new Vector2((int)dS.X - (int)dS.Width, (int)dS.Y);
                default: throw new ArgumentException("Invalid direction type in PositionAhead");
            }
        }
    }
}