using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUsable : AbstractUsable
{

   public  GameObject pantalla;

    public bool pantallaEncendible = true;

    public override void accionInterna()
    {
        if (pantallaEncendible)
        {
            pantalla.GetComponent<ScreenOnOff>().Enter();
        }
    }

    public void apagarPantalla()
    {
        Debug.Log("Pantalla apagada e inhabilitada, porque ya estamos en la lectura de finales");
        pantallaEncendible = false;
        pantalla.GetComponent<ScreenOnOff>().Exit();
    }
}
