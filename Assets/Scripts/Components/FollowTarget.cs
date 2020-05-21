using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public struct FollowTarget
    {
        public Transform targetTransform;
        public EcsEntity targetEntity;
    }
}