using System.Collections.Generic;
using UnityEngine;

public class MovementCurve : MonoBehaviour {
    public int plotPoints = 20; // list will be +1, since [0] is the starting point
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start() {
        // initialize the line
        //lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 21;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
    }

    // Update is called once per frame
    void Update() {
        List<Vector2> plotList = PlotMovePoints(45, 2);
        for (int i=0; i < plotList.Count; i++) {
            lineRenderer.SetPosition(i, plotList[i]);
        }
    }

    public List<Vector2> PlotMovePoints(float angle, float distance) {
        List<Vector2> plot = new List<Vector2>(plotPoints + 1);
        Vector2 pos = transform.position;
        Vector2 fwd = transform.up;
        plot.Add(pos); // start the curve at the startingPoint
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle / plotPoints);
        
        float distancePerStep = distance / plotPoints;

        for (int i = 0; i < plotPoints; i++) {
            fwd = (rotation * fwd).normalized;
            pos += fwd * distancePerStep;
            plot.Add(pos);
            Debug.Log("fwd: " + fwd + " -------- pos: " + pos);
        }
        return plot;
    }
}
