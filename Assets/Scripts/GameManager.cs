using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject player,scoreText,highScoreText,highScoreTextEndGame,startGamePanel,restartGamePanel,gameControlPanel;

    public float distance = 210f;


    void Start() {
        if(PlayerPrefs.GetFloat("highScore",0)!=0){
            highScoreText.SetActive(true);
            highScoreText.GetComponent<Text>().text = "High Score\n"+PlayerPrefs.GetFloat("highScore",0).ToString("00");
        }
    }
    public void StartGame(){
        player.GetComponent<PlayerMovement>().enabled=true;
        scoreText.SetActive(true);
        startGamePanel.SetActive(false);
        gameControlPanel.SetActive(true);
    }
 
    public void EndGame(){

        scoreText.SetActive(false);
        restartGamePanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled=false;
        highScoreTextEndGame.SetActive(true);
        gameControlPanel.SetActive(false);
        float score = (int)(player.transform.position.z/2);
        if(PlayerPrefs.GetFloat("highScore",0)<score){
            PlayerPrefs.SetFloat("highScore",score);
            Debug.Log(score);
            PlayerPrefs.Save();
            highScoreTextEndGame.GetComponent<Text>().text = "High Score\n"+score;
        }else{
            highScoreTextEndGame.GetComponent<Text>().text = "Your Score\n"+score;
        }
        
       
    }

    public void RestartGame(){
       SceneManager.LoadScene("Level0");
    }
}
