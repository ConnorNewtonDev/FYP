using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTimer;
    private float curTimer;
    public GameObject spawnObject;
    public bool hasDirection;

    public Vector3 forceDirection;
    public Vector3 forceVariance;

    public bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        curTimer = spawnTimer / 2;
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

        GameObject obj = Instantiate(spawnObject, this.transform.position, Quaternion.identity, null);
        Destroy(obj, 10f);
        if(hasDirection)
            obj.GetComponent<Rigidbody>().AddForce(VaryForce(forceDirection, forceVariance));
    }

    public void SetStartCurTimer(float time)
    {
        curTimer += time;
        spawning = true;
    }

    private Vector3 VaryForce(Vector3 _forceDir, Vector3 _variance)
    {
        Vector3 minRange = _forceDir - _variance;
        Vector3 maxRange = _forceDir + _variance;

        return new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
    }
}
