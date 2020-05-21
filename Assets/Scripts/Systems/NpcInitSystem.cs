using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class NpcInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GameData _gameData;
        
        public void Init () 
        {
            foreach (var npcObj in GameObject.FindGameObjectsWithTag("Npc"))
            {
                NpcObject npcObjectScript = npcObj.GetComponent<NpcObject>();
                
                EcsEntity npcEntity = _world.NewEntity();
                npcObjectScript.entity = npcEntity;

                ref var npc = ref npcEntity.Set<Npc>();
                npc.objectRef = npcObj;
                npc.health = _gameData.startHP;
                npc.bulletSpawnPoint = npcObjectScript.bulletSpawnPoint;
                
                ref RouteMover routeMover = ref npcEntity.Set<RouteMover>();
                routeMover.points = (Vector3[])npcObjectScript.route.points.Clone();
                // routeMover.points = npcObjectScript.route.points;
                routeMover.moveToPointIdx = 0;

                ref var mover = ref npcEntity.Set<Mover>();
                mover.speed = npcObjectScript.speed;
                mover.transform = npcObj.transform;
                npcEntity.Set<IdleState>();
            }
        }
    }
}