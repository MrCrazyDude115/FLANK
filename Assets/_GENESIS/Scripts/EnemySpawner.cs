using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject spawnerLeft;
    public GameObject spawnerRight;
    public float minSpawnRate = 0.75f;
    public float maxSpawnRate = 2;

    float timer = 0;
    float nextSpawnTime = 0;

    Vector2 spawnerLeftPos;
    Vector2 spawnerRightPos;


    void Start()
    {
        spawnerLeftPos = spawnerLeft.transform.position;
        spawnerRightPos = spawnerRight.transform.position;

        //PickNextSpawnTime();
    }

    void Update()
    {
        if (LogicManager.instance.GetGameStartedStatus() && PlayerController.instance.GetPlayerIsAlive())
        {
            timer += Time.deltaTime;

            if (timer >= nextSpawnTime)
            {
                SpawnEnemy();
                timer = 0f;
                PickNextSpawnTime();
            }
        }
    }

    void PickNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
    }


    void SpawnEnemy()
    {

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject chosenPrefab = enemyPrefabs[index];

        Vector2 spawnPos;

        if (Random.value < 0.5f)
        {
            spawnPos = spawnerLeftPos;
        }
        else
        {
            spawnPos = spawnerRightPos;
        }

        Instantiate(chosenPrefab, spawnPos, Quaternion.identity);
    }
}
