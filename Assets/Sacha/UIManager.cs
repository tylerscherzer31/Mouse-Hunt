using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject beginningScreen;
    public Text score;
   
    void Start()
    {
        
    }

    void Update()
    {
        if (GameState.mode == GameState.GameMode.idle && Input.GetMouseButtonDown(0))
        {
            beginningScreen.SetActive(false);
            GameState.mode = GameState.GameMode.playing;
        }

        if (GameState.mode == GameState.GameMode.playing)
        {
            GameState.gameScore += Time.deltaTime;
            score.text = "Score: " + GameState.gameScore.ToString("F2") + " meters";
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
