using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform balaSpawn;
    public float balaVelocity = 30;
    public float balaPrefabLifeTime = 3f;
    private float delay;


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
        //Instantiate the bullet
        GameObject bala = Instantiate(balaPrefab, balaSpawn.position, Quaternion.identity);
        //Shoot the bullet
        bala.GetComponent<Rigidbody>().AddForce(balaSpawn.forward.normalized * balaVelocity, ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBalaAfterTime(bala, balaPrefabLifeTime));


    }
    private IEnumerator DestroyBalaAfterTime(GameObject bala, float prefabBalaLifeTime)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bala);
    }
   
}
