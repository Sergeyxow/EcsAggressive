using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class SwitchToIdleSystem : IEcsRunSystem
    {
        private EcsFilter<SwitchToIdleFlag> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                
                if (entity.Has<IdleState>())
                {
                    Debug.Log("Entity's state is already idle");
                    return;
                }

                if (entity.Has<AggressiveState>())
                {
                    entity.Unset<AggressiveState>();
                    entity.Set<IdleState>();
                }
            }
        }
    }
}