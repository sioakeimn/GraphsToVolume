using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelSpaceManager : MonoBehaviour {

    public int voxelSpaceSizeX;
    public int voxelSpaceSizeZ;
    public int voxelSpaceSizeY;

    public float voxelSize;

    public Voxel voxel;

    public List<Voxel> voxels;

    private void Awake()
    {
        voxels = new List<Voxel>();
        voxel.gameObject.SetActive(false);
    }

    public void CreateVoxelSpace()
    {
        voxel.gameObject.SetActive(true);
        voxel.transform.localScale = new Vector3(voxelSize, voxelSize, voxelSize);

        //Set the size of the voxel space according to the dimensions of the generated lines
        CreateSpace();
    }

    private void CreateSpace()
    {

        for (int i = 0; i < voxelSpaceSizeX; i++)
        {
            for (int j = 0; j < voxelSpaceSizeY; j++)
            {
                for (int k = 0; k < voxelSpaceSizeZ; k++)
                {
                    voxels.Add(CreateVoxel(i, j, k));
                }
            }
        }
        voxel.gameObject.SetActive(false);
    }

    private Voxel CreateVoxel(int x, int y, int z)
    {
        Voxel createdVoxel = GameObject.Instantiate(voxel, new Vector3(x, y, z) * voxelSize, Quaternion.identity, this.transform).GetComponent<Voxel>();
        return createdVoxel;
    }

    public void FindWalls()
    {
        foreach (Voxel voxel in voxels)
        {
            List<Voxel> neighboors = new List<Voxel>();

            //Only for the ones that are room space find neighboors
            if (voxel.isRoomSpace == true)
            {
                neighboors = voxel.GetNeighbours();
                //And make them walls
                foreach (Voxel neighboor in neighboors)
                {
                    if (neighboor.isRoomSpace == false && neighboor.isWall == false)
                    {
                        neighboor.MakeWall();
                    }
                }
            }
        }
        foreach (Voxel voxel in voxels)
        {
            if (voxel.isRoomSpace == false && voxel.isWall == false)
            {
                voxel.MakeInvisible();
            }
        }

    }

}
