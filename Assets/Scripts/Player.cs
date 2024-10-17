using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidadMovimiento = 0;
    CharacterController controller;
    private float movimiento;
    public GameObject Head;
    public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        if (input.magnitude != 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.rotation.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
        }
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        Head.transform.eulerAngles = new Vector3(y, Head.transform.eulerAngles.y + y, 0);


        // controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }

}
