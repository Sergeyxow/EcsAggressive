using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Vector3[] points;

    private LineRenderer lineRenderer;
    
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        points = new Vector3[transform.childCount];
        lineRenderer.positionCount = transform.childCount;

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 pos = transform.GetChild(i).position;
            points[i] = pos;
            lineRenderer.SetPosition(i, pos);
        }
    }
}
