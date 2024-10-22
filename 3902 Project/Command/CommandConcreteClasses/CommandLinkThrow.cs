﻿// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkThrow : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkThrow(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.Throw();  // Call the Throw method in the Player class
        }
    }
}