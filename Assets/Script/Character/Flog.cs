using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Flog : MonoBehaviour
{
    public int character_id = 6000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    //public CanvasGroup healinggroup;
    public PolygonCollider2D FlogCollider;

    public GameObject FlogObject;

    public Image tigericon;
    public Image dogicon;
    public Image pigicon;
    public Image flogicon;
    public Text NametagText;


    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        talkData.Add(6000, new string[] { "누구냐 개굴" });

        /* quest5 - 상점퀘스트 */
        talkData.Add(6500, new string[] { "호랑상점 가봐라 개굴" });
        talkData.Add(6510, new string[] { "뭐냐 개굴" });
        talkData.Add(6520, new string[] { "호랑상점 어딘지 모르냐 개굴" });
        talkData.Add(6530, new string[] { "그건 뭐냐 개굴? 호야가 준건가 개굴","빨간색 공을 가져다 줘서 고맙다 개굴","종종 부탁해야겠다 개굴" });
        talkData.Add(6540, new string[] { "호야가 찾는다 개굴" });

        /* quest7 - 아이템 퀘스트 */
        talkData.Add(6700, new string[] { "심심해보이는 군 개굴\n나랑 재밌는 게임하나 하지 개굴", "게임의 룰은 간단해 개굴\n내가 원하는 것을 사오면 된다 개굴","그럼 먼저 모자 쓴 열매를 가져다 줘 개굴." });
        talkData.Add(6710, new string[] { "베레모 모자 쓴 열매... 혹시 모르는 건 아니겠지 개굴" });
        talkData.Add(6720, new string[] { "맞아, 정답은 이 도토리 였다 개굴.","그럼 다음으로는 먹으면 잠이 안오는 피를 가져다 줘 개굴" });
        talkData.Add(6730, new string[] { "먹으면 잠이 안오는 피를 가져다 줘라 개굴.\n그렇다고 진짜 피를 가져오면 안된다 개굴개굴" });
        talkData.Add(6740, new string[] { "오 제법인걸. 슬슬 재밌어 진다 개굴!","다음은 들수는 있지만 오를 수 없는 산을 가져다 줘 개굴!" });
        talkData.Add(6750, new string[] { "들수는 있지만 오를 수 없는 산이 뭐가 있을까 깨굴깨굴" });
        talkData.Add(6760, new string[] { "기대 이상이다 개굴!\n구하느라 꽤 애를 먹었을텐데 개굴","이제 정말 마지막 게임을 하자 개굴!","봄과 나를 가져다줘라 개굴!" });
        talkData.Add(6770, new string[] { "봄과 나, 두개다 개굴!" });
        talkData.Add(6780, new string[] { "거울에 비친 나, 그리고 봄에 피는 꽃...","센스 만점이다 개굴!\n이 쿠루와 놀아줘서 고마웠다 개굴!" });

        
        /* 랜덤대화 */
        talkData.Add(6900, new string[] { "개굴개굴 개구리 노래를 한다 개굴","이래봬도 이 근처에서는 나이가 제일 많다 개굴" });
        talkData.Add(6920, new string[] { "당신 내 맘에 쏙 든다 개굴" });

    }


    void Update()
    {
        if(((StaticVal.questID >= 700) && (StaticVal.questID < 800)) || ((StaticVal.questID >= 500) && (StaticVal.questID < 550)))
        {
            questid = StaticVal.questID;
        }
        else if (StaticVal.questID < 300)
        {
            questid = 0;
        }
        else if (StaticVal.questID < 700)
        {
            questid = 900;
        }
        else
        {
            questid = 900;
        }

        NPCsentences = talkData[character_id + questid];

        if (StaticVal.Touchenable == 0) FlogCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) FlogCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = FlogObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = false;
                        flogicon.enabled = true;
                        pigicon.enabled = false;
                        NametagText.text = "쿠루";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 530) Questmanager.instance.quest530End();
                        else if (StaticVal.questID == 700) Questmanager.instance.quest700End();
                        else if (StaticVal.questID == 720) Questmanager.instance.quest720End();
                        else if (StaticVal.questID == 740) Questmanager.instance.quest740End();
                        else if (StaticVal.questID == 760) Questmanager.instance.quest760End();
                        else if (StaticVal.questID == 780) Questmanager.instance.quest780End();

                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = FlogObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = false;
                        flogicon.enabled = true;
                        pigicon.enabled = false;
                        NametagText.text = "쿠루";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 530) Questmanager.instance.quest530End();
                        else if (StaticVal.questID == 700) Questmanager.instance.quest700End();
                        else if (StaticVal.questID == 720) Questmanager.instance.quest720End();
                        else if (StaticVal.questID == 740) Questmanager.instance.quest740End();
                        else if (StaticVal.questID == 760) Questmanager.instance.quest760End();
                        else if (StaticVal.questID == 780) Questmanager.instance.quest780End();
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
