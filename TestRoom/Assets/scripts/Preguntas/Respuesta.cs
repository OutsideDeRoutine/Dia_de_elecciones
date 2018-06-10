using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta   {

    public string texto { get; set; }
    public string final { get; set; }

    public Respuesta(string texto, string final)
    {
        this.texto = texto;
        this.final = final;
    }

    public string mostrarInfo()
    {
        return "\n\t\tRespuesta: "+texto + "\n\t\tFinal: "+final;
    }
}
