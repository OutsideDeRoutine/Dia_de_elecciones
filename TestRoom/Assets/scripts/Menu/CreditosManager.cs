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
        videoPlayer.skipOnDrop = false;
        videoPlayer.loopPointReached += EndReached;
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("MenuScene");
    }
}
