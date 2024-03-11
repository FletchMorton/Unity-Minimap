using UnityEngine;

public class MapRatio : MonoBehaviour
{

    //Map References
    public Transform real_top_edge;
    public Transform real_bottom_edge;
    public Transform ref_top_edge;
    public Transform ref_bottom_edge;

    //Variables
    public Vector3 minimapRatio;


    // Start is called before the first frame update
    void Start()
    {
        CalculateRatio();
    }

    // Update is called once per frame
    void Update()
    {
        //...
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
