using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class OnKilledSystem : IEcsRunSystem
    {
        private EcsFilter<KilledTarget> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                entity.Set<SwitchToIdleFlag>();
                entity.Unset<KilledTarget>();
            }
        }
    }
}
