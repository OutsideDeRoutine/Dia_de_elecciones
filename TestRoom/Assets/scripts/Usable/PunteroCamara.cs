using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteroCamara : MonoBehaviour {

    public Canvas puntero;
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
                
                PCUsable pu = hit.transform.GetComponent<PCUsable>();
                TuboUsable tu = hit.transform.GetComponent<TuboUsable>();
                if ((pu && pu.pantallaEncendible && !pu.pantalla.GetComponent<ScreenOnOff>().inUse))
                {
                    puntero.GetComponent<CanvasGroup>().alpha = 1;
                }
                else if ((tu && !tu.finalActivado && tu.finalActivo))
                {
                    puntero.GetComponent<CanvasGroup>().alpha = 1;
                }
                hit.transform.GetComponent<IUsable>().seleccionado();
                foreach (Material mat in hit.transform.GetComponent<Renderer>().materials)
                {
                    mat.SetColor("_OutlineColor", mat.GetColor("_Color") + new Color(0.2f, 0.2f, 0.2f));
                }
            }
        }
        else
        {
            puntero.GetComponent<CanvasGroup>().alpha = 0;
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
                puntero.GetComponent<CanvasGroup>().alpha = 0;
                hit.transform.GetComponent<IUsable>().accion();
            }
                
        }
    }
}
