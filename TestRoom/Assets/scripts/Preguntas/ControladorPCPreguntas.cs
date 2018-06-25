using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPCPreguntas : MonoBehaviour{

    public void colocarPreguntaEnPantalla(Pregunta pregunta)
    {
        //hacer cosas para colocar la pregunta y las respuestas en la pantalla
        //buscar por nombre
        StopAllCoroutines();
        StartCoroutine(writeME(GameObject.Find("ContentPregunta1").GetComponent<Text>(), pregunta.resp1.texto));
        StartCoroutine(writeME(GameObject.Find("ContentPregunta2").GetComponent<Text>(), pregunta.resp2.texto));
        StartCoroutine(writeME(GameObject.Find("Pregunta").GetComponent<Text>(), pregunta.cuestion));
    }

    private IEnumerator writeME(Text put, string str)
    {
        int i = 0;
        put.text = "";
        foreach(char c in str)
        {
            put.text += c;
            for (float duration = 0.01f; duration > 0; duration -= Time.fixedDeltaTime)
            {
                yield return new WaitForFixedUpdate();
            }
            i++;
        }
    }

    public void seleccionarRespuesta(int numero)
    {
        GetComponent<ControladorDePreguntas>().definirRespuestaSeleccionada(numero);
    }
}
