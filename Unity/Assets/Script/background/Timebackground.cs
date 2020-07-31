using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timebackground : MonoBehaviour
{
    public GameObject b_Morning;
    public GameObject b_Lunch;
    public GameObject b_Midnight;
    public GameObject b_Night;

    SpriteRenderer render;

    void Start()
    {
     

    }

    void Update()
    {
        
    }

    private void FixedUpdate() // 현재 시간을 계속 업데이트해서 시간대에 맞는 배경을 나오게함
    {
        int a = DateTime.Now.Hour;


        if (a > 4 & a < 12)
        {
            b_Morning.SetActive(true);
            b_Lunch.SetActive(false);
            b_Midnight.SetActive(false);
            b_Night.SetActive(false);
        }
        else if (a > 10 & a < 17)
        {
            b_Morning.SetActive(false);
            b_Lunch.SetActive(true);
            b_Midnight.SetActive(false);
            b_Night.SetActive(false);
        }
        else if (a > 15 & a < 23)
        {
            b_Morning.SetActive(false);
            b_Lunch.SetActive(false);
            b_Midnight.SetActive(true);
            b_Night.SetActive(false);
        }
        else
        {
            b_Morning.SetActive(false);
            b_Lunch.SetActive(false);
            b_Midnight.SetActive(false);
            b_Night.SetActive(true);       
        }
    }
}
