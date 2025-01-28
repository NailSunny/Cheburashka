using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pausePanel;
    public bool IsPause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;

            if (!IsPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        IsPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        IsPause = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
