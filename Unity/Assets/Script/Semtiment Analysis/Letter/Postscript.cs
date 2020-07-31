using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
우체통 object 클릭하면 편지 UI 뜨게 하기
*/

public class Postscript : MonoBehaviour
{
    public BoxCollider2D PostCollider;
    public GameObject postObject;
    public GameObject letterObject;
    public AudioSource posteffect;
    public static Postscript instance;


    void Awake()
    {
        instance = this;
        posteffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((StaticVal.Touchenable == 1)&&(StaticVal.Post_bamboo_Num >0))
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount == 1)
                {
                    Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    BoxCollider2D coll = postObject.GetComponent<BoxCollider2D>();

                    if (coll.OverlapPoint(mp))
                    {
                        if (!EventSystem.current.IsPointerOverGameObject())
                        {
                            posteffect.Play();
                            letterObject.SetActive(true);
                            StaticVal.Touchenable = 0;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    BoxCollider2D coll = postObject.GetComponent<BoxCollider2D>();

                    if (coll.OverlapPoint(mp))
                    {
                        if (!EventSystem.current.IsPointerOverGameObject())
                        {
                            posteffect.Play();
                            letterObject.SetActive(true);
                            StaticVal.Touchenable = 0;
                        }
                    }

                }
            }
        }
    }
}
