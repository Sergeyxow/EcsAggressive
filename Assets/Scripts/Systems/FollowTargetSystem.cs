using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class FollowTargetSystem : IEcsRunSystem
    {
        private EcsFilter<AggressiveState, Mover, FollowTarget, Npc> _filter;
        private GameData _gameData;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref Mover mover = ref _filter.Get2(index);
                ref FollowTarget followTarget = ref _filter.Get3(index);
                ref var npc = ref _filter.Get4(index);

                Vector3 currentPos = npc.objectRef.transform.position;
                Vector3 targetPos = followTarget.target.position;

                float distance = Vector3.Distance(currentPos, targetPos);

                if (distance > _gameData.distanceToStopFollowing)
                {
                    Vector3 direction = (targetPos - currentPos).normalized;

                    mover.direction = direction;
                }
            }
        }
    }
}