using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace _3902_Project
{
    // Implementing IController interface for keyboard input handling
    public class MouseInput : IController
    {
        // use game for inputs
        private Game1 _game;

        private HashSet<string> previousMouseButtons = new HashSet<string>();

        // Constructor to initialize the game and map keys to commands
        public MouseInput(Game1 game)
        {
            this._game = game;
        }

        // Update method to check keyboard input and execute corresponding commands
        public void Update()
        {
            //get the keyboard state
            MouseState currentMouseState = Mouse.GetState();
            HashSet<string> newbuttonsClicked = new HashSet<string>();

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                newbuttonsClicked.Add("rc");
            else if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                newbuttonsClicked.Add("lc");

            // for each key, find if it is either previously pressed or a movement key
            foreach (string key in newbuttonsClicked)
            {
                if (key == "rc" && !previousMouseButtons.Contains("rc"))
                {
                    _game.EnvironmentFactory.incrementLevel();
                    _game.Menu.incrementLevel();
                }

                else if (key == "lc" && !previousMouseButtons.Contains("lc"))
                {
                    _game.EnvironmentFactory.decrementLevel();
                    _game.Menu.decrementLevel();
                }
            }

            // set old previous keys = new previous keys
            previousMouseButtons = newbuttonsClicked;
        }
    }
}
