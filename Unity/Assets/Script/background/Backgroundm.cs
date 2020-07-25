using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backgroundm : MonoBehaviour
{
    public CanvasGroup bgmONgroup;
    public CanvasGroup bgmOFFgroup;
    public AudioSource AudioSource;

    public static Backgroundm instance;

    void Awake()
    {
        if (instance != null)
        {
            Backgroundm.instance.AudioSource.Stop();
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

    public void bgmOFF()
    {
        GameObject.Find("BGMONButton").GetComponent<Image>().color = new Color(1, 1, 1);
        GameObject.Find("BGMOFFButton").GetComponent<Image>().color = new Color(52 / 255f, 233 / 255f, 1);
        bgmONgroup.blocksRaycasts = true;
        bgmOFFgroup.blocksRaycasts = false;
        AudioSource.Stop();
    }

    public void bgmON()
    {
        GameObject.Find("BGMOFFButton").GetComponent<Image>().color = new Color(1, 1, 1);
        GameObject.Find("BGMONButton").GetComponent<Image>().color = new Color(52 / 255f, 233 / 255f, 1);
        bgmONgroup.blocksRaycasts = false;
        bgmOFFgroup.blocksRaycasts = true;
        AudioSource.Play();
    }
}
