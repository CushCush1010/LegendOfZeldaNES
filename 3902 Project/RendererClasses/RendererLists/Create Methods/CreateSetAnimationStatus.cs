using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class RendererLists
    {
        public void CreateSetAnimationStatus(Renderer.STATUS status)
        {
            // set the directions
            switch (_rendListType)
            {
                case RendOrder.Size2:
                case RendOrder.Size2DownUpFlip:
                case RendOrder.Size2RightLeftFlip:
                case RendOrder.Size2Flip: 
                    _rendDownUp.SetAnimationStatus(status);
                    _rendRightLeft.SetAnimationStatus(status);
                    break;
                case RendOrder.Size3DownUp:
                case RendOrder.Size3DownUpFlip: 
                    _rendDownUp.SetAnimationStatus(status);
                    _rendRight.SetAnimationStatus(status);
                    _rendLeft.SetAnimationStatus(status);
                    break;
                case RendOrder.Size3RightLeft:
                case RendOrder.Size3RightLeftFlip:
                    _rendDown.SetAnimationStatus(status);
                    _rendUp.SetAnimationStatus(status);
                    _rendRightLeft.SetAnimationStatus(status);
                    break;
                case RendOrder.Size4: 
                    _rendDown.SetAnimationStatus(status);
                    _rendUp.SetAnimationStatus(status);
                    _rendRight.SetAnimationStatus(status);
                    _rendLeft.SetAnimationStatus(status);
                    break;
                default: throw new ArgumentException("Invalid rendOrder type for CreateGetUpdatePosition");
            }
        }
    }
}