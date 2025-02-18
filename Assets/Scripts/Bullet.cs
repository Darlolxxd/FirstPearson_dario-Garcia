using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float damage = 25f;
    public float lifetime = 100f;
    
    // Start is called before the first frame update
    private void Start()
    {
      //  Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                enemigo.TakeDamage(damage);

            }    
        }
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
