using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTuboPreguntas : MonoBehaviour {

    IList<String> respuestas;
	
    public void colocarFinalEnTubo(IList<String> respuesta)
    {
        respuestas = respuesta;
        GameObject.FindObjectOfType<TuboUsable>().GetComponent<TuboUsable>().setFinal(this.mandarMensajeFinalJuego);
    }

    internal void mandarMensajeFinalJuego()
    {
        GameObject.FindGameObjectWithTag("Paper").GetComponent<Animator>().SetBool("open",true);
    }

    public void finalizadaLecturaDeUnFinal()
    {
        //GetComponent<ControladorDePreguntas>().finalizadaLecturaDeUnFinal();
    }
}
