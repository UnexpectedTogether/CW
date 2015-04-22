using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.InputHandlers
{
    public class KeyboardInputHandler : GameComponent
    {
        private static KeyboardState _keyboardState;
        private static KeyboardState _oldKeyboardState;

        public KeyboardInputHandler(Game game)
            : base(game)
        {
            _keyboardState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            _oldKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
            base.Update(gameTime);
        }

        public static bool IsKeyDown(Keys key)
        {
            return _keyboardState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {  

            return _keyboardState.IsKeyUp(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return _keyboardState.IsKeyDown(key) && _oldKeyboardState.IsKeyUp(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            return _keyboardState.IsKeyUp(key) && _oldKeyboardState.IsKeyDown(key);
        }
    }
}
