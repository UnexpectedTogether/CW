using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Library.InputHandlers
{
    public class MouseInputHandler : GameComponent
    {
        private static MouseState _mouseState;
        private static MouseState _oldMouseState;

        public MouseInputHandler(Game game) : base(game)
        {
            _mouseState = Mouse.GetState();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _oldMouseState = _mouseState;
            _mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        public static bool IsLeftButtonDown()
        {
            return _mouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool IsRightButtonDown()
        {
            return _mouseState.RightButton == ButtonState.Pressed;
        }

        public static bool IsLeftButtonUp()
        {
            return _mouseState.LeftButton == ButtonState.Released;
        }

        public static bool IsRightButtonUp()
        {
            return _mouseState.RightButton == ButtonState.Released;
        }

        /// <summary>
        /// Single press and hold
        /// </summary>
        /// <returns></returns>
        public static bool IsLeftButtonPressed()
        {
            return _mouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released;
        }


        /// <summary>
        /// Single press and hold
        /// </summary>
        /// <returns></returns>
        public static bool IsRightButtonPressed()
        {
            return _mouseState.RightButton == ButtonState.Pressed && _oldMouseState.RightButton == ButtonState.Released;
        }

        /// <summary>
        /// Single release
        /// </summary>
        /// <returns></returns>
        public static bool IsLeftButtonReleased()
        {
            return _mouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Single release
        /// </summary>
        /// <returns></returns>
        public static bool IsRightButtonReleased()
        {
            return _mouseState.RightButton == ButtonState.Released && _oldMouseState.RightButton == ButtonState.Pressed;
        }

        public Vector2 CurrentPosition()
        {
            return new Vector2(_mouseState.X,_mouseState.Y);
        }

        public Vector2 OldPosition()
        {
            return new Vector2(_oldMouseState.X,_oldMouseState.Y);
        }

        public Vector2 Moving()
        {
            return new Vector2(_mouseState.X - _oldMouseState.X, _oldMouseState.Y - _oldMouseState.Y);
        }




    }
}
