using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translator : MonoBehaviour
{
    
    public Vector3 translationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translationSpeed * Time.deltaTime, Space.World);

        //Destroy the Hay when it leaves the game boundaries
        if (transform.position.z >= 100)
        {
            Destroy(gameObject);
        }
    }
    
    
}
