using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{

    public List<Vertex> vertices;

    public void ActivateVertices()
    {
        foreach (Vertex vertex in vertices)
        {
            vertex.ActivateLine();
        }
    }
    public void ActivateCylinders()
    {
        foreach (Vertex vertex in vertices)
        {
            vertex.ActivateCylinder();
        }
    }
}