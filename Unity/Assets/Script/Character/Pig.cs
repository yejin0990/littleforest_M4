using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// character script들은 중복되는 것이 많아 코드 설명은 Lion 에

public class Pig : MonoBehaviour
{
    public int character_id = 5000;
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> selectData;
    public string[] NPCsentences;
    int questid;
    public PolygonCollider2D PigCollider;

    public GameObject PigObject;

    public Image tigericon;
    public Image dogicon;
    public Image pigicon;
    public Image flogicon;
    public Text NametagText;


    private void Awake()
    {
        questid = 0;

        talkData = new Dictionary<int, string[]>();
        selectData = new Dictionary<int, string[]>();

        talkData.Add(5000, new string[] { "처음뵙네요 꿀" });

        /* quest5 - 상점퀘스트 */
        talkData.Add(5500, new string[] { "호랑상점 이용해보셨나요 꿀?" });
        talkData.Add(5510, new string[] { "어쩐일이세요 꿀?\n줄게 있다고요 꿀?","와 이거 제가 원하던 지푸라기가 맞아요 꿀!\n지금 집을 짓는 중이거든요.","지금 슈퍼 일을 도와주시는 중이군요 꿀!\n호야님은 무섭게 보여도 정이 많다니까요 꿀~","집은 다 지으면 구경시켜드릴게요 꿀!"});
        talkData.Add(5520, new string[] { "상점으로 안돌아가셔도 되나요 꿀?" });
        talkData.Add(5530, new string[] { "전 이제 주문한게 없어요 꿀" });
        talkData.Add(5540, new string[] { "늦게가면 호야님이 일을 더 시킬지도 몰라요 꿀" });
        talkData.Add(5550, new string[] { "자불라자님은 나도 대화를 안해봤다 꿀\n사실 난...영어 공포증이 있다 꿀" });

        /* quest6 - 집짓기 도와주기 */
        talkData.Add(5600, new string[] { "마침 잘 오셨어요 꿀.\n제가 도움이 필요해요 꿀", "집을 지었는데 집이 날아가 버렸어요...꿀....\n지푸라기 집 말고 나무 집을 지어야겠어요 꿀....","나무 판자... 구하는거 도와주실꺼죠... 꿀...?\n3개 이상면 충분할 것 같아요 꿀!" });
        talkData.Add(5610, new string[] { "나무 판자를 구하셨나요 꿀?\n아마 호랑 슈퍼에 팔꺼에요 꿀!","3개 이상이면 충분할 것 같아요 꿀!\n더 많으면 더 좋지만요 꿀~" });
        talkData.Add(5620, new string[] { "나무 판자를 구해주셨네요 꿀!\n이 은혜를 어떻게 갚아야할지... 꿀...","덕분에 이제 튼튼한 나무 집을 지을 수 있게 되었어요 꿀!","집 정리까지 다 되면 놀러 오세요 꿀~" });

        /* 랜덤 대화 */
        talkData.Add(5900, new string[] { "지푸라기를 구해주셔서 감사해요 꿀!\n덕분에 집을 지을 수 있게 되었어요 꿀!" });

        talkData.Add(5910, new string[] { "항상 감사하게 생각하고 있어요 꿀!","내부 공사까지 마치면 집에 초대할게요 꿀!" });
        talkData.Add(5920, new string[] { "혹시 아기돼지 삼형제라는 동화 본 적 있나요 꿀?", "그건 다 뻥이에요 꿀!" });
    }


    void Update()
    {
        if ((StaticVal.questID >= 500) && (StaticVal.questID < 700))
        {
            questid = StaticVal.questID;
        }
        else if (StaticVal.questID<500)
        {
            questid = 0;
        }
        else if (StaticVal.questID < 600)
        {
            questid = 900;
        }
        else
        {
            questid = 910;
        }

        NPCsentences = talkData[character_id + questid];

        if (StaticVal.Touchenable == 0) PigCollider.enabled = false;
        else if (StaticVal.Touchenable == 1) PigCollider.enabled = true;


        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = PigObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = false;
                        flogicon.enabled = false;
                        pigicon.enabled = true;
                        NametagText.text = "현빈";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 510) Questmanager.instance.quest510End();
                        else if (StaticVal.questID == 600) Questmanager.instance.quest600End();
                        else if (StaticVal.questID == 620) Questmanager.instance.quest620End();

                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PolygonCollider2D coll = PigObject.GetComponent<PolygonCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        tigericon.enabled = false;
                        dogicon.enabled = false;
                        flogicon.enabled = false;
                        pigicon.enabled = true;
                        NametagText.text = "현빈";

                        isSelectsentences(character_id + questid);
                        Talkmanager.instance.Ondialogue(NPCsentences);

                        if (StaticVal.questID == 510) Questmanager.instance.quest510End();
                        else if (StaticVal.questID == 600) Questmanager.instance.quest600End();
                        else if (StaticVal.questID == 610) Questmanager.instance.quest610End();
                        else if (StaticVal.questID == 620) Questmanager.instance.quest620End();
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
