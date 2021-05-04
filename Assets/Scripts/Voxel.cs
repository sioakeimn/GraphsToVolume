using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour {

    public GameObject model;
    public GameObject wall;

    public List<Voxel> neighboors = new List<Voxel>();

    public bool isRoomSpace;
    public bool isWall;

    private void Awake()
    {
        neighboors = new List<Voxel>();
        wall.SetActive(false);
        isRoomSpace = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Cylinder")
        {
            MakeInvisible();
        }
    }

    public void MakeInvisible()
    {
        isRoomSpace = true;
        model.SetActive(false);
    }

    public void MakeWall()
    {
        isWall = true;
        model.SetActive(false);
        wall.SetActive(true);
    }

    public List<Voxel> GetNeighboors()
    {
        neighboors.AddRange(GetNeighboorFromDirection(transform.TransformDirection(Vector3.forward)));
        neighboors.AddRange(GetNeighboorFromDirection(-transform.TransformDirection(Vector3.forward)));
        neighboors.AddRange(GetNeighboorFromDirection(transform.TransformDirection(Vector3.right)));
        neighboors.AddRange(GetNeighboorFromDirection(-transform.TransformDirection(Vector3.right)));
        neighboors.AddRange(GetNeighboorFromDirection(transform.TransformDirection(Vector3.up)));
        neighboors.AddRange(GetNeighboorFromDirection(-transform.TransformDirection(Vector3.up)));

        return neighboors;
    }

    private List<Voxel> GetNeighboorFromDirection(Vector3 direction)
    {
        RaycastHit hit;
        Voxel hitVoxelDepth1;
        Voxel hitVoxelDepth2;
        List<Voxel> hitVoxels = new List<Voxel>();

        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity))
        {
            hitVoxelDepth1 = hit.transform.GetComponent<Voxel>();
            if (hitVoxelDepth1 != null)
            {
                hitVoxels.Add(hitVoxelDepth1);
                hitVoxelDepth1.gameObject.SetActive(false);
                if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity))
                {
                    hitVoxelDepth2 = hit.transform.GetComponent<Voxel>();
                    if (hitVoxelDepth2 != null)
                    {
                        hitVoxels.Add(hitVoxelDepth2);
                        hitVoxelDepth1.gameObject.SetActive(true);
                    }
                }
            }

        }
        return hitVoxels;
    }
}
