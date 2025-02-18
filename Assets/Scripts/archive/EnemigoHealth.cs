using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHealth : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage! Health: " + health);

        if(health < 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
