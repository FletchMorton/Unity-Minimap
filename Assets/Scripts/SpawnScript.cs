using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //Map References
    public Transform real_top_edge;
    public Transform real_bottom_edge;
    public Transform player;
    public Transform spawn;

    //Minimap References
    public RectTransform ref_top_edge;
    public RectTransform ref_bottom_edge;
    public RectTransform ref_player;

    //Variables
    public Vector3 minimapRatio;
    public Vector3 player_vector;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize positions
        player.position = spawn.position;
        ref_player.position = ref_bottom_edge.position;
        
        CalculateRatio();

        //Align player on minimap
        player_vector = player.position - real_bottom_edge.position;
        ref_player.position += new Vector3(player_vector.x * minimapRatio.x, player_vector.y * minimapRatio.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Recalculate map ratio in case UI scale was changed
        CalculateRatio();
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