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

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
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
