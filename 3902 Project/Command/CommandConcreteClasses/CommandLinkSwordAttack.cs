// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSwordAttack : ICommand
    {
        private LinkManager _link;

        public CommandLinkSwordAttack(Game1 game)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkState(LinkManager.LinkActions.Throwing);
        }
    }
}
