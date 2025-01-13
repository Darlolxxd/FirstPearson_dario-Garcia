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

 
    void Update()
    {
        ActualizarInterfaz();
        
    }
    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;
        TextoSalud.text = "+  " + Salud.ToString("f0");
    }
    public void RecibirDaño(float daño)
    {
        Salud -= daño;
    }
}
