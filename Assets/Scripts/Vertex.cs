using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{

    public enum TYPE { DINING, KITCHEN }

    public TYPE roomType;

    public float length;
    public float width;

    public GameObject cylinder;
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        cylinder.SetActive(false);
    }

    public void ActivateLine()
    {
        float xAngle = Random.Range(70, 110);
        float yAngle = Random.Range(-180, 181);
        cylinder.transform.localPosition = Vector3.zero;
        cylinder.transform.localEulerAngles = new Vector3(xAngle, yAngle, 0.0f);
        cylinder.transform.localScale = new Vector3(width, length * 0.45f, width);

        Vector3 pointA = new Vector3(0.0f, length / 2, 0.0f) + this.transform.position;
        Vector3 pointB = new Vector3(0.0f, -length / 2, 0.0f) + this.transform.position;
        pointA = RotatePointAroundPivot(pointA, transform.position, new Vector3(xAngle, yAngle, 0.0f));
        pointB = RotatePointAroundPivot(pointB, transform.position, new Vector3(xAngle, yAngle, 0.0f));
        lineRenderer.SetPosition(0, pointA);
        lineRenderer.SetPosition(1, pointB);
    }

    public void ActivateCylinder()
    {
        cylinder.SetActive(true);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
}
