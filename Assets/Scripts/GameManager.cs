using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject barrierPrefab;

    Vector3 barrierSpawnPoint;

    int totalBarriers;



    void Start()
    {
        barrierSpawnPoint = new Vector3(30, 1, 0);
        totalBarriers = 0;

        StartCoroutine(CoSpawnBarrier());
    }


    void Update()
    {
    }

    void SpawnBarrier()
    {
        GameObject barrier = Instantiate(barrierPrefab, barrierSpawnPoint, Quaternion.identity);
        barrier.name = "Barrier_" + totalBarriers++;
        totalBarriers++;
    }

    IEnumerator CoSpawnBarrier()
    {
        while (true)
        {
            float seconds = 1f + Random.Range(0f, 3f);

            yield return new WaitForSeconds(seconds);

            SpawnBarrier();
        }
    }
}
