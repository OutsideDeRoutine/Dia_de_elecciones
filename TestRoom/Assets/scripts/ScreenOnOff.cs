using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOnOff : MonoBehaviour {
    public bool inUse;
    public float time;
    public bool on = false;
    public bool running = false;
    private Material mat;
	// Use this for initialization
	void Start () {
        mat =this.GetComponent<Renderer>().material;
        on = mat.GetFloat("_OnOff") == 0;
    }

    public void ChangeState()
    {
        if(!running)
        {
            GameObject.Find("AudioPCEmiter").GetComponent<AudioSource>().Play();
            StartCoroutine(OnOff());
        }
    }

    IEnumerator OnOff()
    {
        running = true;
        float startTime = Time.time;
        while (Time.time - startTime < time)
        {
           if (on) mat.SetFloat("_OnOff", Mathf.Lerp(0f,1.5f, Mathf.Clamp((Time.time - startTime) / time, 0, 1)));
           else mat.SetFloat("_OnOff", Mathf.Lerp(1.5f, 0f, Mathf.Clamp((Time.time - startTime) / time,0,1)));
            yield return new WaitForEndOfFrame();
        }
        if (on) mat.SetFloat("_OnOff", 1.5f);
        else mat.SetFloat("_OnOff", 0f);
        running = false;
        on = !on;
    }

    public void Exit()
    {
        inUse = false;
       if (!on)   ChangeState();
        Camera.main.GetComponent<MoveCamera>().isScreen = false;
    }
    public void Enter()
    {
        inUse = true;
        if (on) ChangeState();
        Camera.main.GetComponent<MoveCamera>().isScreen = true;
    }
}
