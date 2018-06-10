using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    /*
     * Metodo para marcar el objeto cuando el jugador lo mira
     * */
    void seleccionado();

    void desSeleccionado();
    /*
     * Accion que realiza el objeto cuando esta seleccionado
     * */
    void accion();
    
    //accion que se va a realizar cuando se pulse sobre el objeto
    void accionInterna();
}


public abstract class AbstractUsable : MonoBehaviour, IUsable {

    bool estaSeleccionado;

    public void seleccionado()
    {
        estaSeleccionado = true;
    }

    public void desSeleccionado()
    {
        estaSeleccionado = false;
    }

    public void accion()
    {
        if (estaSeleccionado)
        {
            accionInterna();
            desSeleccionado();
        }
    }

    public abstract void accionInterna();
}
