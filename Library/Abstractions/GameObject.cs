using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Abstractions
{
    public class GameObject
    {
        protected Guid _guid;
        protected Vector2 _position;
        protected GraphicContext _graphicContext;

        public GameObject( GraphicContext graphicContext,Vector2 position)
        {
            _guid = Guid.NewGuid();
            _position = position;
            _graphicContext = graphicContext;
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

    }
}
