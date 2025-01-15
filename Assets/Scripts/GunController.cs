using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootRate = 0.1f;
    private float nextShotTime = 0f;
    public AudioSource audioSource;
    public AudioClip shootSound;

    
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
        if(Input.GetButton("Fire1") && Time.time >= nextShotTime + shootRate)
        {
            shoot();
            nextShotTime = Time.time + shootRate;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
    void shoot()
    {
        Debug.Log("player is shooting!");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
