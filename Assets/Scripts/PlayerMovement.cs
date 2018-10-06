using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    int lane = 2;
    float sideSpeed = 3500f;
    float forwardSpeed = 5500f;
    //The purpose of this variable is to lock the players movement until the last one is finished
    bool controlLocked = false;
    //This distance represents the step we move by sideways
    float distance = 10f;
    //Stores the X position of the last destination entered
    float lastDestinationX;
    Vector3 desiredVelocity;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        lastDestinationX = rb.transform.position.x;
        desiredVelocity = Vector3.zero;
    }

    void Update() {

        //Check if we reached the position wanted
        float acceptableMaxDistDiff = 1f;

        if (PositionIsReached(acceptableMaxDistDiff)) {
            desiredVelocity = Vector3.zero;
            controlLocked = false;
        }

        #region Checking Inputs
        //Checking for keydown so as to get the input only once per Update
        //TODO: This has to be adapted to mobile by a "Swap" mecanic
        //We also check for the lanes so as to stay in the defined lanes
        //Check if controls are not locks so that they do not interfer with each other unless the last action is finished      
        if ((Input.GetKeyDown(moveRight)) && (lane < 3) && (!controlLocked)) {
            //Position we want to reach
            Vector3 newPos = rb.transform.position + Vector3.right * distance;

            //Changing the players Velocity so that he moves smoothly towards the desired direction.
            ChangePlayerVelocity(newPos);

            //Since we moved to the right, increment lane number
            lane++;
        }

        if ((Input.GetKeyDown(moveLeft)) && (lane > 1) && (!controlLocked)) {
            //Position we want to reach
            Vector3 newPos = rb.transform.position - Vector3.right * distance;

            ChangePlayerVelocity(newPos);

            //Since we moved to the left, decrement lane number
            lane--;
        }

        #endregion

    }

    void FixedUpdate() {
        //Changing the velocity of the player based on the calculations made before
        rb.velocity = desiredVelocity * Time.deltaTime + Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Changing the velocity of the player so that he goes in the direction of the specified position.    
    /// </summary>
    /// <param name="newPos">Position wanted</param>
    void ChangePlayerVelocity(Vector3 newPos) {
        //Lock the control so that future inputs from user do not interfer
        controlLocked = true;

        //Calculate the direction our player should follow based on the position we want to reach.            
        Vector3 dir = (newPos - rb.transform.position).normalized * sideSpeed;

        //Save the last destination entry wanted so as to check for the distance later.
        lastDestinationX = newPos.x;

        //Apply the velocity vector
        desiredVelocity = dir;
    }

    /// <summary>
    ///Calculates the distance between the point we need to reach and our current position.
    ///We check for a threshold, if the X position is under that threshold, we reached the position wanted.
    ///We can't check for 0 though because if you take the refresh time and the speed into consideration, reaching 0 will rarely happen.
    ///This way it will reach a certain point X, which will always be the same.
    /// </summary>
    /// <param name="threshold"></param>
    bool PositionIsReached(float threshold) {
        return Vector3.Distance(Vector3.right * lastDestinationX, Vector3.right * rb.position.x) < threshold;
    }
}