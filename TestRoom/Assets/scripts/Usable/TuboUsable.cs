using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboUsable : AbstractUsable
{
    public bool finalActivo;
    public bool finalActivado;
    Action todo;
    public override void accionInterna()
    {
        if (finalActivo)
        {
            todo();
            finalActivado = true;
        }
    }

    internal void setFinal(Action todo)
    {
        this.todo = todo;
        GetComponentInParent<Animator>().SetBool("open", true);
        finalActivo = true;
    }
}
