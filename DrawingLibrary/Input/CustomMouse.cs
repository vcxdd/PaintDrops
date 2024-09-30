﻿using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DrawingLibrary.Input
{
    public sealed class CustomMouse : ICustomMouse
    {
        /// <summary>
        /// Current mouse position with respect to the window
        /// </summary>
        public Point WindowPosition { get; }
        public MouseState previousState;
        public MouseState currentState;
        private GraphicsDevice _graphicsDevice;
        private static CustomMouse instance = null;

        private CustomMouse() 
        {
            previousState = Mouse.GetState();
            currentState = Mouse.GetState();
            WindowPosition = new Point(currentState.X, currentState.Y);
        }

        public void SetGraphicsDevice(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public static CustomMouse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomMouse();
                }
                return instance;
            }
        }

        /// <summary>
        /// Converts the current mouse position to its relative position in the provided screen.
        /// Note, if the position is outside the area of the screen, the method returns null
        /// </summary>
        /// <param name="screen">The screen whose coordinate system the point must be converted to.</param>
        /// <returns>The converted point with respect to the screens coordinate system</returns>
        public Vector2? GetScreenPosition(IScreen screen)
        {
            if (screen == null) return null;

            Rectangle screenRectangle = screen.CalculateDestinationRectangle();

            // Check if the mouse is within the screen rectangle bounds
            if (currentState.X < screenRectangle.Left || currentState.X > screenRectangle.Right ||
                currentState.Y < screenRectangle.Top || currentState.Y > screenRectangle.Bottom)
            {
                return null;
            }
            
            float scaleX = (float)screen.Width / _graphicsDevice.Viewport.Width;
            float scaleY = (float)screen.Height / _graphicsDevice.Viewport.Height;

            float adjustedX = (currentState.X - screen.coords.X) * scaleX;
            float adjustedY = (currentState.Y - screen.coords.Y) * scaleY;

            return new Vector2(adjustedX, adjustedY);
        }

        public bool IsLeftButtonClicked()
        {
            if (currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftButtonDown()
        {
            if (currentState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftButtonUp()
        {
            if (currentState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool IsMiddleButtonClicked()
        {
            if (currentState.MiddleButton == ButtonState.Released && previousState.MiddleButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsMiddleButtonDown()
        {
            if (currentState.MiddleButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsRightButtonClicked()
        {
            if (currentState.RightButton == ButtonState.Released && previousState.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsRightButtonDown()
        {
            if (currentState.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the states of the mouse. Needs to be called in an update loop
        /// </summary>
        public void Update()
        {
            previousState = currentState;
            currentState = Mouse.GetState();
        }
    }
}