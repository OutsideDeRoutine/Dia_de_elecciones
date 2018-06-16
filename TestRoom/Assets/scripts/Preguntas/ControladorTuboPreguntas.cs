using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTuboPreguntas : MonoBehaviour {


    IList<String> respuestas;
    public Vector3 MoveToOnPaper;
    public Canvas paper;
	
    public void colocarFinalEnTubo(IList<String> respuesta)
    {
        respuestas = respuesta;
        GameObject.FindObjectOfType<TuboUsable>().GetComponent<TuboUsable>().setFinal(this.mandarMensajeFinalJuego);
    }

    internal void mandarMensajeFinalJuego()
    {
        GameObject.FindGameObjectWithTag("Paper").GetComponent<Animator>().SetBool("open",true);
        StartCoroutine(MoveCameraAndActiveScreen(1.7f));
    }

    public void finalizadaLecturaDeUnFinal()
    {
        //GetComponent<ControladorDePreguntas>().finalizadaLecturaDeUnFinal();
    }

    IEnumerator MoveCameraAndActiveScreen(float TimeBefore)
    {
        float time = Time.time;
        yield return new WaitForSeconds(TimeBefore);
        Camera.main.GetComponent<MoveCamera>().isScreen = true;
        while (Vector3.Distance( this.transform.position, MoveToOnPaper)>0.1f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, MoveToOnPaper, 0.05f);
            var targetRotation = Quaternion.LookRotation(paper.transform.position - Camera.main.transform.position);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, 0.05f / Vector3.Distance(this.transform.position, MoveToOnPaper));
            yield return new WaitForFixedUpdate();
        }
        float currentTime = Time.time;
        Color bcolor = Camera.main.backgroundColor;
        while (Time.time - currentTime < 0.5f)
        {
            paper.GetComponent<CanvasGroup>().alpha = Mathf.Abs(((Time.time - currentTime) / 0.5f));
            yield return new WaitForEndOfFrame();
        }
    }
}
