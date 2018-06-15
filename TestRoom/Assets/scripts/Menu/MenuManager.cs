using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public Canvas canvas;
    void Start()
    {
        StartCoroutine(FadeIn(1.5f));
    }
    IEnumerator FadeIn(float time)
    {
        float currentTime = Time.time;
        canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = 0;
        while (Time.time - currentTime < time)
        {
            canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = Mathf.Abs(((Time.time - currentTime) / time));
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOut(string level, float time, Color color)
    {
        float currentTime = Time.time;
        Color bcolor = Camera.main.backgroundColor;
        while (Time.time - currentTime < time)
        {
            canvas.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = Mathf.Abs(((Time.time - currentTime) / time) - 1);
            Camera.main.backgroundColor = Color.Lerp(bcolor, color, (Time.time - currentTime) / time);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(level);
    }


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
        StartCoroutine(FadeOut("SampleScene", 1f, Color.black));
    }
}
