﻿// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkThrow : ICommand
    {
        private LinkManager _link;

        public CommandLinkThrow(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            if (_link.CanFireProjectile())
            {
                _link.SetLinkSpriteState(LinkManager.LinkSprite.Throwing);
                _link.FireProjectile();
            }
        }
    }
}
