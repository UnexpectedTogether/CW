using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Abstractions
{
    public class StaticGameObject : GameObject
    {
        protected ObjectState _objectState;

        public StaticGameObject(GraphicContext graphicContext, Vector2 position, ObjectState objectState)
            : base(graphicContext, position)
        {
            _objectState = objectState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_objectState.IsAlive)
            {
                Rectangle src = new Rectangle((int)_position.X, (int)_position.Y, _graphicContext.Width, _graphicContext.Height);
                Vector2 origin = new Vector2((float)_graphicContext.Width/2, (float)_graphicContext.Height / 2);
                spriteBatch.Draw(_graphicContext.Texture, _position, null, _graphicContext.Color
                    , _graphicContext.Angle, origin, 1f, SpriteEffects.None, 1);
                base.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_objectState.IsAlive)
            {
                _objectState.Lifetime -= gameTime.ElapsedGameTime;
                if (_objectState.Lifetime < TimeSpan.Zero)
                {
                    _objectState.IsAlive = false;
                }
            }
        }
    }
}
