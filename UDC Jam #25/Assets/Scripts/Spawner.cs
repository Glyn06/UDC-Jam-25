using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private float minimunTime = 0.5f;
    [SerializeField] private float maximunTime = 0.5f;
    [SerializeField] private Vector3 spawnArea = new Vector3(1, 1, 0);

    private float spawnTime;
    private float timer;

    private void Awake()
    {
        spawnTime = RandomizeTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0;
            spawnTime = RandomizeTime();

            SpawnRandomObject();
        }
    }

    private void SpawnRandomObject()
    {
        int randomIndex = UnityEngine.Random.Range(0, objects.Count);
        float randomX = UnityEngine.Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2);
        float randomY = UnityEngine.Random.Range(transform.position.y - spawnArea.y / 2, transform.position.y + spawnArea.y / 2);

        Vector2 pos = new Vector2(randomX, randomY);

        Enemy enemy = Instantiate(objects[randomIndex], pos, Quaternion.identity).GetComponent<Enemy>();

        if (enemy != null)
            enemy.SetPlayerObj(playerObj);
    }

    private float RandomizeTime()
    {
        return UnityEngine.Random.Range(minimunTime, maximunTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gameObject.transform.position, spawnArea);
    }
}
