using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;
    private Vector3 mousePosition;
    private Camera mainCamera;
    public float RotationSpeed;

    //private float moveInput;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        AimRotation();
    }
    void FixedUpdate()
    {//movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if ((movement.x == 0) && (movement.y == 0))
        {
            anim.SetBool("isRunning", false);
        }
        else { anim.SetBool("isRunning", true); 
        }
    }

    void AimRotation()
    {
        if (Vector2.Distance(mousePosition, transform.position) > 0.1f)
        {
            Vector2 lookDir = mousePosition - transform.position;
            float angel = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            Quaternion rotation = Quaternion.AngleAxis(angel, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }

}
