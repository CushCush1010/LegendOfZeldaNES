using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class KeyboardInput : IController
    {
        // Dictionary to map keys to corresponding commands
        private Dictionary<Keys, ICommand> keysToCommands = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> keysMoveToCommands = new Dictionary<Keys, ICommand>();

        // Create a set of previous keys for previous 
        private HashSet<Keys> _previousKeys = new HashSet<Keys>();

        // use game for inputs
        private Game1 _game;


        // Constructor to initialize the game and map keys to commands
        public KeyboardInput(Game1 game)
        {
            this._game = game;

            // Mapping keys to corresponding commands for player movement
            keysMoveToCommands.Add(Keys.W, new CommandMoveUp(game));
            keysMoveToCommands.Add(Keys.S, new CommandMoveDown(game));
            keysMoveToCommands.Add(Keys.A, new CommandMoveLeft(game));
            keysMoveToCommands.Add(Keys.D, new CommandMoveRight(game));
            keysMoveToCommands.Add(Keys.Up, new CommandMoveUp(game));
            keysMoveToCommands.Add(Keys.Down, new CommandMoveDown(game));
            keysMoveToCommands.Add(Keys.Left, new CommandMoveLeft(game));
            keysMoveToCommands.Add(Keys.Right, new CommandMoveRight(game));

            // Mapping keys for damaged state
            keysToCommands.Add(Keys.E, new CommandLinkDamaged(game));

            // Mapping keys for other actions such as attack
            keysToCommands.Add(Keys.Z, new CommandLinkSwordAttack(game));
            keysToCommands.Add(Keys.N, new CommandLinkThrow(game));

            // Mapping keys for game control actions such as reset and quit
            keysToCommands.Add(Keys.Q, new CommandQuit(game));
            keysToCommands.Add(Keys.R, new CommandReset(game));

            // Mapping keys for moving through the inventory
            keysToCommands.Add(Keys.D1, new CommandLinkSetInventory(game, 1));
            keysToCommands.Add(Keys.D2, new CommandLinkSetInventory(game, 2));
            keysToCommands.Add(Keys.D3, new CommandLinkSetInventory(game, 3));

        }


        private bool IsMoveKey(Keys key)
        {
            return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D ||
                   key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right;
        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            //get the keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] currentKeyboardPressed = currentKeyboardState.GetPressedKeys();
            HashSet<Keys> newPreviousKeys = new HashSet<Keys>();

            // for each key, find if it is either previously pressed or a movement key
            foreach (Keys key in currentKeyboardPressed)
            {
                // if key passes check, then execute
                if (keysToCommands.ContainsKey(key)) 
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    // add keys to a new previous
                    newPreviousKeys.Add(key);
                }
            }
            // if conditions for movement keys
            if (currentKeyboardPressed.Length == 0) { new CommandLinkStill(_game).Execute(); }
            else if (currentKeyboardPressed.Length > 0)
            {
                Keys key = currentKeyboardPressed[currentKeyboardPressed.Length - 1];
                if (keysMoveToCommands.ContainsKey(key))
                {
                    if (!_previousKeys.Contains(key))
                    {
                        ICommand setKeyboardCommand = keysMoveToCommands[key];
                        setKeyboardCommand.Execute();
                    }
                    newPreviousKeys.Add(key);
                }
            }

            // set old previous keys = new previous keys
            _previousKeys = newPreviousKeys;
        }
    }
}
