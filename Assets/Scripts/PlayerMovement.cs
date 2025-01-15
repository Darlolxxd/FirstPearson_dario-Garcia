using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Animator animator;
    [SerializeField] private float gravity = -9.81f; // Gravity value
    [SerializeField] private float jumpHeight = 2f; // Height of the jump
    private CharacterController controller;
    private Vector3 velocity; // To store the player's velocity
    private bool isGrounded; // To check if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Reset the vertical velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Player movement using W, A, S, D keys
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // Move forward
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S)) // Move backward
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) // Move left
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D)) // Move right
        {
            moveDirection += transform.right;
        }

        // Normalize the movement direction and apply speed
        moveDirection.Normalize();
        controller.Move((moveDirection * speed * Time.deltaTime) + velocity * Time.deltaTime); // Apply movement and jump

        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", moveDirection.magnitude); // Set the Speed parameter

        // Mouse rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply vertical rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Rotate the player on the Y-axis
        transform.Rotate(0, mouseX, 0);

        // Update animator speed based on movement
        if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("speed", 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // Walk
            animator.SetFloat("speed", 0.5f);
        }
        else
        {
            // Run
            animator.SetFloat("speed", 1);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("arma"))
        {
            print("Daño");
        }
    }
}
