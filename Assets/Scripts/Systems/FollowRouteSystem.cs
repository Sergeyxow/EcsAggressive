using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class FollowRouteSystem : IEcsRunSystem
    {
        private EcsFilter<Npc, IdleState, RouteMover, Mover> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref Npc npc = ref _filter.Get1(index);
                ref RouteMover routeMover = ref _filter.Get3(index);
                ref Mover mover = ref _filter.Get4(index);

                Vector3 currentPos = npc.objectRef.transform.position;
                Vector3 nextPointPos = routeMover.points[routeMover.moveToPointIdx];

                Vector3 direction = (nextPointPos - currentPos).normalized;

                mover.direction = direction;
            }
        }
    }
}