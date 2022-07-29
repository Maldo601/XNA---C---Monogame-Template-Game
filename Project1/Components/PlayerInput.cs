using Microsoft.Xna.Framework.Graphics;
using Project1.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Components
{
    class PlayerInput : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.PlayerInput; }
        }

        public PlayerInput()
        {
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if(sprite == null)
            {
                return;
            }
            switch (e.Input)
            {
                case Input.Up:
                    sprite.Move(0, -1.5f);
                    break;
                case Input.Down:
                    sprite.Move(0, 1.5f);
                    break;
                case Input.Left:
                    sprite.Move(-1.5f, 0);
                    break;
                case Input.Right:
                    sprite.Move(1.5f, 0);
                    break;
                case Input.None:
                    sprite.Move(0f, 0);
                    break;
          
        
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
    
        }

        public override void Update(double gameTime)
        {
           
        }
    }
}
