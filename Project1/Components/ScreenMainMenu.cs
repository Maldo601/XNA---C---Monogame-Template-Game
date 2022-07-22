using System;
using System.Collections.Generic;
using System.Text;
using Project1.Manager;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Screens;
using System.Drawing;
using System.Numerics;

namespace Project1.Components
{
    class ScreenMainMenu : Screen
    {
        private SpriteFont _font;
        // private Texture2D _backgroundTexture;
        public ScreenMainMenu(ManagerScreen managerScreen) : base(managerScreen)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        } 

        public override void Update(double gameTime)
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("Font_GUI");
        }

    }
}
