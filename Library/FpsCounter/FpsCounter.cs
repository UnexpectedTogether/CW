using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Library.FpsCounter
{
    public class FpsCounter: DrawableGameComponent
    {
        private int _fps;
        private int _frames;
        private double _seconds;

        public FpsCounter(Game game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            _seconds += gameTime.ElapsedGameTime.TotalSeconds;
            if (_seconds >= 1)
            {
                _fps = _frames;
                Game.Window.Title = "FPS:" + _frames;
                _seconds = _frames = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _frames++;
            base.Draw(gameTime);
        }
    }
}
