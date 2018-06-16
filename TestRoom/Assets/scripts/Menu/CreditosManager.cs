using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditosManager : MonoBehaviour
{
    VideoPlayer videoPlayer;
    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPrepared)
        {
            if (!videoPlayer.isPlaying)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
