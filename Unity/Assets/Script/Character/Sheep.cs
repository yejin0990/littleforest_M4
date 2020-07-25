using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// character script들은 중복되는 것이 많아 코드 설명은 Lion 에

public class Sheep : MonoBehaviour
{
    public int character_id = 2000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    public PolygonCollider2D SheepCollider;

    public GameObject SheepObject;

    public Image lionicon;
    public Image Sheepicon;
    public Image Rabbiticon;
    public Text NametagText;


    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        talkData.Add(2000, new string[] { "꺄아아아아 누구양?" });

        /* quest1-튜토리얼 */
        talkData.Add(2100, new string[] { "난 너가 누군지 알지만 지금은 향섭이에게 가보세양.\n향섭이는 오른쪽에 있다양." });
        talkData.Add(2110, new string[] { "이장님께서 찾고있다양." });
        talkData.Add(2120, new string[] { "안녕하세양~ 처음 뵙겠습니다.\n전 이 마을의 심리치료사 양양이라고해양", "바깥세계에서 오셨다고 들었어양!", "오늘 바깥세계의 일이 즐거우셨어양?", "앗 직업병이 나와버렸네양!\n그래도 당신을 알 수 있어서 좋았어양!","이장님께 다시 가보세양!" });
        selectData.Add(21202, new string[] { "응 즐거웠어!","그냥 괜찮았어","아니.. 별로였어..." });
        talkData.Add(2130, new string[] { "홍홍홍 이장님께 가보세양~"});

        /* quest2-힐링지수 */
        talkData.Add(2200, new string[] { "힐링 지수라는게 생소하시나양?\n힐링 지수를 위해서는 행복 지수가 필요하다양! ","간단한 질문들이지만 시간이 조금 걸리니까\n준비가 되었다면 저를 다시 찾아오세양" });
        talkData.Add(2210, new string[] { "지금부터는 성실하게 부탁한다양!\n그럼 힐링 질문에 대답할 준비가 되셨나양?",
                                            "요즘 주머니 사정은 어떠신가양?",
                                            "당신의 코디는 맘에 드시나양?",
                                            "흠.. 그럼 오늘의 컨디션은 어떤가양?",
                                            "연애할 때는 어떤 타입이신가양?",
                                            "혹시 주변 사람들과 싸우지는 않으셨지양?",
                                            "지금 하고있는 일은 어떠신가양?",  //자부심과 성취감과 관련된 대답보기 만들기
                                            "본인을 위한 일은 하셨나양?", //자기계발은 어떻게 해야할 지 모르겠음,,,,
                                            "당신이 맡은 일은 잘 마치셨나양?",
                                            "하루 충분한 여가활동 즐기셨나양?","성실하게 대답해줘서 고맙다양!\n지금 진단결과를 내고 있는 중이양!","결과는 오른쪽 위의 힐링지수나 힐링 진단서를 보면 알 수 있다양!\n향섭이가 재미있는걸 준비했다하니 결과를 보고 한번 가보라양" });

        talkData.Add(2220, new string[] { "다시 대답을 하고 싶으시다고양?\n그래도 좋다양!",
                                            "경제적으로 힘드신가양?",
                                            "당신은 옷을 대충 입는 스타일이신가양?",
                                            "지금 기분은 어떠신가양?",
                                            "애인은 있으신가양?",
                                            "친구들과의 교류가 많은 편인가양?",
                                            "당신은 자신이 뭐든지 할 수 있다고 생각하나양?",  
                                            "나를 성장하게 해주는 일을 했다고 말할 수 있나양?", 
                                            "스스로가 책임감이 있다고 생각하나양?",
                                            "일을 안 할 땐 무엇을 하시나양?","성실하게 대답해줘서 고맙다양!\n지금 진단결과를 내고 있는 중이양!","결과는 오른쪽 위의 힐링지수나 힐링 진단서를 보면 알 수 있다양!\n향섭이가 재미있는걸 준비했다하니 결과를 보고 한번 가보라양" });

