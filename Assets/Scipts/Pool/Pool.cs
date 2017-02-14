using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brawler.Pooling
{
    public struct Pool
    {
        private Component _component;
        private Transform _parent;
        private List<Component> _components;
        
        public Pool(Component component, Transform parent, int count)
        {
            _component = component;
            _parent = parent;
            _components = new List<Component>();

            for (var i = 0; i < count; i++)
                AddToPool(Object.Instantiate(_component, parent));
        }

        public void AddToPool(Component component)
        {
            _components.Add(component);
            component.gameObject.SetActive(false);
        }

        public Component GetFromPool()
        {
            Component component;
            if (_components.Count > 0)
            {
                component = _components.First();
                _components.Remove(component);
                component.gameObject.SetActive(true);
                return component;
            }
            
            component = Object.Instantiate(_component, _parent).GetComponent(_component.GetType());
            return component;
        }
    }
}