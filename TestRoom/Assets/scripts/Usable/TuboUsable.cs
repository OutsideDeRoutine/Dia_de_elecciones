using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboUsable : AbstractUsable
{
    bool finalActivo;
    Action todo;
    public override void accionInterna()
    {
        if (finalActivo)
        {
            todo();
        }
    }

    internal void setFinal(Action todo)
    {
        this.todo = todo;
        GetComponentInParent<Animator>().SetBool("open", true);
        finalActivo = true;
    }
}
