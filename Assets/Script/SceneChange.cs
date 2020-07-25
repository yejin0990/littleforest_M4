using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;
    public AudioSource effecta;

    void Awake()
    {
        effecta = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");   
    }

    public void ChangeScene()
    {
        if (StaticVal.Touchenable == 1)
        {
            if (StaticVal.scenenumber == 3)
            {
                StaticVal.scenenumber = 2;
                StaticVal.Touchenable = 1;
            }
            else if (StaticVal.scenenumber == 2)
            {
                StaticVal.scenenumber = 3;
                StaticVal.Touchenable = 1;
            }

            SceneManager.LoadScene(StaticVal.scenenumber);
        }

        effecta.Play();
    }

    public void ChangeSubScene()
    {
        StaticVal.scenenumber = 3;
        SceneManager.LoadScene(StaticVal.scenenumber);
        StaticVal.Touchenable = 1;
    }

    public void ChangeGameScene()
    {
        StaticVal.scenenumber = 5;
        SceneManager.LoadScene(StaticVal.scenenumber);
    }
    public void musiccontrol()
    {
        Backgroundm.instance.AudioSource.Stop();
    }

    /*
    public void Change이동할 씬 이름Scene()
    {
        SceneManager.LoadScene("이동할 씬 이름");
    }
    */

}
