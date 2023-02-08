using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    //Ossian
    private float vertical; 

    [SerializeField]
    public float speed = 5.0f;

    public bool PlayerOnGround; // �r spelaren p� marken?
    private bool isLadder; // �r objektet en stege?
    private bool isClimbing; //Kl�ttrar spelaren

    public Animator PlayerAnimation;

    [SerializeField] private Rigidbody2D rb; //best�mmer vad rigidbody(spelaren) �r

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        PlayerOnGround = FindObjectOfType<PlayerMovement>().OnFloor;//hittar playermovement och att den �r p� golvet
    }
    void Update() 
    {
        vertical = Input.GetAxisRaw("Vertical"); //vertical=vertical

        if (isLadder && Mathf.Abs(vertical) > 0f)//Om det �r en ladder och vertical �r st�rre en 0 s� kl�ttrar man
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)  // om man kl�ttrar  blir gravity0 och man �ker upp annars �r gravity scale 1.5.
        {
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1.5f;
        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            PlayerOnGround = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && Input.GetKey(KeyCode.W))
        {
            isLadder = true;
            PlayerAnimation.SetBool("IsClimbing", true);
        }
        if (collision.CompareTag("Ladder") && Input.GetKey(KeyCode.W) && PlayerOnGround == true)
        {
            isLadder = true;
            PlayerAnimation.SetBool("IsClimbing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            PlayerAnimation.SetBool("IsClimbing", false);
            
        }
        if (collision.CompareTag("Ladder") && rb.velocity.y > 0.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3.0f);
        }
    }
} 