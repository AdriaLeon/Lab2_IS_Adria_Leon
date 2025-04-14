using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Instance;
    [HideInInspector]
    public int sheepSaved;
    [HideInInspector]
    public int sheepDropped;
    public int sheepDroppedBeforeGameOver;
    public sheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }
    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();

    }
    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        
    }
}
