// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory : ICommand
    {
        private LinkManager _link;

        public CommandLinkSetInventory(Game1 game, int key)
        {
            _link = game._Link;
        }

        public void Execute()
        {
            _link.SetLinkState(LinkManager.LinkActions.Throwing);
        }
    }
}
