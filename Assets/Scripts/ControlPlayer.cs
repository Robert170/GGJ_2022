using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private float horizontalMovement = 0.0f;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public float playerVelocity;
    public float jumpForce;
    private bool jump = false;
    public LayerMask floor;

    // Update is called once per frame
    void 
    Update() {

      horizontalMovement = Input.GetAxisRaw("Horizontal");

      if (Input.GetButtonDown("Jump")) {
        jump = true;
      }

    }

    private void 
    FixedUpdate() {
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

          //rigidBody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime);
          rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.fixedDeltaTime)
                             , ForceMode2D.Impulse);
          //Todo add sound
          Debug.Log("We must jump");

        }
        jump = false;
      }
    }

}
