using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDaño : MonoBehaviour
{
    [SerializeField] float CantidadDaño = 10.0f;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("Player") && other.GetComponent<VidaPersonaje>())
        {
            other.GetComponent<VidaPersonaje>().RecibirDaño(CantidadDaño);
        }
    }
}
