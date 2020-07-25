using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MarketEntry : MonoBehaviour
{
    public GameObject MarketObject;
    public Transform slotRoot;

    public AudioSource belleffect;

    void Awake()
    {
        belleffect = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = MarketObject.GetComponent<BoxCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        belleffect.Play();
                        StaticVal.scenenumber = 4;
                        SceneManager.LoadScene(StaticVal.scenenumber);
                        
                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = MarketObject.GetComponent<BoxCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        belleffect.Play();
                        StaticVal.scenenumber = 4;
                        SceneManager.LoadScene(StaticVal.scenenumber);
                    }
                }

            }
        }
    }
}
