using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

namespace Client
{
    public class SwitchToAggressiveSystem : IEcsRunSystem
    {
        private EcsFilter<SwitchToAggressiveFlag> _filter;
        private EcsFilter<Npc> _npcFilter;
        
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

                    Transform randomTarget = FindRandomTarget(entity);

                    if (randomTarget)
                    {
                        entity.Set<FollowTarget>().target = randomTarget;
                    }
                }
            }
        }

        [CanBeNull]
        private Transform FindRandomTarget(EcsEntity sourceEntity)
        {

            foreach (var index in _npcFilter)
            {
                if (_npcFilter.GetEntity(index) == sourceEntity)
                    continue;

                return _npcFilter.Get1(index).objectRef.transform;
            }

            return null;
        }
    }
}