using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace DrawingLibrary.Graphics
{
    public sealed class Screen : IScreen
    {
        private int _width;
        private int _height;
        public int Width => _width;
        public int Height => _height;
        private float aspectRatio;
        private RenderTarget2D _target;
        public GraphicsDevice graphicsDevice { get; }
        private Rectangle _rectangle;
        public Vector2 coords { get; set; }

        public Screen(RenderTarget2D target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target is null");
            }

            this._target = target;
            _height = target.Height;
            _width = target.Width;
            this.aspectRatio = (float)_width / _height;
            this.graphicsDevice = target.GraphicsDevice;
        }

        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            if (spritesRenderer == null)
            {
                throw new ArgumentNullException("spritesRenderer is null");
            }

            CalculateDestinationRectangle();
            spritesRenderer.Begin(textureFiltering);
            spritesRenderer.Draw(_target, _rectangle, Color.White);   
            spritesRenderer.End();
        }

        public void Set()
        {
            if (graphicsDevice.GetRenderTargets().Length > 0)
            {
                throw new Exception("Screen is already set");
            }

            graphicsDevice.SetRenderTarget(_target);
        }

        public void UnSet()
        {
            if (graphicsDevice.GetRenderTargets().Length == 0)
            {
                throw new Exception("Screen is already unset");
            }

                graphicsDevice.SetRenderTarget(null);
        }

        public Rectangle CalculateDestinationRectangle()
        {
            float screenWidth, screenHeight;
            int posX, posY;

            if (graphicsDevice.Viewport.Width > graphicsDevice.Viewport.Height)
            {
                screenHeight = graphicsDevice.Viewport.Height;
                screenWidth = screenHeight * this.aspectRatio;
                posX = (int)((graphicsDevice.Viewport.Width - screenWidth) / 2);
                posY = 0;

            } else
            {
                screenWidth = graphicsDevice.Viewport.Width;
                screenHeight = screenWidth / this.aspectRatio;
                posX = 0;
                posY = (int)((graphicsDevice.Viewport.Height - screenHeight) / 2);
            }

            coords = new Vector2(posX, posY);
            _rectangle = new Rectangle(posX, posY, (int)screenWidth, (int)screenHeight);

            return _rectangle;
        }
           
        public void Dispose()
        {
            if (_target != null)
            {
                _target.Dispose();
                _target = null;
            }
        }
    }
}
