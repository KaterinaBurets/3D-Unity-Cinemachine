using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;

    private Vector3 velocity;
    private bool isGrounded = false;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        WalkAnimation();
        JumpingAnimation();

        isGrounded = false;
    }

    private void WalkAnimation()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _anim.SetBool("isIdle", false);
            _anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isIdle", true);
        }
    }

    private void JumpingAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Input.GetKeyDown(KeyCode.W)))
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetBool("isIdle", false);
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _anim.SetBool("isJumping", false);
            _anim.SetBool("isIdle", true);
        }
    }
}    