using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using ShapeLibrary;
using DrawingLibrary;
using PaintDropSimulation;
using PatternGenerationLib;

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

        private ISurface _surface;

        private IPatternGenerator _patternGenerator = new Phyllotaxis();
        private bool _generating = false;

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

            this._surface = PaintDropSimulationFactory.CreateSurface(screen.Width, screen.Height);
        }

        private void onClientSizeChanged(Object sender, EventArgs e)
        {
            screen.CalculateDestinationRectangle();
        }

        protected override void Initialize()
        {
            _surface.PatternGeneration += (v) => _patternGenerator.CalculatePatternPoint(_surface);

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
                    int red = random.Next(255);
                    int green = random.Next(255);
                    int blue = random.Next(255);
                    Colour color = new Colour(red, green, blue);
                    ICircle c = ShapesFactory.CreateCircle(pos.Value.X, pos.Value.Y, 16, color);

                    this._surface.AddPaintDrop(PaintDropSimulationFactory.CreatePaintDrop(c));
                }
            }

            if (_mouse.IsRightButtonClicked())
            {
                this._surface.Drops.Clear();
            }

            if (_keyboard.IsKeyClicked(Keys.M))
            {
                _generating = true;

                Random random = new Random();
                int red = random.Next(255);
                int green = random.Next(255);
                int blue = random.Next(255);
                Colour color = new Colour(red, green, blue);

                _surface.GeneratePaintDropPattern(16, color);
            }

            if (_keyboard.IsKeyClicked(Keys.E))
            {
                _generating = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            screen.Set();

            GraphicsDevice.Clear(_backgroundColor);

            _shapesRenderer.Begin();
            
            foreach (IPaintDrop d in _surface.Drops)
            {
                _shapesRenderer.DrawShape(d.Circle);
            }
            _shapesRenderer.End();

            screen.UnSet();
            screen.Present(this._spritesRenderer);

            base.Draw(gameTime);
        }
    }
}
