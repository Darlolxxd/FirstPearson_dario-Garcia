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
    
    private float velocidadRotacion;
    private Animator anim;

    private Vector3 movimientoVertical;

    [SerializeField] private float smoothing;

    [Header("Deteccion del suelo")]
    [SerializeField] private GameObject pies;
    [SerializeField]private float escalaGravedad;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;


    [SerializeField] private float alturaSalto;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private int speed = 0;
    private Animator Animator;


    
    



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

           
        }
        if(moveDirection == Vector3.zero)
        {
            //Idle
            anim.SetFloat("Speed", 0);
        } 

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("Speed",0.5f);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //run
            anim.SetFloat("Speed", 1);
            Animator.SetBool("run", true);
        }
        moveDirection *= speed;
         
        

        AplicarGravedad();
        DeteccionSuelo();






        // controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical* Time.deltaTime);
    }
    private void DeteccionSuelo()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(pies.transform.position, radioDeteccion, queEsSuelo);

        if(collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color= Color.green;
        Gizmos.DrawSphere(pies.transform.position, radioDeteccion);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
            
        }
    }

     

}
