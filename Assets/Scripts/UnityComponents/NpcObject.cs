using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class NpcObject : MonoBehaviour
{
    [HideInInspector] public EcsEntity entity;
    public Route route;
    public float speed;
    public Transform bulletSpawnPoint;
}
