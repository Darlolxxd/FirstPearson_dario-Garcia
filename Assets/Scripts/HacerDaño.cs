using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDaño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("player") && other.GetComponent<VidaPersonaje>())
        {
            other.GetComponent<VidaPersonaje>().RecibirDaño(CantidadDaño);
        }
    }
}
