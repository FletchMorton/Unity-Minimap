using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Variables
    public Rigidbody2D body;
    public AudioSource footsteps;
    public LayerMask interactable;
    public float speed;

    //Private Variables
    private Animator animator;
    private Vector2 input;


    //When object loaded in
    private void Awake()
    {
        //Animate the player
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Positions the user on start
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the Player
        Move();

        //Check for interaction
        Interact();
    }

    //Move the player and animate the movement
    void Move()
    {
        //Get input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        //Update animation variables and play audio
        if(input != Vector2.zero) {
        
            footsteps.enabled = true;
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            animator.SetBool("isMoving", true);
        
        } else {
        
            footsteps.enabled = false;
            animator.SetBool("isMoving", false);
        
        }

        body.velocity = input * speed;
    }

    //Check if the player is trying to interact with something
    void Interact()
    {
        //Set player's interaction radius
        var facingDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var collider = Physics2D.OverlapCircle(transform.position + facingDirection, 0.2f, interactable);
        
        //Check for interactions
        if(collider != null) {
            if(Input.GetKeyDown(KeyCode.Z)) Debug.Log("MOOMOOMOOMOOMOOMOOMOOMOOMOO");
        }
    }

}
