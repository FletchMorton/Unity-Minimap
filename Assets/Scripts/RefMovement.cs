using UnityEngine;

public class RefMovement : MonoBehaviour
{
    //Public Variables
    public Transform playerPos;
    public GameObject mapRatio;
    public Vector3 ratio;

    //Private Variables
    private Vector3 oldPlayerPos;
    private Vector3 camDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        //Set the map ratio
        ratio = mapRatio.GetComponent<MapRatio>().minimapRatio;
        
        //Calculate where the player reference is on screen with respect to the player
        camDisplacement = playerPos.position - transform.position;

        //Initialize player position
        oldPlayerPos = playerPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Variables
        var playerDis = playerPos.position - oldPlayerPos;

        //Align player icon on screen
        transform.position = playerPos.position - camDisplacement;

        //If the player moved, move the icon with respect to ratio scaling
        if(oldPlayerPos != playerPos.position) {
            transform.position += new Vector3(playerDis.x * ratio.x, playerDis.y * ratio.y, 0);
        }

        //Update positions
        oldPlayerPos = playerPos.position;
        camDisplacement = playerPos.position - transform.position;
        
    }

}
