using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Screens
{
    public abstract class Screen
    {
        protected ManagerScreen ManagerScreen;
        public Screen(ManagerScreen managerScreen)
        {
            ManagerScreen = managerScreen;
        }

        public virtual void Initialize(){   }
        public virtual void Uninitialize() {   }

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
