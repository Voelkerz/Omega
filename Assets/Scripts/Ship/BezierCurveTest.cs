using UnityEditor;
using UnityEngine;

public class BezierCurveTest : MonoBehaviour {
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 startTangent;
    public Vector3 endTangent;
    public Color color;
    public Texture2D texture;
    public float width;

    // Start is called before the first frame update
    void Start() {
        Handles.DrawBezier(startPosition, endPosition, startTangent, endTangent, color, texture, width);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
