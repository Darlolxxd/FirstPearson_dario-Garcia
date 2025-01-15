using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform balaSpawn;
    public float balaVelocity = 30f; // Adjust this value to control bullet speed
    public float balaPrefabLifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        // Instantiate the bullet
        GameObject bala = Instantiate(balaPrefab, balaSpawn.position, balaSpawn.rotation); // Use balaSpawn.rotation for correct orientation

        // Shoot the bullet
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(balaSpawn.forward * balaVelocity, ForceMode.Impulse); // Use forward direction
        }

        // Destroy the bullet after some time
        StartCoroutine(DestroyBalaAfterTime(bala, balaPrefabLifeTime));
    }

    private IEnumerator DestroyBalaAfterTime(GameObject bala, float prefabBalaLifeTime)
    {
        yield return new WaitForSeconds(prefabBalaLifeTime); // Use prefabBalaLifeTime for the delay
        Destroy(bala);
    }
}
