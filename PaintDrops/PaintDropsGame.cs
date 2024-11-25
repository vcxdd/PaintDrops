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
using System.Linq;
using System.Diagnostics;

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

        private List<IPatternGenerator> _patterns = new List<IPatternGenerator>();
        private IPatternGenerator _patternGenerator;
        private bool _generating = false;
        private int _currentCount;
        private int _maxCount = 125;
        private int _patIndex = 0;

        private float _radius = 16;
        private SpriteFont _font;

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

            _patterns.Add(PatternFactory.CreatePhyllotaxis());
            _patterns.Add(PatternFactory.CreateSpiral());
            _patternGenerator = _patterns[_patIndex];
        }

        private void onClientSizeChanged(Object sender, EventArgs e)
        {
            screen.CalculateDestinationRectangle();
        }

        protected override void Initialize()
        {
            _surface.PatternGeneration += _patternGenerator.CalculatePatternPoint;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Radius");
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
                    ICircle c = ShapesFactory.CreateCircle(pos.Value.X, pos.Value.Y, _radius, color);

                    this._surface.AddPaintDrop(PaintDropSimulationFactory.CreatePaintDrop(c));
                }
            }

            if (_mouse.IsRightButtonClicked())
            {
                _surface.Drops.Clear();
                _currentCount = 0;
                _generating = false;
                _patternGenerator.Reset();

            }

            if (_keyboard.IsKeyClicked(Keys.M))
            {
                _generating = true;
            }

            if (_generating && _currentCount < _maxCount)
            {
                GeneratePattern();
            }

            if (_keyboard.IsKeyClicked(Keys.E))
            {
                _generating = false;
            }

            if (_keyboard.IsKeyClicked(Keys.J))
            {
                if (_radius < 64)
                {
                    _radius += 1;
                }
            }

            if (_keyboard.IsKeyClicked(Keys.K))
            {
                if (_radius > 4)
                {
                    _radius -= 1;
                }
            }

            if (_keyboard.IsKeyClicked(Keys.P))
            {
                _surface.Drops.Clear();
                _currentCount = 0;
                _generating = false;
                _patternGenerator.Reset();

                _surface.PatternGeneration -= _patternGenerator.CalculatePatternPoint;
                _patIndex = (_patIndex + 1) % _patterns.Count;
                _patternGenerator = _patterns[_patIndex];
                _surface.PatternGeneration += _patternGenerator.CalculatePatternPoint;
            }

            base.Update(gameTime);
        }
        protected void GeneratePattern()
        {
            Random random = new Random();
            int red = random.Next(255);
            int green = random.Next(255);
            int blue = random.Next(255);
            Colour color = new Colour(red, green, blue);

            _surface.GeneratePaintDropPattern(16, color);
            _currentCount++;
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

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Radius: " + _radius, new Vector2(0, 0), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
