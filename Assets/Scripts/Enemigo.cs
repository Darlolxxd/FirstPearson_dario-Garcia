using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;
    public float Health = 100f;
    

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }
    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("walk", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 3);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:

                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 2 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);
                //ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);

                ani.SetBool("attack", true);
                atacando = true;
                

            }
        }   
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Bullet"))
        {
            Health -= 20.0f;
            print("From Enemigo: Da�o recibido.");
        }
    }
    public void TakeDamage(float damage)
    {  
        Debug.Log("From Enemigo: damage taken! Health: " + Health + "Damage: "+ damage);
        Health -= damage;
        if (Health <=0)
        {
            ani.SetBool("death", true);
            Die();
        }
    }

    void Die()
    {
        Debug.Log("From Enemigo: Enemigo died!");
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
}
