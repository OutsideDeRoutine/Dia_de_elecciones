using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUsable : AbstractUsable
{

   public  GameObject pantalla;
    public override void accionInterna()
    {
        pantalla.GetComponent<ScreenOnOff>().Enter();
    }


}
