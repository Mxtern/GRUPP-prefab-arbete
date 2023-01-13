using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical; 
    private float speed = 10f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb; //ändra till spelarens rigid body och gör även en tag som heter "Ladder"

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
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) // om tagen är "ladder" är ladder sant
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))// bra jobbat här
        {
            isLadder = false;
            isClimbing = false;
        }
    }
} // inte mitt script fuck you