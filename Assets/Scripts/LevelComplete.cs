using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	// Use this for initialization
	public void LoadNextLevel(){
		//TODO : add +1 when other scenes will be available
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
