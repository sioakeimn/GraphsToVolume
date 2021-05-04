using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public VoxelSpaceManager voxelSpaceManager;
    public GraphManager graphManager;

    public bool voxelSpaceCreated;

    [ContextMenu("CreateVoxelSpace")]
    public void CreateVoxelSpace()
    {
        if (voxelSpaceCreated == false)
        {
            voxelSpaceCreated = true;
            voxelSpaceManager.CreateVoxelSpace();
        }
    }

    public void ToggleVoxelSpace()
    {
        if (voxelSpaceManager.gameObject.activeInHierarchy == true)
        {
            voxelSpaceManager.gameObject.SetActive(false);
        }
        else
        {
            voxelSpaceManager.gameObject.SetActive(true);
        }
    }

    public void CreateGraph()
    {
        graphManager.ActivateVertices();
    }

    public void CreateCylinders()
    {
        graphManager.ActivateCylinders();
    }

    public void ToggleGraph()
    {
        if (graphManager.gameObject.activeInHierarchy == true)
        {
            graphManager.gameObject.SetActive(false);
        }
        else
        {
            graphManager.gameObject.SetActive(true);
        }
    }

    public void Calculate()
    {
        voxelSpaceManager.FindWalls();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