        selectData.Add(22100, new string[] { "응 당연하지!", "준비됐어~", "응... 아마..." });
        selectData.Add(22101, new string[] { "빵빵해~", "그럭저럭~", "조금..힘들어.." });
        selectData.Add(22102, new string[] { "당연하지~", "그냥 아무거나 입었어", "입을 옷이 없어..." });
        selectData.Add(22103, new string[] { "최고야!", "그냥 그래", "별로야..." });
        selectData.Add(22104, new string[] { "행복해지는 타입~", "부끄러워...", "무슨 연애야!!!" });
        selectData.Add(22105, new string[] { "절대 아니지!", "별일 없어~", "어떻게 알았어?!" });
        selectData.Add(22106, new string[] { "잘 되어가!", "나쁘지 않아!", "잘 안풀리네.." });
        selectData.Add(22107, new string[] { "물론이지!", "그럭저럭?", "바빠서.." });
        selectData.Add(22108, new string[] { "잘 끝났어!", "나쁘지 않아!", "잘 안풀리네.." });
        selectData.Add(22109, new string[] { "물론이지!", "그럭저럭?", "바빠서.." });

        selectData.Add(22200, new string[] { "다시 할래!", "준비됐어~", "응ㅎㅎ" });
        selectData.Add(22201, new string[] { "전혀 안 힘들어", "그냥저냥~", "힘들어.." });
        selectData.Add(22202, new string[] { "무조건 입고 싶은 옷!", "맞아 대충 입어.", "눈에 보이는 옷 입어." });
        selectData.Add(22203, new string[] { "좋아!", "아무 생각이 없어", "기분 안 좋아.." });
        selectData.Add(22204, new string[] { "있어서 행복해!", "없어도 행복해!", "연애 절대 안 해." });
        selectData.Add(22205, new string[] { "친구들이 제일 좋아", "소소한 모임 조금?", "혼자 노는게 제일 좋아" });
        selectData.Add(22206, new string[] { "당연하지!", "아닐 수도 있고..", "난 못 할거야.." });
        selectData.Add(22207, new string[] { "할 수 있어!", "그럭저럭?", "안 했어.." });
        selectData.Add(22208, new string[] { "책임감빼면 시체야", "그냥 보통?", "전혀 없어" });
        selectData.Add(22209, new string[] { "여가 생활을 즐겨", "매일 바껴", "아무것도 안 해.." });


        /* 힐링 질문 */

        /* 랜덤 대화 */
        talkData.Add(2900, new string[] { "사실 힐링 지수는 우리 마을에서만 사용한다양!" });

    }


    void Update()
    {
        if ((StaticVal.questID >= 0) && (StaticVal.questID < 300))
        {
            questid = StaticVal.questID;
        }
        else
        {
            questid = 900; //나중에 랜덤으로 바꾸기!
        }

        NPCsentences = talkData[character_id + questid];


        if (StaticVal.Touchenable == 0) SheepCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) SheepCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = SheepObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        lionicon.enabled = false;
                        Rabbiticon.enabled = false;
                        Sheepicon.enabled = true;
                        NametagText.text = "양양이";

                        if (character_id + questid == 2210)
                        {
                            Healing.instance.healing_QuestionQueue.Clear();
                            StaticVal.selectID = 1;
                        }
                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (questid == 120) Questmanager.instance.quest120End();
                        else if (questid == 200) Questmanager.instance.quest200End();
                        else if (questid == 210) Questmanager.instance.quest210End();


                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = SheepObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        lionicon.enabled = false;
                        Rabbiticon.enabled = false;
                        Sheepicon.enabled = true;
                        NametagText.text = "양양이";

                        if (character_id + questid == 2210)
                        {
                            Healing.instance.healing_QuestionQueue.Clear();
                            StaticVal.selectID = 1;
                        }
                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (questid == 120) Questmanager.instance.quest120End();
                        else if (questid == 200) Questmanager.instance.quest200End();
                        else if (questid == 210) Questmanager.instance.quest210End();

                    }
                }

            }
        }
    }

    public void isSelectsentences(int questid)
    {
        string[] blank = { "", "", "" };

        for (int i=0; i<12; i++)
        {
            if (selectData.ContainsKey(questid*10 + i))
            {
                Talkmanager.instance.isSelectData(selectData[questid*10 + i]);
            }
            else Talkmanager.instance.isSelectData(blank);
        }
    }
}