using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text sheepSavedText;
    public Text sheepDroppedText;
    public GameObject gameOverWindow; 
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    
    public void UpdateSheepSaved()
    {
        Debug.Log("UpdateSheepSaved called");
        sheepSavedText.text = scoreManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        Debug.Log("UpdateSheepDropped called");
        sheepDroppedText.text = scoreManager.Instance.sheepDropped.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
