using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public int highscore;
    public int score;

    public bool ingame = false;

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
        if (!ingame && (Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ingame = true;
            
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
        Debug.Log("Game Over");

        ingame = false;

        menuUi.gameObject.SetActive(true);
        ingameUi.gameObject.SetActive(false);

        if (score > highscore)
            SaveHighscore();

        score = 0;
    }

    private void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void SaveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public bool isIngame()
    {
        return this.ingame;
    }
}
