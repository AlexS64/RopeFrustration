using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    private int highscore;
    private int score;

    private bool ingame = false;

    public Canvas menuUi;
    public Canvas ingameUi;

    public Text highscoreTxt;
    public Text scoreTxt;

    void Start()
    {
        ingameUi.gameObject.SetActive(false);
        LoadHighscore();

        highscoreTxt.GetComponent<Text>().text = "Highscore: " + highscore;
    }
    
    public void Update()
    {
        if (!ingame && (Input.touchCount > 0))
        {
            ingame = true;

            score = 0;
            scoreTxt.GetComponent<Text>().text = score.ToString();

            menuUi.gameObject.SetActive(false);
            ingameUi.gameObject.SetActive(true);
        }
        
    }

    public void AddHighscore()
    {
        score++;
        scoreTxt.GetComponent<Text>().text = score.ToString();
    }

    public void GameOver()
    {
        ingame = false;
        menuUi.gameObject.SetActive(true);
        ingameUi.gameObject.SetActive(false);
        if (score > highscore)
            SaveHighscore();
    }

    private void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void SaveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }
}
