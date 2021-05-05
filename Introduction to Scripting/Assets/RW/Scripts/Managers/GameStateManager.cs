using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    [HideInInspector]
    public int sheepSpeedIncrease;

    [HideInInspector]
    public int sheepNumberSpawnPoints;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        sheepNumberSpawnPoints = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();

        if (sheepSaved % 5 == 0)
        {
            sheepSpeedIncrease++;

            if (sheepSaved % 10 == 0 && sheepNumberSpawnPoints < 5)
                sheepNumberSpawnPoints++;
        }
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep();

        if (SaveBestScore.bestScore < sheepSaved)
            SaveBestScore.bestScore = sheepSaved;

        UIManager.Instance.ShowGameOverWindow();
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
}
