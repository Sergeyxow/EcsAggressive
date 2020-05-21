using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class BulletFollowSystem : IEcsRunSystem
    {
        private EcsFilter<Bullet, Mover> _filter;


        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var bullet = ref _filter.Get1(index);
                ref var mover = ref _filter.Get2(index);
                
                Vector3 currentPos = bullet.transform.position;

                if (!bullet.target.Has<Npc>())
                {
                    Debug.Log("Target is not npc");
                    _filter.GetEntity(index).Destroy();
                    return;
                }

                Vector3 targetPos = bullet.target.Set<Npc>().objectRef.transform.position;

                float distance = Vector3.Distance(currentPos, targetPos);

                float step = mover.speed * Time.deltaTime + 0.03f;
                
                if (distance > step)
                {
                    Vector3 direction = (targetPos - currentPos).normalized;

                    mover.direction = direction;
                }
                else
                {
                    bullet.target.Set<Damage>().value = 1;
                    
                    Object.Destroy(bullet.transform.gameObject);
                    _filter.GetEntity(index).Destroy();
                }
            }
        }
    }
}