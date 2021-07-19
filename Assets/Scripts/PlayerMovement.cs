using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;
    public LayerMask groundLayer;
    public AudioSource runAudio;
    public AudioSource jumpAudio;
    public Animator anim;

    private float inputX;
    public float mSpeed = 1;
    public float jumpForce = 5;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //moving player 
        rb.velocity = new Vector2(inputX * mSpeed, rb.velocity.y);
        playRun();

    }
    public void Move(InputAction.CallbackContext value) 
    {
        inputX = value.ReadValue<float>();
        anim.SetFloat("Speed", inputX);
        
    }
    public void Jump(InputAction.CallbackContext value)
    {
        if(value.performed && isGrounded())
        {
            anim.SetFloat("Speed", inputX);
            anim.SetBool("Jump", true);
            jumpAudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else anim.SetBool("Jump", false);


    }
    private bool isGrounded()
    {
        float extraHeight = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center,
            playerCollider.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);


        //check if player touches the ground
        return raycastHit.collider != null;
    }
    private void playRun()
    {
        if (inputX == 0 || !isGrounded()) runAudio.mute = true;
        else runAudio.mute = false;
        
    }
}
