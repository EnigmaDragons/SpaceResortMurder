﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Render;

namespace MonoDragons.Core.Engine
{
    public static class World
    {
        private static readonly ColoredRectangle _darken;
        
        private static SpriteBatch _spriteBatch;

        static World()
        {
            _darken = new ColoredRectangle
            {
                Color = Color.FromNonPremultiplied(0, 0, 0, 130),
                Transform = new Transform2(new Size2(1920, 1080))
            };
        }

        public static void Init(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            DefaultFont.Load(CurrentGame.ContentManager);
        }

        public static void DrawBackgroundColor(Color color)
        {
            CurrentGame.GraphicsDevice.Clear(color);
        }

        public static void Draw(Texture2D texture, Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(texture, ScaleRectangle(rectangle), color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            var resource = Resources.Load<Texture2D>(imageName);
            _spriteBatch.Draw(resource, new Rectangle(ScalePoint(pixelPosition), ScalePoint(resource.Width, resource.Height)), Color.White);
        }

        public static void Draw(string imageName, Transform2 transform)
        {
            Draw(imageName, transform.ToRectangle());
        }

        public static void Draw(string imageName, Rectangle rectPostion)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), ScaleRectangle(rectPostion), Color.White);
        }

        public static void Draw(string imageName, Vector2 size, Anchor anchor)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), ScaleRectangle(new Rectangle(
                    new Point(
                        anchor.AnchorFromLeft ? anchor.HorizontalOffset : (int)Math.Round(CurrentDisplay.Display.GameWidth / CurrentDisplay.Display.Scale - anchor.HorizontalOffset),
                        anchor.AnchorFromTop ? anchor.VerticalOffset : (int)Math.Round(CurrentDisplay.Display.GameHeight / CurrentDisplay.Display.Scale - anchor.VerticalOffset)),
                    size.ToPoint())),
                Color.White);
        }
        
        public static void DrawRotatedFromCenter(string name, Transform2 transform)
        {
            var resource = Resources.Load<Texture2D>(name);
            var x = transform.Rotation.Value;
            _spriteBatch.Draw(resource, null, ScaleRectangle(transform.ToRectangle()), null, new Vector2(resource.Width / 2, resource.Height / 2),
                transform.Rotation.Value * .017453292519f, new Vector2(1, 1));
        }

        public static void Draw(Texture2D texture, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(texture, new Rectangle(ScalePoint(pixelPosition), ScalePoint(texture.Width, texture.Height)), Color.White);
        }

        public static void Draw(Texture2D texture, Rectangle rectPosition)
        {
            if (texture.Height > 1 && texture.Width > 1) // Clever hack to prevent from disposing of RectangleTextures
                Resources.Put(texture.GetHashCode().ToString(), texture);
            _spriteBatch.Draw(texture, ScaleRectangle(rectPosition), Color.White);
        }

        public static void Draw(Texture2D texture, Transform2 transform)
        {
            Draw(texture, transform.ToRectangle());
        }

        public static void DrawRotatedFromCenter(Texture2D texture, Rectangle rectPosition, Rotation2 rotation)
        {
            Resources.Put(texture.GetHashCode().ToString(), texture);
            var scaledRect = ScaleRectangle(rectPosition);
            _spriteBatch.Draw(texture, null, scaledRect, null, new Vector2(scaledRect.Width / 2, scaledRect.Height / 2),
                rotation.Value * .017453292519f, new Vector2(1, 1));
        }
        
        public static void Darken()
        {
            _darken.Draw(Transform2.Zero);
        }

        private static Rectangle ScaleRectangle(Rectangle rectangle)
        {
            return new Rectangle(ScalePoint(rectangle.Location), ScalePoint(rectangle.Size));
        }

        private static Point ScalePoint(float x, float y)
        {
            return ScalePoint(new Vector2(x, y));
        }

        private static Point ScalePoint(Vector2 vector)
        {
            return new Point((int)Math.Round(vector.X * CurrentDisplay.Display.Scale), (int)Math.Round(vector.Y * CurrentDisplay.Display.Scale));
        }

        private static Point ScalePoint(Point point)
        {
            return ScalePoint(point.ToVector2());
        }
    }
}
