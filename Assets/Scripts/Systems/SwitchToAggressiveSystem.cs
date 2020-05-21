using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class SwitchToAggressiveSystem : IEcsRunSystem
    {
        private EcsFilter<SwitchToAggressiveFlag> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                
                if (entity.Has<AggressiveState>())
                {
                    Debug.Log("Entity's state is already aggressive");
                    return;
                }

                if (entity.Has<IdleState>())
                {
                    entity.Unset<IdleState>();
                    entity.Set<AggressiveState>();
                }
            }
        }
    }
}