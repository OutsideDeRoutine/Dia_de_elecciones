using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta 
{
    public bool pregUsada { get; set; }
    public string cuestion { get; set; }
    public Respuesta resp1 { get; set; }
    public Respuesta resp2 { get; set; }
    public int indiceRespSeleccionada;

    public Pregunta(string cuestion, Respuesta resp1, Respuesta resp2)
    {
        this.cuestion = cuestion;
        this.resp1 = resp1;
        this.resp2 = resp2;
    }

    //1 o 2
    public void respSeleccionada(int resp)
    {
        indiceRespSeleccionada = resp;
    }

    public Respuesta getRespuestaAPregunta()
    {
        return (indiceRespSeleccionada == 1) ? resp1 : resp2;
    }

    public string mostrarInfo()
    {
        return "Pregunta: " + cuestion + "\n\tRespuesta1: " + resp1.mostrarInfo() + "\n\tRespuesta2: " + resp1.mostrarInfo() + "\n";
    }

}
