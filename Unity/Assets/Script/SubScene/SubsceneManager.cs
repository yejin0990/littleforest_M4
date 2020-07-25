using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsceneManager : MonoBehaviour
{
    public static SubsceneManager instance;

    public GameObject pighouseObject0;
    public GameObject pighouseObject1;
    public GameObject pighouseObject2;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (StaticVal.questID < 520)
        {
            pighouseEmpty();
        }
        else if (StaticVal.questID < 550)
        {
            pighouseFirst();
        }
        else if (StaticVal.questID < 630)
        {
            pighouseEmpty();
        }
        else
        {
            pighouseSecond();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pighouseEmpty()
    {
        pighouseObject0.SetActive(true);
        pighouseObject1.SetActive(false);
        pighouseObject2.SetActive(false);
    }
    public void pighouseFirst()
    {
        pighouseObject1.SetActive(true);
        pighouseObject2.SetActive(false);
        pighouseObject0.SetActive(false);
    }
    public void pighouseSecond()
    {
        pighouseObject0.SetActive(false);
        pighouseObject1.SetActive(false);
        pighouseObject2.SetActive(true);
    }
   
}
