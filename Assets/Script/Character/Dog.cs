using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    public int character_id = 7000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    //public CanvasGroup healinggroup;
    public PolygonCollider2D DogCollider;

    public GameObject DogObject;

    public Image tigericon;
    public Image dogicon;
    public Image pigicon;
    public Image flogicon;
    public Text NametagText;


    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        talkData.Add(7000, new string[] { "누군가요... You는..?", "Mr.장임을 찯아가보셰요." });

        /* quest5 - 상점퀘스트 */
        talkData.Add(7550, new string[] { "안영하세효~ 져는 자불라자라고 합니돠.\n한큑말 오려워...","나랑 study GAME하고 싶으면 옆의 door 클릭해죠" });

        /* 랜덤 대화 */
        talkData.Add(7900, new string[] { "안영하세효~ 저는 외쿡에서 왓셔요~","져는 자불라자라고 합니돠. 반걉슴니다." });
        talkData.Add(7910, new string[] { "안영하세효~ 져는 자불라자라고 합니돠.\n저랑 game안하실례요? 혹쉬~?","옆에 door을 클릭하면 game하러 갈 수 있셔요!" });

        /* quest8 - 마지막퀘스트 */
        talkData.Add(7800, new string[] { "혹쉬... 내 공부 도와 쥬세요\ns나 혼자 콩부 어려워요","내가 공부 할슈이께 pencil과 book을 가치 구해죠요?" });
        talkData.Add(7810, new string[] { "콩부를 하료면 pencil과 book이 필요해yo...." });
        talkData.Add(7820, new string[] { "연필과 책! 코마워요!","그럼 이제 본격적으로 콩부 해도 될 것같아요!\n콩부하러 같이 갈까효?","맞춤법 game 같이 하러 가쓰면 좋겠어yo...." });
        talkData.Add(7840, new string[] { "덕분에 한국어 마스터 했습니다. 당신의 도움에 감동했습니다.","당신은 정말 친절한 사람입니다. 모두 그렇게 생각하고 있을 것입니다." });
    }

    void Update()
    {
        if ((StaticVal.questID == 0) && (StaticVal.questID > 800) &&(StaticVal.questID == 550))
        {
            questid = StaticVal.questID;
        }
        else
        {
            questid = 900;
        }

        NPCsentences = talkData[character_id + questid];

        if (StaticVal.Touchenable == 0) DogCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) DogCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = DogObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = true;
                        pigicon.enabled = false;
                        flogicon.enabled = false;
                        NametagText.text = "자불라자";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 550) Questmanager.instance.quest550End();
                        else if (StaticVal.questID == 800) Questmanager.instance.quest800End();
                        else if (StaticVal.questID == 820) Questmanager.instance.quest820End();

                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = DogObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = true;
                        pigicon.enabled = false;
                        flogicon.enabled = false;
                        NametagText.text = "자불라자";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 550) Questmanager.instance.quest550End();
                        else if (StaticVal.questID == 800) Questmanager.instance.quest800End();
                        else if (StaticVal.questID == 820) Questmanager.instance.quest820End();

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
