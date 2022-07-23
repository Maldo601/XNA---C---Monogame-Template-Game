using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1.Components
{
    public class Animation : Component
    {
       
        public override ComponentType ComponentType
        {
            get { return ComponentType.Animation;  } 
        }
        public Rectangle TextureRectangle { get; private set; }
        public Direction Direction { get; set; }
        public Direction _currentDirection;

        public State CurrentState { get; private set; }
        private State _currentState;
        private KeyboardState _keyState;
        private int _width;
        private int _height;
        private double _counter;
        private int _animationIndex;
        public int AnimationIndex { get; private set; }

        public Animation(int width, int height)
        {
            _width = width;
            _height = height;
            _counter = 0;
            _animationIndex = 0;
            AnimationIndex = 0;
            _currentState = State.Standing;
            TextureRectangle = new Rectangle(0, 0, width, height);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }

        public override void Update(double gameTime)
        {
            switch (_currentState)
            {
                case State.Walking:
                    _counter += gameTime;
                    if (_counter > 150)
                    {
                        ChangeState();
                        _counter = 0;
                    }
                    break;
            }
        }

        public void ResetCounter(State state, Direction direction)
        {
            if(state != _currentState)
            {
                _counter = 1000;
                _animationIndex = 0;
            }
            _currentState = state;
            _currentDirection = direction;
        }

        private void ChangeState(int y = 0, int animationFrames = 2)
        {   
            switch (_currentDirection)
            {
                case Direction.Down:
                    TextureRectangle = new Rectangle(_width * _animationIndex, 0, _width, _height);
                    break;
                case Direction.Up:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height, _width, _height);
                    break;
                case Direction.Left:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 2, _width, _height);
                    break;
                case Direction.Right:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height*3, _width, _height);
                    break;
                
            }
            

        int _counter = 0;
            
            if(! _keyState.IsKeyDown(Keys.None))
            {
                _animationIndex = _animationIndex == 0 ? _animationIndex = _counter + 1 : _counter = 0;
    
            }
          
            //_currentState = State.Standing;
            
        }
    }
}
