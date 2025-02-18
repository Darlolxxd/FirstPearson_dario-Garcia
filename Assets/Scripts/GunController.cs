using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject firePoint;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector
    public GameObject bulletPrefab;

    public AudioSource audioSource;
    public AudioClip shootSound;

    private GameObject newBullet;
    private float bulletSpeed = 0.1f; 
    private float shootInterval = 0.1f;
    private float myTime = 0.0f;
    private float nextShotTime = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
        if ( audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        // Dispara si se pulsa el botón izquierdo del ratón y ha pasado el intervado entre disparos
        if (Input.GetMouseButtonDown(0) && myTime >= nextShotTime)
        {
            Debug.Log("Time to shoot . ");
            nextShotTime = myTime + shootInterval;
            shoot();
        }
    }
    void shoot()
    {
        Debug.Log("GunController: Bullet departing !");
       // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
        if (audioSource != null)
        {
          audioSource.Play();
        }         
    }
}
