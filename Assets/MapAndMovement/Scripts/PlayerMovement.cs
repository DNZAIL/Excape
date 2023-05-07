using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//GIRL
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private Collider2D coll;

    [SerializeField]
    private LayerMask jumpableGround;

    //animation variables
    Vector2 movement;
    public Animator animator;
    float lastMoveX;
    float lastMoveY;
    float curSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float dirX = Input.GetAxis("P1_Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        //if(Input.GetButtonDown("Jump") && isGrounded())
        if(Input.GetKeyDown("w") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }

        //for animation controls
        movement.x = Input.GetAxisRaw("P1_Horizontal");
        movement.y = Input.GetAxisRaw("P1_Vertical");

        animationControls();
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    void animationControls()
    {
        curSpeed = movement.sqrMagnitude;
        if(curSpeed > 0.01)
        {
            lastMoveX = movement.x;
            lastMoveY = movement.y;
        }
        
        
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", lastMoveX);
        animator.SetFloat("Vertical", lastMoveY);
        
        animator.SetFloat("Speed", curSpeed);
    }
}
