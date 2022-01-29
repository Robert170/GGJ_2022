using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private CharacterController controller;

    private float horizontalMovement = 0.0f;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public float playerVelocity;
    public float jumpForce;
    private bool jump = false;
    public LayerMask floor;
    public LayerMask blackSpace;
    public LayerMask whiteSpace;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void 
    Update() {

      horizontalMovement = Input.GetAxisRaw("Horizontal");

        //Vector2 direction = new Vector2(horizontalMovement, 0);
        
        if (Input.GetButtonDown("Jump")) {
        jump = true;
      }

    }

    private void 
    FixedUpdate() {

        //checkSpace();

        if (Physics2D.Raycast(boxCollider.bounds.center,
                             Vector2.down,
                             boxCollider.bounds.extents.y + 0.30f,
                             floor))
        {

            rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.fixedDeltaTime)
                               , ForceMode2D.Impulse);
        }

        Vector2 objectVelocity = new Vector2(horizontalMovement * 
                                             playerVelocity * Time.fixedDeltaTime, 
                                             rigidBody.velocity.y);

      rigidBody.velocity = objectVelocity;
      playerJump();



    }

    private void
    playerJump() { 

      if(true == jump) {

        if (Physics2D.Raycast(boxCollider.bounds.center, 
                              Vector2.down, 
                              boxCollider.bounds.extents.y + 0.30f,
                              floor)) {

          rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.fixedDeltaTime)
                             , ForceMode2D.Impulse);
        }
        jump = false;
      }
    }

    private void checkSpace()
    {
        
    }
}


