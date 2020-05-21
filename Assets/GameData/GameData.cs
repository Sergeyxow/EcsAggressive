using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    [Header("Rest Timing")]
    public float minRestTime;
    public float maxRestTime;

    [Header("Aggressive state data")] 
    public float distanceToAttack;
    public float distanceToStopFollowing;
    public int startHP;

    [Header("Bullet")] 
    public GameObject bulletPrefab;
    public float bulletSpeed;
}
