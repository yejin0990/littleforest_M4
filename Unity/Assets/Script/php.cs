using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class php : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
        StartCoroutine("LoadFromPhp");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadFromPhp()
    {
        string url = "http://34.71.85.31";
        WWW www = new WWW(url);

        yield return www;

        if (www.isDone)
        {
            if (www.error == null)
            {
                Debug.Log("Receive Data : " + www.text + "\n- php 연결완료!");
            }
            else
            {
                Debug.Log("error : " + www.error);
            }
        }
    }

}