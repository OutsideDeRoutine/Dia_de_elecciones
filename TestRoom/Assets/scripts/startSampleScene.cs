using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSampleScene : MonoBehaviour {

    void Start()
    {
        StartCoroutine(FadeIn(1.5f));
        if (!Lenguaje.instance)
        {
            this.gameObject.AddComponent<Lenguaje>();
            Lenguaje.instance.textLenguaje = "EN";
        }
    }
    IEnumerator FadeIn(float time)
    {
        float currentTime = Time.time;
        this.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = 1;
        while (Time.time - currentTime < time)
        {
            this.GetComponent<Canvas>().GetComponent<CanvasGroup>().alpha = 1- Mathf.Abs(((Time.time - currentTime) / time));
            yield return new WaitForEndOfFrame();
        }
    }
}
