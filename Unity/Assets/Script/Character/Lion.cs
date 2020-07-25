using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 나머지 캐릭터 script들은 중복됨 */

public class Lion : MonoBehaviour
{
    public int character_id=1000;
    Dictionary<int, string[]> talkData;     // 대사 data
    Dictionary<int, string[]> selectData;   // 선택 대사 data
    public string[] NPCsentences;
    int questid;
    public PolygonCollider2D LionCollider;

    public GameObject LionObject;

    public Image lionicon;
    public Image Sheepicon;
    public Image Rabbiticon;
    public Text NametagText;


    private void Awake()
    { 
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        /* 처음 */
        talkData.Add(1000, new string[] { "너는 누구냐. 길을 잃은 것인가..?", "나는 이장임이라고한다.\n물론 이 마을의 이장님이기도하다.", "온김에 우리 마을 주민들을 소개해줄까?", "오른쪽으로 쭉 가다보면 향섭이네가 나오니 \n가서 향섭군과 한번 이야기해보게" });

        /* quset1 - 튜토리얼 */
        talkData.Add(1100, new string[] { "향섭이와 인사를 나누고 오거라." });
        talkData.Add(1110, new string[] { "향섭군이 무척 반가워 했다네.", "그럼 이번엔 왼쪽에 있는 양양이라는 양에게 가보겠나." });
        talkData.Add(1120, new string[] { "양양이네 집은 왼쪽일세.." });
        talkData.Add(1130, new string[] { "인사하느라 수고했네. \n이 마을에 종종 놀러오려면 인사정도는 해두는게 좋지.",
            "심리 치료사인 양양이가 자네의 힐링지수를 계산하고싶다고 하더군.\n다들 자네가 여기서 힐링 하고갔으면 한다네.",
            "우리가 아직은 자네에 대해 잘 모르니\n양양이와 대화를 조금 더 나누어보지 않겠는가." });

        /* 양양, 향섭 퀘스트 중*/
        talkData.Add(1200, new string[] { "자네가 양양이, 향섭이와 대화를 더 나누어봤으면 하네." });

        /* quest4 - 컨텐츠 소개 */
        talkData.Add(1400, new string[] { "혹시 내 옆에 우체통이 보이는가?\n우체통을 클릭하면 편지를 쓸 수 있다네.",
            "오늘 있었던 일 중에서 기뻤던 일이나 화났던 일들을 적어보겠나.\n그럼 한번 해보고 다시 와볼 수 있겠나?" });
        talkData.Add(1410, new string[] { "우체통에서 답장을 받아봤는가?\n우리 마을의 누군가가 적은거라네 허허.",
        "혹시 옆쪽에 대나무숲 표지판을 봤는가?\n그 표지판을 눌러보면 대나무숲으로 가게 될걸세.","대나무 숲에서 감정을 담아 하고 싶은 말을 해보게.\n무슨 말을 하는지는 아무도 못들으니까 안심하게나!" });
        talkData.Add(1420, new string[] { "사진, 편지, 그리고 자네의 목소리에 따라\n힐링지수에 변화가 생겼을 걸세.",
            "힐링 진단서에 있는 모든 항목이 채워지면\n오늘의 소식지가 따로 뜰걸세.\n오늘의 소식지를 한번 확인해보겠나.",
            "아, 확인해보기 전에 몇가지만 물어보지.\n자네는 어떤 분위기의 노래를 좋아하나?",
            "그럼 자네는 어떤 느낌의 영화를 좋아하나?","흠 자네의 취향을 조금은 알 것 같군..\n이리저리 불려다니느라 수고했다네 껄껄" });
        selectData.Add(14202,new string[] { "감성적인 음악","신나는 음악","상큼한 음악" });
        selectData.Add(14203, new string[] { "역동적인 영화", "감성적인 영화", "귀여운 영화" });

        /* 랜덤 대화 */
        talkData.Add(1900, new string[] { "자네는 힐링이 무엇이라고 생각하나... " });
        talkData.Add(1910, new string[] { "처음 왔을 때 보다 마을 사람들과 친해진 것 같구먼 허허", "다들 착한 녀석들이야 허허허" });
        talkData.Add(1920, new string[] { "혹시 마을 옆 쪽에 가봤나?","그 곳에는 다른 주민들과 슈퍼도 있다네!\n안가봤으면 한번 가보면 좋을 듯하네." });

    }

    
    void Update()
    {
        // quest id에 따라 캐릭터의 quest id 정해주기
        if ((StaticVal.questID >= 0) && (StaticVal.questID < 200))
        {
            questid = StaticVal.questID;
        }
        else if ((StaticVal.questID >= 400) && (StaticVal.questID < 500)) questid = StaticVal.questID;
        else if ((StaticVal.questID >= 200) && (StaticVal.questID < 400)) questid = 200;
        else
        {
            int random = Random.Range(0, 3); // 0 <= random < 3
            questid = 900 + (random * 10);
        }

        NPCsentences = talkData[character_id + questid];

        // touchable 이 0 이면 다른 UI가 실행되고 있기 때문에 lion 클릭 방지
        if (StaticVal.Touchenable == 0) LionCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) LionCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = LionObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        // 대사 창의 icon 선택
                        lionicon.enabled = true;
                        Rabbiticon.enabled = false;
                        Sheepicon.enabled = false;
                        NametagText.text = "이장임";

                        if (StaticVal.questID == 420) StaticVal.selectID = 4;

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        // 클릭 후 퀘스트에 맞춰서 진행 ( qusetmanager )
                        if (questid == 0) Questmanager.instance.quest0End();
                        else if (questid == 110) Questmanager.instance.quest110End();
                        else if (questid == 130) Questmanager.instance.quest130End();
                        else if (questid == 400) Questmanager.instance.quest400End();
                        else if (questid == 410) Questmanager.instance.quest410End();
                        else if (questid == 420) Questmanager.instance.quest420End();


                    }
                }
            }
        }
    
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = LionObject.GetComponent<PolygonCollider2D>();
                
                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        lionicon.enabled = true;
                        Rabbiticon.enabled = false;
                        Sheepicon.enabled = false;
                        NametagText.text = "이장임";

                        if (StaticVal.questID == 420) StaticVal.selectID = 4;

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (questid == 0) Questmanager.instance.quest0End();
                        else if (questid == 110) Questmanager.instance.quest110End();
                        else if (questid == 130) Questmanager.instance.quest130End();
                        else if (questid == 400) Questmanager.instance.quest400End();
                        else if (questid == 410) Questmanager.instance.quest410End();
                        else if (questid == 420) Questmanager.instance.quest420End();


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
