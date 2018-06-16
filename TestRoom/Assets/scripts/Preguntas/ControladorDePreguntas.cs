using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ControladorDePreguntas : MonoBehaviour {

    public IList<Pregunta> preguntas;
    int numeroPregunta = 0;

    bool leyendoPregunta = false;
    int preguntaSeleccionada = 1;
    bool finalActivo = false;


   void Start() {
        //vamos a Cargar las preguntas
        preguntas = new List<Pregunta>();
        string path = Lenguaje.instance.textLenguaje+"_preguntas"; 
       
        TextAsset textAsset = (TextAsset)Resources.Load(path);
        XmlDocument doc = new XmlDocument();

        try
        {
            //cargamos el documento
            doc.LoadXml(textAsset.text);
            //Sacamos todos los nodos pregunta
            XmlNodeList listaNodosConstante = doc.GetElementsByTagName("pregunta");
            Debug.Log(listaNodosConstante.Count);
            IEnumerator ienumListaNodos = listaNodosConstante.GetEnumerator();           
            
            while (ienumListaNodos.MoveNext())
            {
                XmlNode nodoPreg = (XmlNode)ienumListaNodos.Current;
                String pregunta = nodoPreg.Attributes["texto"].Value;
                //solo tenemos dos hijos
                XmlNode resp1Nodo = nodoPreg.FirstChild;
                Respuesta resp1 = new Respuesta(resp1Nodo.Attributes["texto"].Value,resp1Nodo.FirstChild.Value);
                XmlNode resp2Nodo = nodoPreg.LastChild;
                Respuesta resp2 = new Respuesta(resp2Nodo.Attributes["texto"].Value,resp2Nodo.FirstChild.Value);
                Pregunta preg = new Pregunta(pregunta,resp1,resp2);
                preguntas.Add(preg);
            }
            foreach (Pregunta preg in preguntas)
            {
                Debug.Log(preg.mostrarInfo());
            }
        }
        catch (System.IO.FileNotFoundException)
        {
            Debug.Log("No se ha cargado bien el fichero");
        }
    }

    public Pregunta getPReguntaActual()
    {
        return preguntas[numeroPregunta];
    }

    public Boolean preguntasAcabadas()
    {
        return (numeroPregunta >= preguntas.Count) ? true : false;
    }

    //lamar a este metodo con el indice de la respuesta seleccionada
    public void definirRespuestaSeleccionada(int numero)
    {
        getPReguntaActual().respSeleccionada(numero);
        marcarPreguntaActualComoRespondida();
    }

    private void marcarPreguntaActualComoRespondida()
    {
        preguntas[numeroPregunta].pregUsada = true;
        numeroPregunta++;
        leyendoPregunta = false;
    }  
       
    public IList<String> getFinales()
    {
        IList<String> listaFinales = new List<String>();
        foreach(Pregunta preg in preguntas)
        {
            listaFinales.Add(preg.getRespuestaAPregunta().final);
        }
        return listaFinales;
    }

	
	// Update is called once per frame
	void Update () {

        if (!preguntasAcabadas())
        {
            if (!leyendoPregunta)
            {                
                leyendoPregunta = true;
                GetComponent<ControladorPCPreguntas>().colocarPreguntaEnPantalla(getPReguntaActual());              
            }
        }
        else
        {
            if (!finalActivo)
            {

                Debug.Log("Acabadas las preguntas");
                GameObject.FindObjectOfType<PCUsable>().apagarPantalla();
                finalActivo = true;
                GameObject.Find("AudioTuboEmiter").GetComponent<AudioSource>().Play();
                GetComponent<ControladorTuboPreguntas>().colocarFinalEnTubo(getFinales());
            }
        }
        
        
              
	}
}