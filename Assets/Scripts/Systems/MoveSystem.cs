﻿using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Mover>.Exclude<Rest> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref Mover mover = ref _filter.Get1(index);

                Vector3 movePos = mover.speed * mover.direction * Time.deltaTime;
                movePos.y = 0;
                mover.transform.position += movePos;

                mover.direction = Vector3.zero;
            }
        }
    }
}