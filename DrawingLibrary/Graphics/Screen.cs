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

        /// <summary>
        /// Draw sprites to the window. This is performed by using the spritesRenderer to begin drawing, 
        /// drawing with the computed rectangle, and ending the batch
        /// </summary>
        /// <param name="spritesRenderer">The sprites to be drawn</param>
        /// <param name="textureFiltering"></param>
        /// <exception cref="ArgumentNullException">Throws if sprites renderer is null</exception>
        ///
        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            if (spritesRenderer == null)
            {
                throw new ArgumentNullException("spritesRenderer is null");
            }

            spritesRenderer.Begin(textureFiltering);
            spritesRenderer.Draw(_target, _rectangle, Color.White);   
            spritesRenderer.End();
        }

        /// <summary>
        /// Enables drawing on the render target. This is done by setting the GraphicsDevice render target 
        /// to a render target object
        /// </summary>
        /// <exception cref="Exception">Throws if screen is already set</exception>
        ///
        public void Set()
        {
            if (graphicsDevice.GetRenderTargets().Length > 0)
            {
                throw new Exception("Screen is already set");
            }

            graphicsDevice.SetRenderTarget(_target);
        }

        /// <summary>
        /// Removes drawing on the render target. This is done by setting the GraphicsDevice render target to null
        /// </summary>
        /// <exception cref="Exception">Throws if screen is already unset</exception>
        ///
        public void UnSet()
        {
            if (graphicsDevice.GetRenderTargets().Length == 0)
            {
                throw new Exception("Screen is already unset");
            }

                graphicsDevice.SetRenderTarget(null);
        }

        /// <summary>
        /// Computes the rectangle that fits inside the windows given the screen size. 
        /// Computes the aspect ratio of the window versus the screen and adds a border to either the top or bottom or to the left or right sides
        /// </summary>
        /// <returns>A rectangle whose coordinates and size represent where the screen should be drawn with respect to the window</returns>
        /// <remarks>Note, the coordinate system of the window is (0,0) in the upper left corner with positive X right and positive Y down</remarks>
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
