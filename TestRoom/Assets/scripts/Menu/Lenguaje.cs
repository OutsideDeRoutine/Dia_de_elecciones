using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenguaje : MonoBehaviour {

    public static Lenguaje instance { get; private set; }

    public string textLenguaje;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
