using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Infrastructure;
using Microsoft.Xna.Framework;

namespace Library.Abstractions
{
    public class StaticWorldObject: StaticGameObject
    {
        protected BlockType BlockType;
        public StaticWorldObject(GraphicContext graphicContext, Vector2 position, ObjectState objectState, BlockType blockType) 
            : base(graphicContext, position, objectState)
        {
            BlockType = blockType;
        }




    }
}
