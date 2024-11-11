// CommandMoveDown.cs
namespace _3902_Project
{
    public class CommandLinkStill : ICommand
    {
        private LinkManager _link;

        public CommandLinkStill(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkState(LinkManager.LinkActions.Standing);
        }
    }
}
