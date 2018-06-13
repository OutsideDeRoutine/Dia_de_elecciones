using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour {

    public GameObject canvasQuest;

    // Use this for initialization
    public void Click () {
        canvasQuest.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorDePreguntas>().enabled=true;
       this.transform.parent.gameObject.SetActive(false);
	}
}
