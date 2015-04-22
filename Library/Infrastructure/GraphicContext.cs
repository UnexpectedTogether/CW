using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Infrastructure
{
    public class GraphicContext
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float Opacity { get; set; }
        public float Angle { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }

        public GraphicContext(Texture2D texture, int width, int height, float angle, float opacity, Color color)
        {
            Angle = angle;
            Color = color;
            Height = height;
            Opacity = opacity;
            Texture = texture;
            Width = width;
        }

        public GraphicContext(Texture2D texture):this(texture,texture.Width,texture.Height,0f,1f,Color.White)
        {
        }


        public GraphicContext(Texture2D texture, int width, int height)
            : this(texture,width,height, 0f, 1f, Color.White)
        {
        }

        public GraphicContext(Texture2D texture, int width, int height, Color color):
            this(texture,width,height,0f,1f,Color.White)
        {
        }
    }
}
