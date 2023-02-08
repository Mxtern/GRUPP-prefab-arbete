using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    //Ossian
    private float vertical; 

    [SerializeField]
    public float speed = 5.0f;

    public bool PlayerOnGround; // är spelaren på marken?
    private bool isLadder; // är objektet en stege?
    private bool isClimbing; //Klättrar spelaren

    public Animator PlayerAnimation;

    [SerializeField] private Rigidbody2D rb; //bestämmer vad rigidbody(spelaren) är

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        PlayerOnGround = FindObjectOfType<PlayerMovement>().OnFloor;//hittar playermovement och att den är på golvet
    }
    void Update() 
    {
        vertical = Input.GetAxisRaw("Vertical"); //vertical=vertical

        if (isLadder && Mathf.Abs(vertical) > 0f)//Om det är en ladder och vertical är större en 0 så klättrar man
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)  // om man klättrar  blir gravity0 och man åker upp annars är gravity scale 1.5.
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