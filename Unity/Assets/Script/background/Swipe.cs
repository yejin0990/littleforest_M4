using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float speed = 0.000001f;
    public Transform cam;

    /*
    Vector2 prevPos = Vector2.zero;
    float prevDistance = 0f;
    */

    public Vector2 center;
    public Vector2 size;

    float height;
    float width;


    void Start()
    {
       // cam = Camera.main.transform;
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center,size);
    }

    
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (StaticVal.Touchenable == 1)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                float movess = -touchDeltaPosition.x * speed;

                if (((transform.position.x + movess) >= 18f) && (touchDeltaPosition.x < 0))
                {
                    transform.Translate(0, 0, 0);
                }
                else if (((transform.position.x + movess) <= -18f) && (touchDeltaPosition.x > 0))
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    transform.Translate(movess, 0, 0);
                }
            }
          

            /*
             * 두번째
            
            float lx = size.x * 0.5f - width;
            float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

            transform.position = new Vector3(clampX, 0, 0);
            */

        }

    }




}
