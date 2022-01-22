using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -19.62f;
    public float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistanse = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //tmp variables
    [SerializeField] private GameObject buts;
    private bool isButActive = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistanse, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //tmp for Machnik
        if (Input.GetKeyDown(KeyCode.F) && !isButActive) {
            Camera.main.GetComponent<MouseLook>().enabled = false;
            buts.SetActive(true);
            isButActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.G) && isButActive) {
            Camera.main.GetComponent<MouseLook>().enabled = true;
            buts.SetActive(false);
            isButActive = false;
            Cursor.visible = false;
        }

    }
}
