using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public struct Bullet
    {
        public Transform transform;
        public EcsEntity target;
        public EcsEntity attacker;
    }
}