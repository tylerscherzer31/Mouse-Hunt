using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject NewHighScore;
    public GameObject HighScore;
    public Text currentScore;
    public Text gameOverScore;
    public Text[] scores;
    public InputField nameInput;
    private Leaderboard leaderboard;
    private float lowestScore = 0;
    
    private void Start()
    {
        GetHighScores();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if(GameState.gameScore > lowestScore)
            {
                NewHighScore.SetActive(true);
            }
            gameOverScore.text = GameState.gameScore.ToString("F2") + " meters";
            currentScore.text = GameState.gameScore.ToString("F2") + " meters";
        }
        
    }
    public void PlayGame()
    {
        GameState.mode = GameState.GameMode.idle;
        GameState.gameScore = 0f;
        GameState.level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        HighScore.SetActive(true);
    }
    public void Submit()
    {
        string name = nameInput.text;
        Entry entry = new Entry();
        entry.name = name;
        entry.score = GameState.gameScore;
        leaderboard.entries.Add(entry);
        leaderboard.SortList();
        PlayerPrefs.SetString("highScore", JsonUtility.ToJson(leaderboard));
        GetHighScores();
        NewHighScore.SetActive(false);
        HighScore.SetActive(true);
    }
    public void CloseHighScores()
    {
        HighScore.SetActive(false);
    }

    public void PlayAgain()
    {
        GameState.mode = GameState.GameMode.idle;
        GameState.gameScore = 0f;
        GameState.level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }
    private void GetHighScores()
    {
        string highScoresJson = PlayerPrefs.GetString("highScore", "");
        if(highScoresJson == "")
        {
            leaderboard = new Leaderboard();
            for(int i = 0;i < scores.Length; i++)
            {
                scores[i].text = (i + 1).ToString() + ":  0m     ***";
            }
        }
        else
        {
            leaderboard = JsonUtility.FromJson<Leaderboard>(highScoresJson);
            for (int i = 0; i < scores.Length; i++)
            {
                if(leaderboard.entries.Count > i)
                {
                    lowestScore = leaderboard.entries[i].score;
                    scores[i].text = (i + 1).ToString() + ":  " + leaderboard.entries[i].score.ToString("F2") + "m  " + leaderboard.entries[i].name;
                }
                else
                {
                    lowestScore = 0;
                    scores[i].text = (i + 1).ToString() + ":  0m     ***";
                }
                
            }
        }
    }
}
