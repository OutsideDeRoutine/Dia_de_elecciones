using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void empezarJuegoESP()
    {
        Lenguaje.instance.textLenguaje = "ES";
        empezarJuego();
    }

    public void empezarJuegoENG()
    {
        Lenguaje.instance.textLenguaje = "EN";
        empezarJuego();
    }

    private void empezarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
