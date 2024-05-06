using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    private int minX = -11;
    private int maxX = 11;
    public float lineWidth = 0.1f;
    public Material lineMaterial;
    public CountdownTimer timer;

    private GameObject lineObject;

    public int lineCountLimit = 10; // Set the line count limit here

    private int lineCount = 0;

    public void GenerateLine(int m, int b)
    {
        if (lineCount >= lineCountLimit)
        {
            DeleteLine(); // Delete the oldest line if the limit is reached
        }

        lineObject = new GameObject("Line");
        lineObject.transform.SetParent(transform);

        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        

        int resolution = maxX - minX + 1;
        lineRenderer.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float x = i + minX;
            float y = m * x + b;
            Vector3 point = new Vector3(x, y, 0f);
           // ClampPointToBounds(ref point);
            lineRenderer.SetPosition(i, point);
        }

        EdgeCollider2D edgeCollider = lineObject.AddComponent<EdgeCollider2D>();
        Vector2[] colliderPoints = new Vector2[resolution];
        for (int i = 0; i < resolution; i++)
        {
            colliderPoints[i] = lineRenderer.GetPosition(i);
        }
        edgeCollider.points = colliderPoints;

        Debug.Log($"Line Generated: y = {m}x + {b}");

        lineCount++;
    }





    public void DeleteLine()
    {
        if (lineCount > 0 && lineObject != null)
        {
            Destroy(lineObject);
            lineObject = null;
            lineCount--;
        }
    }


}