using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnerType spawnType;
    public Vector3 forceDirection;
    public Vector3 forceVariance;
    public bool spawning = false;

    private float spawnTimer;
    private float curTimer;
    private bool hasDirection;
    private GameObject spawnObject;




    // Start is called before the first frame update
    void Start()
    {
        curTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawning)
        {
            if (curTimer > 0)
                curTimer -= Time.deltaTime;
            else
                Spawn();
        }

    }

    private void Spawn()
    {
        curTimer = spawnTimer;

        GameObject obj = Instantiate(spawnObject, this.transform.position, this.transform.rotation);
        
        if(hasDirection)
            obj.GetComponent<Rigidbody>().AddForce(VaryForce(forceDirection, forceVariance));
    }

    public void Init(float time)
    {
        spawnTimer = spawnType.spawnRate;
        spawnObject = spawnType.spawnObject;
        hasDirection = spawnType.hasDirection;

        if(spawnType.oneTimeSpawn)
        {
            Spawn();
        }
        else
        {
            curTimer += time;
            spawning = true;
        }
    }

    private Vector3 VaryForce(Vector3 _forceDir, Vector3 _variance)
    {
        Vector3 minRange = _forceDir - _variance;
        Vector3 maxRange = _forceDir + _variance;

        return new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
    }
}
