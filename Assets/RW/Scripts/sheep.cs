using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private sheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void SetSpawner(sheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        Debug.Log("Dropping the sheep!");
        runSpeed = 5;   
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay) 
            {
            Destroy(other.gameObject);
            HitByHay();
            } 
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }

    }
    public void SetSpeed(float speed)
    {
        runSpeed = speed;
    }
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * runSpeed * Time.deltaTime);
    }
    
}
