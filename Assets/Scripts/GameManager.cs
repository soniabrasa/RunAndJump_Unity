using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject barrierPrefab;

    List<GameObject> barrierPool;
    Vector3 barrierSpawnPoint;

    int totalBarriers;
    bool gameOver;

    public bool GameOver { get { return gameOver; } }

    void Awake()
    {
        instance = this;
        gameOver = false;
    }


    void Start()
    {
        barrierPool = new List<GameObject>();
        barrierSpawnPoint = new Vector3(30, 1, 0);
        totalBarriers = 0;

        StartCoroutine(CoSpawnBarrier());
    }


    void Update()
    {
    }

    void SpawnBarrier()
    {
        // Comprobando si hay alguna barrera en la lista
        if (barrierPool.Count > 0)
        {
            // Reutilizando la primera barrera de la lista
            GameObject barrier = barrierPool[0];

            // Inicializando las físicas de espaneo
            barrier.transform.position = barrierSpawnPoint;
            barrier.transform.rotation = Quaternion.identity;
            barrier.GetComponent<Rigidbody>().velocity = Vector3.zero;
            barrier.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            // Activando la barrera
            Debug.Log($"{gameObject.name}.SpawnBarrier {barrier.name}.SetActive(true)");

            barrier.SetActive(true);

            // Eliminando la primera barrera de la lista
            barrierPool.RemoveAt(0);
        }

        else
        {
            GameObject barrier = Instantiate(barrierPrefab, barrierSpawnPoint, Quaternion.identity);
            barrier.name = "Barrier_" + totalBarriers++;

            Debug.Log($"{gameObject.name}.SpawnBarrier {barrier.name}");

            // Este condador va de 2 en 2 y no sé pq
            totalBarriers++;
        }
    }

    public void DeactivateBarrier(GameObject barrier)
    {
        Debug.Log($"{gameObject.name}.DeactivateBarrier {barrier.name}");

        barrierPool.Add(barrier);
        barrier.SetActive(false);
    }

    public void SetGameOver()
    {
        gameOver = true;

        Debug.Log("*** GAME OVER ***");
    }

    IEnumerator CoSpawnBarrier()
    {
        while (true)
        {
            float seconds = 1f + Random.Range(0f, 3f);

            Debug.Log($"{gameObject.name}.CoSpawnBarrier in {seconds} s.");

            yield return new WaitForSeconds(seconds);

            SpawnBarrier();
        }
    }
}
