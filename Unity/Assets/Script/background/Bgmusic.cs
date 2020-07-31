using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmusic : MonoBehaviour
{
// 배경음 중복 제어, 끄고 키는 코드
    public CanvasGroup bgmONgroup;
    public CanvasGroup bgmOFFgroup;
    public AudioSource AudioSource;

    public static Bgmusic instance = null;

    void Awake() // 씬전환 할때마다 배경음이 중복 되는거 막음
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
