using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Spawn Type", menuName = "Spawner/Spawn Type")]
public class SpawnerType : ScriptableObject
{
    public GameObject spawnObject;
    public float spawnRate;
    public bool hasDirection;
    public bool oneTimeSpawn;
}
