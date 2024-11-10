// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkThrow : ICommand
    {
        private LinkManager _link;

        public CommandLinkThrow(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkState(LinkManager.LinkActions.Throwing);
        }
    }
}
