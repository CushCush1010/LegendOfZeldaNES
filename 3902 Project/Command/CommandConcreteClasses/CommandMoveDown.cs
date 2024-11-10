// CommandMoveDown.cs
using System;

namespace _3902_Project
{
    public class CommandMoveDown : ICommand
    {
        private LinkManager _link;

        public CommandMoveDown(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkDirection(Renderer.DIRECTION.DOWN);
            _link.SetLinkState(LinkManager.LinkActions.Moving);
        }
    }
}
