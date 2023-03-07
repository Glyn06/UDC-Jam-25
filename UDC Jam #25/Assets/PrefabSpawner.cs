using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    public void SpawnPrefab(int quantity)
    {
        if (quantity > 0)
        {
            for (int i = 0; i < quantity; i++)
            {
                Quaternion rotation = new Quaternion(0, 0, Random.Range(0, 90), 0);
                Instantiate(prefabToSpawn, gameObject.transform.position, rotation);
            }
        }
    }

    public void SpawnPrefabRandomQuantity(int maxQuantity)
    {
        int quantity = Random.Range(1, maxQuantity);

        SpawnPrefab(quantity);
    }
}
