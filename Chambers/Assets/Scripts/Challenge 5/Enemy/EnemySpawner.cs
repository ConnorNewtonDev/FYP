using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    private Transform path;
    public bool isSpawning = false;
    // Start is called before the first frame update
    public List<Transform> nodes = new List<Transform>();
    public List<SpawnListItem> spawns = new List<SpawnListItem>(15);
    public GameObject enemyPrefab;
    private GameObject spawnParent;
    private float spawnDelay = 3;
    private Vector3 spawnPoint;
    private PlayerData pData;
    public int remainingEnemies;
    
    void Start()
    {
        path = GameObject.Find("Path").transform;
        spawnParent = GameObject.Find("Enemies");
        pData = FindObjectOfType<PlayerData>();
        for(int i = 0; i < path.childCount; i++)
        {
            nodes.Add(path.GetChild(i).transform);
        }
        spawnPoint = new Vector3(nodes[0].transform.position.x, 1.5f, nodes[0].transform.position.z);

        remainingEnemies = spawns.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawning)
        {
            if(spawnDelay  <=0)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint, nodes[0].transform.rotation, spawnParent.transform);
                enemy.GetComponent<Enemy>().Spawned(spawns[0].Data, nodes.ToArray());
                spawns.RemoveAt(0);
                enemy.GetComponent<Enemy>().deathEvent += pData.OnEnemyKilled;
                enemy.GetComponent<Enemy>().deathEvent += EnemyDeathEvent;
                
                if(spawns.Count == 0)
                {
                    enemy.GetComponent<Enemy>().isLastEnemy = true;
                    ToggleSpawning();
                }

                else
                    spawnDelay = spawns[0].spawnDelay;

            }
            else
            {
                spawnDelay -= Time.deltaTime;

            }
        }
    }

    private void EnemyDeathEvent(int val, GameObject obj)
    {
        remainingEnemies -= 1;

        if(remainingEnemies == 0)
        {
            FindObjectOfType<GameManager>().FinishedLevel(6, true);
        }


    }

    public void StartSpawning()
    {
        isSpawning = true;
    }
    public void ToggleSpawning()
    {
        isSpawning = !isSpawning;
    }

[System.Serializable]
    public struct SpawnListItem
    {
        public EnemyData Data;
        public float spawnDelay;
    }
}
