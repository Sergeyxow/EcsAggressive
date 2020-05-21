using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class RestSystem : IEcsRunSystem
    {
        private EcsFilter<Rest, RouteMover, Npc> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref Rest restComponent = ref _filter.Get1(index);
                ref RouteMover routeMover = ref _filter.Get2(index);

                if (restComponent.timePassed < restComponent.time)
                {
                    restComponent.timePassed += Time.deltaTime;
                }
                else
                {
                    routeMover.moveToPointIdx = restComponent.nextPointIndex;
                    _filter.GetEntity(index).Unset<Rest>();
                }
            }
        }
    }
}