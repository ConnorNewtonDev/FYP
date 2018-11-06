using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeOne : MonoBehaviour
{
    public GameObject path;
    public GameObject dissolvePath;
    public GameObject pathParent;
    public GameObject dissolveParent;

    private int[,] pathLayout;
    public bool _hardMode;
    public Transform spawnLoc;

    // Start is called before the first frame update
    void Start()
    {
        if (_hardMode)
            LoadHardPath();
        else
            LoadNormalPath();


        SpawnPath();
    }

    private void SpawnPath()
    {
        for (int i = 0; i < pathLayout.GetLength(1); i++)
        {
            for (int j = 0; j < pathLayout.GetLength(0); j++)
            {
                if (pathLayout[j, i] == 0)
                    SpawnPrefab(dissolvePath, ref i, ref j);
                else
                    SpawnPrefab(path, ref i, ref j);
            }
        }
    }

    private void SpawnPrefab(GameObject obj, ref int i, ref int j)
    {
        Vector3 objPos = spawnLoc.position;


        objPos = new Vector3((spawnLoc.position.x + (obj.transform.localScale.x * i)) ,
            spawnLoc.position.y,
            (spawnLoc.position.z + (obj.transform.localScale.z * j))
            );

        if (obj == dissolvePath)
            Instantiate(obj, objPos, Quaternion.identity, dissolveParent.transform);
        else
            Instantiate(obj, objPos, Quaternion.identity, pathParent.transform);
    }
    
    private void LoadNormalPath()
    {

        pathLayout = new int[,]
                    { { 0, 0, 0, 1, 1, 1, 0 },
                      { 0, 0, 1, 1, 0, 1, 0 },
                      { 0, 0, 1, 0, 0, 1, 1 },
                      { 1, 1, 1, 0, 0, 0, 0 },
                      { 1, 0, 0, 0, 0, 0, 0 } };


    }

    private void LoadHardPath()
    {
        pathLayout = new int[,]
                    {
                      { 0, 0, 0, 1, 1, 1, 0 },
                      { 0, 0, 1, 1, 0, 1, 0 },
                      { 0, 0, 1, 0, 0, 1, 1 },
                      { 0, 0, 1, 1, 0, 0, 0 },
                      { 0, 0, 0, 1, 0, 0, 0 },
                      { 1, 1, 0, 1, 0, 0, 0 },
                      { 0, 1, 0, 1, 1, 0, 0 },
                      { 0, 1, 0, 0, 1, 0, 0 },
                      { 0, 1, 1, 1, 1, 0, 0 } };
    }

}
