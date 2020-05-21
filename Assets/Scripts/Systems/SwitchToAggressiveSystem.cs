using System;
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
                    EcsEntity randomTarget = FindRandomTarget(entity);
                    
                    entity.Unset<IdleState>();
                    entity.Set<AggressiveState>();

                    ref var followTarget = ref entity.Set<FollowTarget>();
                    followTarget.targetTransform = randomTarget.Set<Npc>().objectRef.transform;
                    followTarget.targetEntity = randomTarget;
                }
            }
        }

        
        private EcsEntity FindRandomTarget(EcsEntity sourceEntity)
        {

            foreach (var index in _npcFilter)
            {
                if (_npcFilter.GetEntity(index) == sourceEntity)
                    continue;

                return _npcFilter.GetEntity(index);
            }

            sourceEntity.Unset<SwitchToAggressiveFlag>();
            throw new Exception("No target to attack");
        }
    }
}