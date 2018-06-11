using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditosManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer.isPrepared)
        {
            if (!videoPlayer.isPlaying)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
