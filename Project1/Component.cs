using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public abstract class Component
    {
        private BaseObject _baseObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize(BaseObject baseObject)
        {
            _baseObject = baseObject;
        }

        public int getOwnerId()
        {
            return _baseObject.ID;
        }

        public void removeMe()
        {
            _baseObject.RemoveComponent(this);
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject == null ? null : _baseObject.GetComponent<TComponentType>(componentType);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spritebatch);

        public virtual void Initialize() { }

        public virtual void Uninitalize() { }
    }
}
