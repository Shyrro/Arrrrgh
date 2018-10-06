using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text ScoreValue;
    public Transform player;
	
	// Update is called once per frame
	void Update () {
        ScoreValue.text = player.position.z.ToString("0");
	}
}
