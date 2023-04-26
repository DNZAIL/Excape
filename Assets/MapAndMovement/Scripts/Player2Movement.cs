using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    Rigidbody2D rb;

    private BoxCollider2D coll;

    [SerializeField]
    private LayerMask jumpableGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float dirX = Input.GetAxis("P2_Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        /*
        if(this.gameObject.tag == "Player 2")
        {
            float dirX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        }
        */

        //if(Input.GetButtonDown("Jump") && isGrounded())
        if(Input.GetKeyDown("up") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
