using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArma : MonoBehaviour
{
    [SerializeField] private GameObject[] Weapon;
    [SerializeField] private bool[] tieneWeapon;
    bool estaCambiandoWeapon = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Weapon = -1;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon = 1;
        }
    }
}
