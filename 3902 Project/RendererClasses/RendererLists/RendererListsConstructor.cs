using System;

namespace _3902_Project
{
    public partial class RendererLists
    {
        private Renderer[] _rendererList;
        public enum RendOrder { Size2, Size2DownUpFlip, Size2RightLeftFlip, Size2Flip, Size3DownUp, Size3DownUpFlip, Size3RightLeft, Size3RightLeftFlip, Size4 }
        private RendOrder _rendListType;
        private Renderer.DIRECTION _direction;

        // case 1: Size2
        private Renderer _rendDownUp;
        private Renderer _rendRightLeft;
        // case 2 - 4: Size3DownUp, Size3RightLeft, Size4
        private Renderer _rendDown;
        private Renderer _rendUp;
        private Renderer _rendRight;
        private Renderer _rendLeft;

        private Random _random = new Random();

        /// <summary>
        /// constructor for creating a plain RendererList
        /// </summary>
        /// <param name="rendererList">the list of renderers to be inputed</param>
        /// <param name="order">the type of RendererList you want based on given "rendererList"</param>
        public RendererLists(Renderer[] rendererList, RendOrder order)
        {
            _rendererList = rendererList;
            _rendListType = order;
            SetRenderers();
        }
    }
}