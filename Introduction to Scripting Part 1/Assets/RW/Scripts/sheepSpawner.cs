using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;

    private List<GameObject> sheepList = new List<GameObject>();

    private float speedIncreaseTimer = 0f;
    public float speedIncreaseInterval = 5f;
    public float speedIncreaseAmount = 2f;

    private float currentSheepSpeed = 10f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        speedIncreaseTimer += Time.deltaTime;

        if (speedIncreaseTimer >= speedIncreaseInterval)
        {
            currentSheepSpeed += speedIncreaseAmount;
            speedIncreaseTimer = 0f;
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            if (sheep != null)
            {
                Destroy(sheep);
            }
        }

        sheepList.Clear();
        Debug.Log("All sheep destroyed.");
    }
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);

        sheep sheepScript = sheep.GetComponent<sheep>();
        sheepScript.SetSpawner(this);
        sheepScript.SetSpeed(currentSheepSpeed);
    }
}
