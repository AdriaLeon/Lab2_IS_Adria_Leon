using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject powerUpPrfeab;
    public List<Transform> powerUpSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;

    private List<GameObject> powerUpList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {

    }

    public void RemovePowerFromList(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnPowerUp();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnPowerUp()
    {
        Vector3 randomPosition = powerUpSpawnPositions[Random.Range(0, powerUpSpawnPositions.Count)].position;
        GameObject powerUp = Instantiate(powerUpPrfeab, randomPosition, powerUpPrfeab.transform.rotation);
        powerUpList.Add(powerUp);

        powerUp powerUpScript = powerUp.GetComponent<powerUp>();
        powerUpScript.SetSpawner(this);
 
    }
}
