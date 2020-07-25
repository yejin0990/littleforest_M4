using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmusic : MonoBehaviour
{
    public CanvasGroup bgmONgroup;
    public CanvasGroup bgmOFFgroup;
    public AudioSource AudioSource;

    public static Bgmusic instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {

    }

    void bgmOFF()
    {
        bgmONgroup.blocksRaycasts = true;
        bgmOFFgroup.blocksRaycasts = false;
        AudioSource.Stop();
    }

    void bgmON()
    {
        bgmONgroup.blocksRaycasts = false;
        bgmOFFgroup.blocksRaycasts = true;
        AudioSource.Play();
    }
}
