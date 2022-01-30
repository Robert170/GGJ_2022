using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 2f;

    [SerializeField]
    private float _jumpSpeed = 10f;

    [SerializeField]
    private float _gravity = 9.81f;

    public Animator animator;

    private CharacterController _controller;

    private float directionY;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // Debug.Log(horizontalInput);
        if (horizontalInput > 0  )
        {
            animator.SetBool("Direction", true);

        }
        else if (horizontalInput < 0)
        {
            animator.SetBool("Direction", false);

        }

        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput * _moveSpeed));


        

        if (Input.GetButtonDown("Jump"))
        {
            directionY = _jumpSpeed;
        }

        directionY -= _gravity * Time.deltaTime;

        moveDirection.y = directionY;

        _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }
}
