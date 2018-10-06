using UnityEngine;

public class CollisionDetection : MonoBehaviour {        

    void OnCollisionEnter(Collision collision)
    {
        //We check if we hit an obstacle 
        if (collision.collider.tag.Equals("Obstacle"))
        {            
            FindObjectOfType<GameManager>().GameOver();            
        }
    }


    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
