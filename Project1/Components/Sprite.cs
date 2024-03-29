﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1.Components
{
    public class Sprite : Component
    {

        private Texture2D _texture;
        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;
        private int _width;
        private int _height;
        private Vector2 _position;
        public Vector2 Position { get; private set; }

        public Color Color { get; set; }

        public Sprite(Texture2D texture, int width, int height, Vector2 position)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _position = position;
            Color = Color.White;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Sprite; }
        }

        public Rectangle Rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, _width, _height); } }

        public override void Draw(SpriteBatch spritebatch)
        {
         
            var animation = GetComponent<Animation>(ComponentType.Animation);

            if (animation != null)
            {
                spritebatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _width, _height), animation.TextureRectangle, Color.White);
            }
            else
            {
                spritebatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _width, _height),
                                 Color.White);
            }

        }

        public override void Update(double gameTime)
        {
           
        }

        public void Move(float x, float y)
        {
            _position = new Vector2(_position.X + x, _position.Y + y);

            var animation = GetComponent<Animation>(ComponentType.Animation);

            if (animation == null)
            {
                return;
            }
            else
            {
                if (x > 0)
                {
                    animation.ResetCounter(State.Walking, Direction.Right);
                }
                else if (x < 0)
                {
                    animation.ResetCounter(State.Walking, Direction.Left);
                }
                else if (y > 0)
                {
                    animation.ResetCounter(State.Walking, Direction.Down);
                }
                else if (y < 0)
                {
                    animation.ResetCounter(State.Walking, Direction.Up);
                } 
                else if (x == 0 || y == 0)
                {
                    animation.ResetCounter(State.Standing, Direction.None);
                }
            }

          
        }
    }
}
