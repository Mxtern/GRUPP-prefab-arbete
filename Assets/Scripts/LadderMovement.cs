using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    
    private float vertical; 

    [SerializeField]
    public float speed = 5.0f;

    public bool PlayerOnGround;
    private bool isLadder;
    private bool isClimbing;

    public Animator PlayerAnimation;

    [SerializeField] private Rigidbody2D rb; //ändra till spelarens rigid body och gör även en tag som heter "Ladder"

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerOnGround = FindObjectOfType<PlayerMovement>().OnFloor;
    }
    void Update() 
    {
        vertical = Input.GetAxisRaw("Vertical"); // även här

        if (isLadder && Mathf.Abs(vertical) > 0f) // lika bra här
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing) // vete fan men skitbra
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
        if (collision.CompareTag("Ladder") && Input.GetKey(KeyCode.W))// om tagen är "ladder" är ladder sant
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
        if (collision.CompareTag("Ladder"))// bra jobbat här
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
} // inte mitt script fuck you