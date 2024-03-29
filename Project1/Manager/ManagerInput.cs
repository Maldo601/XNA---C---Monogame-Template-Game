﻿using Microsoft.Xna.Framework.Input;
using Project1.Components;
using Project1.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Manager
{
    class ManagerInput
    {
        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;

        private static event EventHandler<NewInputEventArgs> _FireNewInput;
        private double _counter;
        private static double _cooldown;

        public static event EventHandler<NewInputEventArgs> FireNewInput
        {
            add { _FireNewInput += value; }
            remove { _FireNewInput -= value;  }

        }

        public static bool ThrottleInput { get; set; }
        public static bool LockMovement { get; set; }


        public ManagerInput()
        {
            ThrottleInput = false;
            LockMovement = false;
            _counter = 0;
        }

        public void Update(double gameTime)
        {
            if(_cooldown > 0)
            {
                _counter += gameTime;
                if(_counter > gameTime)
                {
                    _cooldown = 0;
                    _counter = 0;
                }
                else
                {
                    return;
                }
            }
            ComputerControlls(gameTime);
        }

        public void ComputerControlls(double gameTime)
        {
            _keyState = Keyboard.GetState();
            if(_keyState.IsKeyUp(_lastKey) && _lastKey != Keys.None)
            {
                if(_FireNewInput != null)
                {
                    _FireNewInput(this, new NewInputEventArgs(Input.None));
                }
            }

            CheckKeyState(Keys.A, Input.Left);  
            CheckKeyState(Keys.D, Input.Right); 
            CheckKeyState(Keys.W, Input.Up);    
            CheckKeyState(Keys.S, Input.Down);
            CheckKeyState(Keys.None, Input.None);

            _lastKeyState = _keyState;

        }

        private void CheckKeyState(Keys key, Input fireInput)
        {
            if (_keyState.IsKeyDown(key))
            {
                if(!ThrottleInput || (ThrottleInput && _lastKeyState.IsKeyUp(key)))
                {
                    if(_FireNewInput != null)
                    {
                        _FireNewInput(this, new NewInputEventArgs(fireInput));
                        _lastKey = key;
                    }
                }
            }
        }
    }
}
