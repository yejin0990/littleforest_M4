using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentQuest : MonoBehaviour
{
    public static CurrentQuest instance;
    public GameObject currentQuestObject;
    public Text questTitleText;
    public Text questContentText;
    public Image questImage;
    public AudioSource currentsound;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        currentsound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentQuestObject.SetActive(false);

        if (StaticVal.questID < 200) quest100();
        else if (StaticVal.questID < 300) quest200();
        else if (StaticVal.questID < 400) quest300();
        else if (StaticVal.questID < 500) quest400();
        else if (StaticVal.questID < 600) quest500();
        else if (StaticVal.questID < 700) quest600();
        else if (StaticVal.questID < 800) quest700();
        else if (StaticVal.questID < 900) quest800();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCurrentQuest()
    {
        if(StaticVal.Touchenable == 1)
        {
            currentsound.Play();
            StaticVal.Touchenable = 0;
            currentQuestObject.SetActive(true);
        }
    }
    public void closeCurrentQuest()
    {
        currentsound.Play();
        StaticVal.Touchenable = 1;
        currentQuestObject.SetActive(false);
    }

    public void quest100()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/lion");
        questTitleText.text = "마을 주민들과 인사하기";
        questContentText.text = "우리 마을에 온 것을 환영한다네.\n" +
            "마을 주민들에게 인사를 하고 와주겠나?\n" +
            "내가 특별한 손님이 왔다고 말해놓았다네 허허.";
    }
    public void quest200()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/sheep");
        questTitleText.text = "힐링 지수 알아보기";
        questContentText.text = "오른쪽 위에 있는 힐링지수가 무엇인지 궁금하지 않으시나양?\n" +
            "저와 함께 대화를 나누면서 힐링 지수에 대해 알아봐양!\n" +
            "힐링을 위해 기본적인 행복지수도 계산할 예정이니\n" +
            "조금의 시간적 여유를 가지고 와야한다양!";
    }
    public void quest300()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/rabbit");
        questTitleText.text = "사진으로 감정을 알아보기";
        questContentText.text = "너의 기분을 내가 맞춰볼께!\n" +
            "지금 너가 느끼는 감정을 표정으로 보여줘!\n" +
            "나한테 말을 걸면 사진을 찍을 수 있으니 꼭 말을 걸어줘~\n" +
            "기다리고 있을게~!";
    }
    public void quest400()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/lion");
        questTitleText.text = "편지와 대나무 숲 알아보기";
        questContentText.text = "우리 마을에 있는 우체통과 대나무 숲 표지판을 보았나\n" +
            "우체통을 누르면 편지를 작성할 수 있고\n" +
            "표지판을 누르면 대나무 숲으로 갈 수 있다네.\n" +
            "두개 모두 재밌으니 한번 눌러보고 오겠나.";
    }
    public void quest500()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/tiger");
        questTitleText.text = "호랑상점 도와주기";
        questContentText.text = "상점을 한번도 이용하지 않았더군.\n" +
            "상점 일을 도우면서 상점에 대해서도 배우고 근처 친구들과도 인사하는 좋은 기회가 되길 바란다.\n";
    }
    public void quest600()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/pig");
        questTitleText.text = "현빈의 집 짓기";
        questContentText.text = "지푸라기 집은 역시 약한가봐요 꿀...\n" +
            "저번에 도와 주셔서 감사하지만\n"+
            "튼튼한 집을 지을 수 있게 한번만 더 도와주실 수 있으신가요 꿀...?";
    }
    public void quest700()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/flog");
        questTitleText.text = "쿠루와 아이템 게임";
        questContentText.text = "나와 함께 작은 게임하나 해보자 개굴\n" +
            "게임 방법은 별거 아니다 개굴!\n" +
            "그저 내가 말한 것만 사와주면 된다 개굴!";
    }
    public void quest800()
    {
        questImage.sprite = Resources.Load<Sprite>("QuestCharacter/dog");
        questTitleText.text = "자불라자와 한국어 공부";
        questContentText.text = "자불라자가 한국말을 잘 못해서 내가 대신 말해준다 개굴.\n" +
            "자불라자가 공부할 수 있게 도와주도록 해라 개굴!\n"+
            "+ HELP ME~~~~~!";
    }
}
