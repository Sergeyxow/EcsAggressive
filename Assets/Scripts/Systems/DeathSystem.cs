using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class DeathSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<DeathFlag, Npc> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var npc = ref _filter.Get2(index);
                ref var death = ref _filter.Get1(index);

                GameObject.Destroy(npc.objectRef);
                death.killer.Set<KilledTarget>();
                var entity = _filter.GetEntity(index);
                entity.Destroy();
            }
        }
    }
}