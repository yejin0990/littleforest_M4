using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gamedog : MonoBehaviour
{
    public int character_id = 8000;
    Dictionary<int, string[]> talkData;
    public string[] NPCsentences;
    int questid;
    //public CanvasGroup healinggroup;
    public PolygonCollider2D GamedogCollider;

    public GameObject GamedogObject;

    public Text NametagText;
  
    public void Start()
    {
        talkData = new Dictionary<int, string[]>();
        talkData.Add(8000, new string[] { "도와주러 오셔쿤yo~ 나에게 맛춘법을 알려주면 됨니다~", "맛는 맛춘법을 select 해yo." });
        /* 이 대화가 끝나면 게임이 시작하도록 하고 시풔..*/


    }


    void Update()
    {
        
    }
}
