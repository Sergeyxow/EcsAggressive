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
        npcEntity.Set<SwitchToAggressiveFlag>();
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
        npcEntity.Set<SwitchToIdleFlag>();
    }
}
