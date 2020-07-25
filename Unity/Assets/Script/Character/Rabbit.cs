using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// character script들은 중복되는 것이 많아 코드 설명은 Lion 에

public class Rabbit : MonoBehaviour
{
    public int character_id = 4000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    public PolygonCollider2D RabbitCollider;

    public GameObject RabbitObject;

    public Image lionicon;
    public Image Sheepicon;
    public Image Rabbiticon;
    public Text NametagText;


    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        talkData.Add(4000, new string[] { ".....누구세요?"});

        /* quest1 - 튜토리얼 */
        talkData.Add(4100, new string[] { "안녕. 이장임아저씨께 네 얘기는 들었어.", "우리 종종 바깥세상 이야기도 하고 그러자.", "그럼 이제 다시 장임아저씨께 가봐." });
        talkData.Add(4110, new string[] { "다시 장임아저씨께 가봐." });
        talkData.Add(4120, new string[] { "양양님은 반대편에 있다구!" });
        talkData.Add(4130, new string[] { "이장임이 부르는 소리가 들리는걸?"});

        /* quest4 - 사진퀘스트 */
        talkData.Add(4300, new string[] { "너의 지금 기분을 표정으로 보여줘!" });
        selectData.Add(43000, new string[] { "카메라를 보여줘!", "앨범에서 찾아볼게", "다음에.." });

        /* 사진 요구 */
        talkData.Add(4800, new string[] { "바깥세상 갔다왔어??" });

        /* 랜덤 대화 */
        talkData.Add(4900, new string[] { "평소에 사진찍는 것을 좋아하니?", "사실 난... 사진을 잘 못찍어..." });

        
    }

    void Start()
    {

    }


    void Update()
    {
        if (((StaticVal.questID >= 0) && (StaticVal.questID < 200)) || ((StaticVal.questID >= 300) && (StaticVal.questID < 400)))
        {
            questid = StaticVal.questID;
        }
        else if (StaticVal.questID < 500)
        {
            questid = 900;
        }
        else
        {
            questid = 300; //나중에 랜덤으로 바꾸기!
        }

        NPCsentences = talkData[character_id + questid];

        if (StaticVal.Touchenable == 0) RabbitCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) RabbitCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = RabbitObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        lionicon.enabled = false;
                        Rabbiticon.enabled = true;
                        Sheepicon.enabled = false;
                        NametagText.text = "향섭이";

                        if (character_id + questid == 4300) StaticVal.selectID = 2;
                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (questid == 100) Questmanager.instance.quest100End();
                        else if ((StaticVal.questID == 300) && (Healing.instance.currentPicEmotion != "")) Questmanager.instance.quest300End();

                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = RabbitObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        lionicon.enabled = false;
                        Rabbiticon.enabled = true;
                        Sheepicon.enabled = false;
                        NametagText.text = "향섭이";

                        isSelectsentences(character_id + questid);

                        if (character_id + questid == 4300) StaticVal.selectID = 2;

                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (questid == 100) Questmanager.instance.quest100End();
                        else if ((StaticVal.questID == 300) && (Healing.instance.currentPicEmotion != "")) Questmanager.instance.quest300End();
                        // else if (questid == 300)는 socket에 넣어놓음.

                    }
                }

            }
        }
    }

    public void isSelectsentences(int questid)
    {
        string[] blank = { "", "", "" };

        for (int i = 0; i < 12; i++)
        {
            if (selectData.ContainsKey(questid * 10 + i))
            {
                Talkmanager.instance.isSelectData(selectData[questid * 10 + i]);
            }
            else Talkmanager.instance.isSelectData(blank);
        }
    }
}
