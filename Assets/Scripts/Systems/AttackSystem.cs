using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class AttackSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<AttackFlag, AggressiveState, FollowTarget, Npc>.Exclude<AttackCooldown> _filter;
        private GameData _gameData;
        
        public void Run()
        {
            
            foreach (var index in _filter)
            {
                ref var followTarget = ref _filter.Get3(index);
                ref var attackFlag = ref _filter.Get1(index);
                ref var npc = ref _filter.Get4(index);

                var bulletObj = GameObject.Instantiate(_gameData.bulletPrefab, npc.bulletSpawnPoint.position, Quaternion.identity);
                EcsEntity bulletEntity = _world.NewEntity();
                
                ref Bullet bullet = ref bulletEntity.Set<Bullet>();
                
                bullet.attacker = _filter.GetEntity(index);
                bullet.target = followTarget.targetEntity;
                bullet.transform = bulletObj.transform;

                ref var mover = ref bulletEntity.Set<Mover>();
                mover.speed = _gameData.bulletSpeed;
                mover.transform = bulletObj.transform;

                _filter.GetEntity(index).Set<AttackCooldown>().time = 1.5f;
            }
        }
    }
}