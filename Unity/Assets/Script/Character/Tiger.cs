using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tiger : MonoBehaviour
{
    public int character_id = 3000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    //public CanvasGroup healinggroup;
    public GameObject TigerObject;
    public PolygonCollider2D TigerCollider;

    public Image tigericon;
    public Image dogicon;
    public Image pigicon;
    public Image flogicon;
    public Text NametagText;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        /* 처음 랜덤 대화 */
        talkData.Add(3000, new string[] { "나는 슈퍼 주인 호야라고 한다.", "슈퍼에 가고 싶으면 문을 열고 들어가렴." });
        talkData.Add(3010, new string[] { "문을 여는 방법을 모르는거라 계속 말을 거는건가?" });


        /* quest5-상점퀘스트 */
        talkData.Add(3500, new string[] { "혹시 우리 호랑슈퍼를 이용하면서...\n잠깐, 자네 우리 슈퍼를 한 번도 이용하지 않았잖아?",
            "나의 심부름을 도와주면 나도 자네의 슈퍼이용을 도와주지.\n어떤가?","좋다고? 좋아.\n그럼 먼저 여기 옆에 있는 현빈에게 지푸라기를 주고와줘." });
        talkData.Add(3510, new string[] { "지푸라기를 현빈에게 가져다 주게나" });
        talkData.Add(3520, new string[] { "현빈이에게 잘 가져다 주었나?","잘했네. 이번엔 쿠루씨에게 사과를 가져다 주게나","참고로 쿠루씨는 장난끼가 많아\n아마 사과를 사과라 하지 않을 것이야." });
        talkData.Add(3530, new string[] { "쿠루씨에게 사과를 가져다 주게나" });
        talkData.Add(3540, new string[] { "허허 일을 이렇게 맡기니 편하군.\n하지만 마냥 일을 시킬 순없으니 이쯤하지.",
            "이제는 편하게 슈퍼를 이용하러 오게나.\n아마 곧 상점을 자주 이용하게 될게야~","마지막으로 자불라자에게 가볼수 있는가?\n자불라자의 공부를 도와주었으면 하네." });
        talkData.Add(3550, new string[] { "마지막으로 자불라자에게 가주게나\n자불라자는 왼쪽으로 쭉가면 있다네." });

        /* 랜덤 대화 */
        talkData.Add(3900, new string[] { "상점의 물건들은 자주 바뀐다네~" });

    }

    // Start is called before the first frame update
    void Start()
    {
        questid = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((StaticVal.questID >= 500) && (StaticVal.questID < 600))
        {
            questid = StaticVal.questID;
        }
        else if(StaticVal.questID >= 400)
        {
            questid = 900;
        }
        else
        {
            questid = 0;
        }

        NPCsentences = talkData[character_id + questid];

        /*
        <힐링바>
        if (questid > 30)
        {
            healinggroup.alpha = 1;
            healing.instance.PlayerHPbar();
        }
        */

        if (StaticVal.Touchenable == 0) TigerCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) TigerCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = TigerObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = true;
                        dogicon.enabled = false;
                        flogicon.enabled = false;
                        pigicon.enabled = false;
                        NametagText.text = "호야";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 500) Questmanager.instance.quest500End();
                        else if (StaticVal.questID == 520) Questmanager.instance.quest520End();
                        else if (StaticVal.questID == 540) Questmanager.instance.quest540End();

                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = TigerObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = true;
                        dogicon.enabled = false;
                        flogicon.enabled = false;
                        pigicon.enabled = false;
                        NametagText.text = "호야";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 500) Questmanager.instance.quest500End();
                        else if (StaticVal.questID == 520) Questmanager.instance.quest520End();
                        else if (StaticVal.questID == 540) Questmanager.instance.quest540End();
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
