using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
