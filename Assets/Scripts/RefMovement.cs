using UnityEngine;

public class RefMovement : MonoBehaviour
{
    //Public Variables
    public Transform playerPos;
    public GameObject SpawnManager;
    public Vector3 ratio;

    //Private Variables
    private Vector3 oldPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize player position
        oldPlayerPos = playerPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Update ratio if UI scale changed
        ratio = SpawnManager.GetComponent<SpawnScript>().minimapRatio;

        //Calculat6e player displacement
        var playerDis = playerPos.position - oldPlayerPos;

        //If the player moved, move the icon with respect to ratio scaling
        if(oldPlayerPos != playerPos.position) {
            transform.position += new Vector3(playerDis.x * ratio.x, playerDis.y * ratio.y, 0);
        }

        //Update positions
        oldPlayerPos = playerPos.position;
        
    }

}
