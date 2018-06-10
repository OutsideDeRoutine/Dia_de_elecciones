using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteroCamara : MonoBehaviour {    

	// Update is called once per frame
	void Update () {
        //para hacer debug del puntero de accion
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
            IUsable itemUsable = hit.transform.GetComponent<IUsable>();
            if (itemUsable != null)
            {
                hit.transform.GetComponent<IUsable>().seleccionado();
                foreach(Material mat in hit.transform.GetComponent<Renderer>().materials)
                {
                    mat.SetColor("_OutlineColor", Color.white);
                }
            }
        }
        else
        {
            //quitamos los atributos seleccionados a todo
            GameObject[] usables = GameObject.FindGameObjectsWithTag("Usable");
            foreach (GameObject obj in usables)
            {
                foreach (Material mat in obj.GetComponent<Renderer>().materials)
                {
                    mat.SetColor("_OutlineColor", Color.black);
                }
                obj.GetComponent<IUsable>().desSeleccionado();
            }
        }

        //Esto no se muy bien donde meterlo 
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hit.transform.GetComponent<IUsable>().accion();
            }
                
        }
    }
}
