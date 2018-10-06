using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Vector3 offset = new Vector3(0, 5, -15);
    public Transform playerToFollow;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(transform.position.x, playerToFollow.position.y,playerToFollow.position.z) + offset;
	}
}
