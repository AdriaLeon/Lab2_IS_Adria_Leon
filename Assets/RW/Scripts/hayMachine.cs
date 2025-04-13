using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayMachine : MonoBehaviour
{
    public Vector3 translationSpeed;
    public float limitX;
    public GameObject hayBalePrefab;
    public Vector3 offset;
    public float shootInterval;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void checkAction()
    {
        if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x <= limitX) 
        {
            transform.Translate(translationSpeed * Time.deltaTime);
        }
        
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x >= -limitX) 
        {
            transform.Translate(translationSpeed * Time.deltaTime * -1);
        }

        updateShooting();
    }

    private void updateShooting()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            shootHay();
        }
    }
    private void shootHay()
    {
        Instantiate(hayBalePrefab, transform.position + offset, Quaternion.identity);
    }
    void Update()
    {
        checkAction();
    }
}
