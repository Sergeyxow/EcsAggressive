using Leopotam.Ecs;

namespace Client
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        private EcsFilter<DamageFlag, Npc> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var damage = ref _filter.Get1(index);
                ref var npc = ref _filter.Get2(index);

                npc.health -= damage.value;

                if (npc.health <= 0)
                {
                    _filter.GetEntity(index).Set<DeathFlag>().killer = damage.source;
                }
            }
        }
    }
}