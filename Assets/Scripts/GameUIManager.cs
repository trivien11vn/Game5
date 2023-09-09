using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUIManager : Singleton<GameUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public GameObject gameOver;
    public Text scoreText;

    public override void Awake(){
        MakeSingleton(false);
    }
    public void ShowGameGUI(bool isShow){
        if(gameGUI){
            gameGUI.SetActive(isShow);
        }
        if(homeGUI){
            homeGUI.SetActive(!isShow);
        }
    }
    public void ShowGameOver(bool isShow) {
        if(gameOver){
            gameOver.SetActive(isShow);
        }
    }
    public void UpdateScore(int score){
        if(scoreText){
            scoreText.text = "Score: "+score.ToString("00");
        }
    }
    public void Replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Home(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
