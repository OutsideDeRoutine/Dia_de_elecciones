using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalController : MonoBehaviour {
    public Text text;
    IList<String> finales;
    private int i=0;
    public GameObject end;
    public void theAwaken()
    {
        finales=GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorDePreguntas>().getFinales();
        colocarSiguiente();
    }

    public void colocarSiguiente()
    {
        if (i >= finales.Count)
        {
            GoEndCanvas();
            return;
        }
        StopAllCoroutines();
        StartCoroutine(writeME(text, finales[i]));
        i++;
    }

    private IEnumerator writeME(Text put, string str)
    {
        int i = 0;
        put.text = "";
        foreach (char c in str)
        {
            put.text += c;
            yield return new WaitForSeconds(0.1f / str.Length);
            i++;
        }
    }

    private void GoEndCanvas()
    {
        end.SetActive(true);
        StopAllCoroutines();
        text.transform.parent.transform.parent.transform.parent.gameObject.SetActive(false);
    }

    public void Creditos()
    {
        StartCoroutine(FadeOut("creditosScene", 1f, Color.black));
    }

    IEnumerator FadeOut(string level, float time, Color color)
    {
        float currentTime = Time.time;
        Color bcolor = Camera.main.backgroundColor;
        while (Time.time - currentTime < time)
        {
            GameObject.FindGameObjectWithTag ("CanvasPlayer").GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = Mathf.Abs(((Time.time - currentTime) / time));
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(level);
        GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("CanvasPlayer"));
    }
}
