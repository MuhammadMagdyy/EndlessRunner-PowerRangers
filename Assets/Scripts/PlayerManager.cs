using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isPaused;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        gameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();

            }
            else
            {
                Resume();
            }
        }


    }

    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        /*FindObjectOfType<AudioManager>().PlaySound("credits");
        AudioListener.volume = 0.0f;*/

        Time.timeScale = 0;
    }
    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
      /*  AudioListener.volume = 1.0f;*/
        Time.timeScale = 1;
    }
}
