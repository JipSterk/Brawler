using UnityEngine;

namespace Brawler.Pooling
{
    public interface IPoolAble
    {
        Component Component { get; }
        
        void OnDisable();
    }
}