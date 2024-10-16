using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using ShapeLibrary;
using DrawingLibrary;

namespace PaintDrops
{
    public class PaintDropsGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IScreen screen;
        private CustomKeyboard _keyboard;
        private CustomMouse _mouse;
        private Color _backgroundColor = Color.White;
        private ISpritesRenderer _spritesRenderer;
        private IShapesRenderer _shapesRenderer;

        private List<IShape> _shapes = new List<IShape>();

        public PaintDropsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += onClientSizeChanged;

            this.screen = new Screen(new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            this._spritesRenderer = new SpritesRenderer(GraphicsDevice);
            this._shapesRenderer = new ShapesRenderer(GraphicsDevice);

            this._keyboard = CustomKeyboard.Instance;
            this._mouse = CustomMouse.Instance;
            _mouse.SetGraphicsDevice(GraphicsDevice);
        }

        private void onClientSizeChanged(Object sender, EventArgs e)
        {
            screen.CalculateDestinationRectangle();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _keyboard.Update();
            _mouse.Update();
            screen.CalculateDestinationRectangle();
            
            if (_keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (_mouse.IsLeftButtonClicked())
            {
                Vector2? pos = _mouse.GetScreenPosition(screen);
                if (pos.HasValue)
                {
                    Random random = new Random();
                    int red = random.Next(0, 255);
                    int green = random.Next(0, 255);
                    int blue = random.Next(0, 255);
                    Colour color = new Colour(red, green, blue);
                    _shapes.Add(ShapesFactory.CreateCircle(pos.Value.X, pos.Value.Y, 64, color));
                }
            }

            if (_mouse.IsRightButtonClicked())
            {
                Vector2? pos = _mouse.GetScreenPosition(screen);
                if (pos.HasValue)
                {
                    Random random = new Random();
                    int red = random.Next(0, 255);
                    int green = random.Next(0, 255);
                    int blue = random.Next(0, 255);
                    Colour color = new Colour(red, green, blue);
                    _shapes.Add(ShapesFactory.CreateRectangle(pos.Value.X, pos.Value.Y, 128, 128, color));
                }
            }

            if (_mouse.IsMiddleButtonClicked())
            {
                _shapes.Clear();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            screen.Set();

            GraphicsDevice.Clear(_backgroundColor);

            _shapesRenderer.Begin();
            foreach (IShape shape in _shapes)
            {
                _shapesRenderer.DrawShape(shape);
            }
            _shapesRenderer.End();

            screen.UnSet();
            screen.Present(this._spritesRenderer);

            base.Draw(gameTime);
        }
    }
}
