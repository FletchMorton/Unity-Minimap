using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //Map References
    public Transform real_top_edge;
    public Transform real_bottom_edge;
    public Transform player;
    public Transform spawn;

    //Minimap References
    public Transform ref_top_edge;
    public Transform ref_bottom_edge;
    public Transform ref_player;

    //Variables
    public Vector3 minimapRatio;
    public Vector3 bottom_distance;
    public Vector3 top_distance;
    public Vector3 player_vector;


    // Start is called before the first frame update
    void Start()
    {
        CalculateRatio();

        //Get distacne vectors to trackers
        bottom_distance = player.position - ref_bottom_edge.position;
        top_distance = player.position - ref_top_edge.position;

        //Reposition player
        player.position = spawn.position;

        //Reposition minimap
        ref_bottom_edge.position = player.position - bottom_distance;
        ref_top_edge.position = player.position - top_distance;

        //Reposition player pointer
        player_vector = player.position - real_bottom_edge.position;
        ref_player.position = ref_bottom_edge.position + new Vector3(player_vector.x * minimapRatio.x, player_vector.y * minimapRatio.y, 0);


    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void CalculateRatio()
    {
        //Calculate minimap distance
        Vector3 virtualDistance = new Vector3(ref_top_edge.position.x - ref_bottom_edge.position.x, ref_top_edge.position.y - ref_bottom_edge.position.y, 0);

        //Calculate real distance
        Vector3 realDistance = new Vector3(real_top_edge.position.x - real_bottom_edge.position.x, real_top_edge.position.y - real_bottom_edge.position.y, 0);

        //Set ratio
        minimapRatio = new Vector3(virtualDistance.x / realDistance.x, virtualDistance.y / realDistance.y, 0);
    }

}