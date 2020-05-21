using System.Collections;
using System.Collections.Generic;
using Client;
using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;

public class SwitchStateButton : MonoBehaviour
{
    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 100, 70), "Aggressive"))
            MakeAggressive();

        if (GUI.Button(new Rect(10, 100, 100, 70), "Idle"))
            MakeIdle();
    }

    private void MakeAggressive()
    {
        Debug.Log("Aggressive");
        NpcObject npcObject = Selection.activeGameObject.GetComponent<NpcObject>();

        if (!npcObject)
        {
            Debug.Log("Object is not a npc");
            return;
        }

        EcsEntity npcEntity = npcObject.entity;

        if (npcEntity.Has<AggressiveState>())
        {
            Debug.Log("Entity's state is already aggressive");
            return;
        }

        if (npcEntity.Has<IdleState>())
        {
            npcEntity.Unset<IdleState>();
            npcEntity.Set<AggressiveState>();
        }
    }

    private void MakeIdle()
    {
        Debug.Log("Idle");
        NpcObject npcObject = Selection.activeGameObject.GetComponent<NpcObject>();

        if (!npcObject)
        {
            Debug.Log("Object is not a npc");
            return;
        }

        EcsEntity npcEntity = npcObject.entity;

        if (npcEntity.Has<IdleState>())
        {
            Debug.Log("Entity's state is already idle");
            return;
        }

        if (npcEntity.Has<AggressiveState>())
        {
            npcEntity.Unset<AggressiveState>();
            npcEntity.Set<IdleState>();
        }
    }
}
