using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidadmovimiento = 0;
    CharacterController controller;
    private float movimiento;
    public GameObject Head;
    public float turnSpeed;
    private Camera cam;
    [SerializeField] private float smoothing;
    private float velocidadRotacion;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
       
        

       
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;


        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.rotation.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);
            Debug.Log(velocidadRotacion);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            controller.Move(movimiento * 5 * Time.deltaTime);
            anim.SetBool("Running", true);
        }
        else 
        {
            anim.SetBool("Running", false);
        }
        


        // controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }

}
