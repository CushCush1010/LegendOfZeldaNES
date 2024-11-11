// CommandMoveLeft.cs
namespace _3902_Project
{
    public class CommandMoveLeft : ICommand
    {
        private LinkManager _link;

        public CommandMoveLeft(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkDirection(Renderer.DIRECTION.LEFT);
            _link.SetLinkState(LinkManager.LinkActions.Moving);
        }
    }
}
