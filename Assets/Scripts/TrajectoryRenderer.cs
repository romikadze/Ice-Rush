using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {   Vector3[] points = new Vector3[5];
        lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time;
        }

        lineRenderer.SetPositions(points);
    }

    public void hideTrajectory()
    {
        lineRenderer.positionCount = 0;
    }

}
