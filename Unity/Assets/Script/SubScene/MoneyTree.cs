using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyTree : MonoBehaviour
{
    public GameObject CointreeObject;
    public AudioSource treeeffect;
    public static MoneyTree instance;

    void Awake()
    {
        treeeffect = GetComponent<AudioSource>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(StaticVal.coinTree == 0)CointreeObject.SetActive(false);
        else CointreeObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (StaticVal.coinTree == 1) touchCoinTree();
        else CointreeObject.SetActive(false);
        */
        touchCoinTree();
    }

    public void touchCoinTree()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = CointreeObject.GetComponent<BoxCollider2D>();
                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        treeeffect.Play();
                        StaticVal.playerCoin += Random.Range(1, 5);
                        CointreeObject.SetActive(false);
                        StaticVal.coinTree = 0;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = CointreeObject.GetComponent<BoxCollider2D>();
                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("클릭함");
                        treeeffect.Play();
                        StaticVal.playerCoin += Random.Range(1, 5);
                        CointreeObject.SetActive(false);
                        StaticVal.coinTree = 0;
                    }
                }

            }
        }
    }
}
