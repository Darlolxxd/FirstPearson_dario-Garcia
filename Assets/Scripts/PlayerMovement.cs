using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Animator animator;
    [SerializeField] private CharacterController Controller;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene el componente Animator
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador usando teclas W, A, S, D
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // Mover hacia adelante
        {
            moveDirection += transform.forward;
           
            // Avanza en la dirección hacia donde está mirando
        }
        if (Input.GetKey(KeyCode.S)) // Mover hacia atrás
        {
            moveDirection -= transform.forward; // Retrocede en la dirección opuesta
        }
        if (Input.GetKey(KeyCode.A)) // Mover a la izquierda
        {
            moveDirection -= transform.right; // Se mueve a la izquierda
        }
        if (Input.GetKey(KeyCode.D)) // Mover a la derecha
        {
            moveDirection += transform.right; // Se mueve a la derecha
        }

        // Normaliza la dirección de movimiento y aplica la velocidad
        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Actualiza el parámetro Speed en el Animator
        animator.SetFloat("Speed", moveDirection.magnitude); // Establece el parámetro Speed

        // Rotación del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Aplica la rotación vertical a la cámara
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Rota el jugador en el eje Y
        transform.Rotate(0, mouseX, 0);
        if(moveDirection == Vector3.zero)
        {
            animator.SetFloat("speed", 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            //walk
            animator.SetFloat("speed", 0.5f);
        }
        else
        {
            //run
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
