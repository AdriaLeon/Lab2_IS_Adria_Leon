using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float gotPowerUpDestroyDelay;
    public float speedBost;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private powerUpSpawner powerUpSpawner;
    private Vector3 startPos;
    public float floatAmplitude = 0.25f; // how high it moves up/down
    public float floatFrequency = 1f;    // how fast it moves

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    public void SetSpawner(powerUpSpawner spawner)
    {
        powerUpSpawner = spawner;
    }
    private void OnTriggerEnter(Collider other)
    {
        hayMachine player = other.GetComponent<hayMachine>();
        if (player != null)
        {
            Debug.Log("Power-up collected by player!");
            player.IncreaseSpeed(new Vector3(speedBost, 0f, 0f));
            powerUpSpawner.RemovePowerFromList(gameObject);
            Destroy(gameObject, gotPowerUpDestroyDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float floatY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0, floatY, 0);
    }
}
