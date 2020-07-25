using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class bambooGO : MonoBehaviour
{
    public BoxCollider2D bambooGOCollider;
    public GameObject bambooGOObject;
    public AudioSource woodeffect;

    public static bambooGO instance;


    void Awake()
    {
        instance = this;
        woodeffect = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((StaticVal.Touchenable == 1) && (StaticVal.Post_bamboo_Num > 1))
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount == 1)
                {
                    Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    BoxCollider2D coll = bambooGOObject.GetComponent<BoxCollider2D>();                   

                    if (coll.OverlapPoint(mp))
                    {
                        if (!EventSystem.current.IsPointerOverGameObject())
                        {
                            woodeffect.Play();
                            StaticVal.scenenumber = 5;
                            SceneManager.LoadScene(StaticVal.scenenumber);
                            StaticVal.Touchenable = 1;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    BoxCollider2D coll = bambooGOObject.GetComponent<BoxCollider2D>();                   

                    if (coll.OverlapPoint(mp))
                    {
                        if (!EventSystem.current.IsPointerOverGameObject())
                        {
                            woodeffect.Play();
                            StaticVal.scenenumber = 5;
                            SceneManager.LoadScene(StaticVal.scenenumber);
                            StaticVal.Touchenable = 1;
                        }
                    }

                }
            }
        }
    }
}

