using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    class AttackCooldownSystem : IEcsRunSystem
    {
        private EcsFilter<AttackCooldown> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var cooldownComponent = ref _filter.Get1(index);
                
                if (cooldownComponent.timePassed < cooldownComponent.time)
                {
                    cooldownComponent.timePassed += Time.deltaTime;
                }
                else
                {
                    _filter.GetEntity(index).Unset<AttackCooldown>();
                }
            }
        }
    }
}