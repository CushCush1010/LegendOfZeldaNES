// CommandMoveRight.cs
namespace _3902_Project
{
    public class CommandMoveRight : ICommand
    {
        private LinkManager _link;

        public CommandMoveRight(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkDirection(Renderer.DIRECTION.RIGHT);
            _link.SetLinkState(LinkManager.LinkActions.Moving);
        }
    }
}
