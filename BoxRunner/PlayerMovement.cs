using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Animator animator;

    public float jumpVelocity = 5f;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = Vector2.up * jumpVelocity;
            ScoreScript.scoreValue += 10;
            
        }
        
           
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycast.collider != null;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "Box")
        {
            FindObjectOfType<GameManager>().GameOver();

        }
        if (collisionInfo.collider.tag == "Pig")
        {
            FindObjectOfType<GameManager>().GameOver();

        }
    }
}
