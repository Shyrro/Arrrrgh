using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameEnded = false;
    public float endDelay = 0.5f;
    public int lastScore = 0;
    string finalScoreTxtName = "FinalScore";
    public GameObject completeLevelUI;    

    public void CompleteLevel(){        
        completeLevelUI.transform.Find(finalScoreTxtName).GetComponent<Text>().text = FindObjectOfType<Score>().ScoreValue.text;
        completeLevelUI.SetActive(true);
    }

    public void GameOver() {
        if (!gameEnded) {
            gameEnded = true;
            lastScore = Convert.ToInt32(FindObjectOfType<Score>().ScoreValue.text);
            Debug.Log("Over : " + lastScore);

            Invoke("Restart", endDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}