using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class CheckForNextPoint : IEcsRunSystem
    {
        private EcsFilter<Npc, IdleState, RouteMover, Mover>.Exclude<Rest> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref Npc npc = ref _filter.Get1(index);
                ref RouteMover routeMover = ref _filter.Get3(index);
                ref Mover mover = ref _filter.Get4(index);

                float step = mover.speed * Time.deltaTime + 0.01f;

                int nextPointIndex = routeMover.moveToPointIdx;
                Vector3 nextPoint = routeMover.points[nextPointIndex];
                Vector3 currentPos = npc.objectRef.transform.position;

                float distance = Vector3.Distance(nextPoint, currentPos);
                

                if (distance <= step * 2)
                {
                    if (nextPointIndex == routeMover.points.Length - 1)
                        nextPointIndex = 0;
                    else
                        nextPointIndex++;

                    ref Rest restComponent = ref _filter.GetEntity(index).Set<Rest>();
                    restComponent.time = Random.Range(0.1f, 1f);
                    restComponent.timePassed = 0;
                    restComponent.nextPointIndex = nextPointIndex;
                }
            }
        }
    }
}