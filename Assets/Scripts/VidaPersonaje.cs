using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPersonaje : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    public Image BarraSalud;
    public Text TextoSalud;

    // Steps to define an event
    // a) Define a delegate for the event (a method signature)
    public delegate void QuitGame();
    // Define the event using the delegate
    public event QuitGame OnPlayerDeath;

    void Start()
    {
        Salud = SaludMaxima;

    }
    void Update()
    {
        ActualizarInterfaz();

    }
    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;
        TextoSalud.text = "+  " + Salud.ToString("f0");
        if (Salud <= 0)
        {
            Die();
        }
    }
    public void RecibirDaño(float daño)
    {
        Debug.Log(" Jugador dañado: -" + daño);
        Salud -= daño;
    }
    private void Die()
    {
        // Invoke the OnPlayerDeath event if there are listeners
        // Trigger the event
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath.Invoke();
        }
    }
}

