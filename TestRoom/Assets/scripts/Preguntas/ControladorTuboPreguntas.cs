using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTuboPreguntas : MonoBehaviour {

    IList<String> respuestas;
	
    public void colocarFinalEnTubo(IList<String> respuesta)
    {
        respuestas = respuesta;
        //respuesta.final;
        //colocar el final del juego
    }

    internal void mandarMensajeFinalJuego()
    {
        //mandar mensaje de agradecimiento por participar en el experimento
        //tener en cuenta los idiomas
        throw new NotImplementedException();
    }

    public void finalizadaLecturaDeUnFinal()
    {
        //GetComponent<ControladorDePreguntas>().finalizadaLecturaDeUnFinal();
    }
}
