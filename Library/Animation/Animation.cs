using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Animation
{
    public class Animation
    {
        private Texture2D _texture;
        private int _frameWidth;
        private int _frameHeight;
        private int _heightInFrames;
        private int _widthInFrames;
        private int _framesCount;
        private int _animationPeriod;
        private int _currentFrame = 0;
        private int _currentPeriodPart = 0;
        private Color _tintColor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture">Animation texture</param>
        /// <param name="widthInFrames">width in frames on texture</param>
        /// <param name="heightInFrames">height in frames on texture</param>
        /// <param name="animationPeriod">number of game cycles per frame </param>
        /// <param name="tintColor">tint color of frames</param>
        /// <param name="framesCount">total frames count in animation</param>
        public Animation(Texture2D texture, int widthInFrames, int heightInFrames, int animationPeriod, Color tintColor, int framesCount = 0)
        {
            _texture = texture;
            _heightInFrames = heightInFrames;
            _widthInFrames = widthInFrames;
            _frameWidth = texture.Width / widthInFrames;
            _frameHeight = texture.Height / heightInFrames;
            _framesCount = _framesCount <= 0 ? widthInFrames * heightInFrames : framesCount;
            _animationPeriod = animationPeriod;
            _tintColor = tintColor;
        }

        public void Update()
        {
            _currentPeriodPart++;
            if (_currentPeriodPart == _animationPeriod)
            {
                _currentPeriodPart = 0;
                _currentFrame++;
                if (_currentFrame == _framesCount)
                {
                    _currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int currentFrameVerticalPos = _currentFrame / _widthInFrames;
            int currentFrameHorizontalPos = _currentFrame % _widthInFrames;
            int topPos = currentFrameVerticalPos * _frameHeight;
            int leftPos = currentFrameHorizontalPos * _frameWidth;
            Rectangle currentFrameRect = new Rectangle(leftPos, topPos, _frameWidth, _frameHeight);
            spriteBatch.Draw(_texture, position, currentFrameRect, _tintColor);
        }
    }
}
