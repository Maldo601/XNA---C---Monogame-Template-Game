﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    public class BaseObject
    {
        public int ID { get; set; }
        private readonly List<Component> _components;

        public BaseObject()
        {
            _components = new List<Component>();
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        public void AddComponents(List<Component> components)
        {
            _components.AddRange(components);
            foreach(var component in components)
            {
                component.Initialize(this);
            }
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public void Update (double gameTime)
        {
            foreach(var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var component in _components)
            {
                component.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
            if (_components == null)
                return;
            _components.ForEach(c => c.Initialize());
        }

        public void Uninitialize()
        {
            if (_components == null)
                return;
            _components.ForEach(c => c.Uninitalize());
        }

    }
}
