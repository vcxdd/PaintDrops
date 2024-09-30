using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace DrawingLibrary.Input
{
    public sealed class CustomKeyboard : ICustomKeyboard
    {
        public KeyboardState currentState;
        public KeyboardState previousState;
        private static CustomKeyboard instance = null;

        private CustomKeyboard()
        {
            this.previousState = Keyboard.GetState();
            this.currentState = Keyboard.GetState();
        }

        public static CustomKeyboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomKeyboard();
                }
                return instance;
            }
        }

        /// <summary>
        /// Indicates if the key has been pressed.
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>If the key was clicked</returns>
        public bool IsKeyClicked(Keys key)
        {
            if(previousState.GetPressedKeys().Contains(key))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Indicates if the key is down
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>If the key is down</returns>
        public bool IsKeyDown(Keys key)
        {
            if (currentState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the status of the keyboard. Needs to be called in the update loop
        /// </summary>
        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
        }
    }
}
