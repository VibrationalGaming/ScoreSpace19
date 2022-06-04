using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{

    private LineRenderer lr;

    void Awake()
    {
        lr = this.GetComponent<LineRenderer>();
    }

    public void Render(Vector3 start, Vector3 end)
    {
        lr.positionCount = 2;

        Vector3[] points = new Vector3[2];

        points[0] = start;
        points[1] = end;

        lr.SetPositions(points);
    }

    public void UnRender()
    {
        lr.positionCount = 0;
    }
}
