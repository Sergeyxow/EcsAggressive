using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class NpcInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        public void Init () 
        {
            foreach (var npcObj in GameObject.FindGameObjectsWithTag("Npc"))
            {
                NpcObject npcObjectScript = npcObj.GetComponent<NpcObject>();
                
                EcsEntity npcEntity = _world.NewEntity();
                npcObjectScript.entity = npcEntity;
                
                npcEntity.Set<Npc>().objectRef = npcObj;
                
                ref RouteMover routeMover = ref npcEntity.Set<RouteMover>();
                routeMover.points = (Vector3[])npcObjectScript.route.points.Clone();
                // routeMover.points = npcObjectScript.route.points;
                routeMover.moveToPointIdx = 0;

                npcEntity.Set<Mover>().speed = npcObjectScript.speed;
                npcEntity.Set<IdleState>();
            }
        }
    }
}