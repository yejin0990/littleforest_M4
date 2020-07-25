using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CLetter : MonoBehaviour
{
    public static CLetter instance;

    public InputField m_InputField;
    public Text m_Letter;

    public CanvasGroup letterOutputgroup;
    public CanvasGroup SendButtongroup;

    public int letterInt;
    Dictionary<int, string> letterData;
    public Text letterOutputtext;

    public GameObject CLetterObject;

    public AudioSource lettersound;

    private void Awake()
    {
        lettersound = GetComponent<AudioSource>();
        instance = this;

        letterData = new Dictionary<int, string>();

        //초기대답
        letterData.Add(0, "편지같은거 오지 않았는데 혹시 보냈었다면 다시 시도해봐.\n" +
            "우체국에 문제가 생겼을 수도 있거든.");
        //긍정대답
        letterData.Add(11, "너의 편지는 보기만해도 재미있어진다 개굴\n오늘 호야 상점에 빨간색 공이 들어왔더군\n하나 잡숴봐 내가 제일 좋아하는 과일이야.");
        letterData.Add(12, "안녕, 오늘 좋은 하루 보내 개굴!\n이건 이장님에게 들은 옆 동네 얘기인데\n옆 동네 다람이가 모자쓴 열매를 좋아한다더군 개굴..");
        letterData.Add(13, "난 비오는 날을 좋아해 개굴!\n들수는 있지만 오를 수 없는 산에 떨어지는\n빗방울 소리가 제일 좋아 개굴!");
        //부정대답
        letterData.Add(21, "당신의 편지를 우연히 봤는데 부정의 기운이 느껴진다양\n오늘은 아무 생각없이 쉬는걸 추천해양\n생각이 많아지면 복잡해지거든양");
        letterData.Add(22, "편지 보내줘서 고마워양 당신은 슬프거나 화날 때\n무엇을 하시나양? 저는 부정적인 생각을\n하지않으려고 노력해양");
        letterData.Add(23, "오늘 당신은 힘들어보이네양 저는 심리상담사를 직업으로\n한지 꽤 오래되었는데 인간은 정말 어려운 동물이에양\n할 말이 이것밖에 없네양.. 오늘도 힘내세양!");
        //중립대답
        letterData.Add(31, "자네의 편지는 어렵구만.... 마치 어려운 자네같군 껄껄\n좀 더 명확한 단어를 사용하면 좋을 것 같군..\n오늘도 좋은 하루 보내게!");
        letterData.Add(32, "편지 분석에 실패했습니다.(삐리리-)\n리틀포레스트 침략 실패. 침략 실패.\nC4-2020별로 철수한다.");
        letterData.Add(33, "이 편지는 M4별에서 최초로 시작되어 일년에\n한 바퀴 돌면서 받는 사람에게 행운을 줍니다.\n이 편지를 본 모든 생명들에게 행운이 오길,,");
    }

    void Start()
    {
        letterInt = 0;
        letterOutputgroup.alpha = 0;
        letterOutputgroup.interactable = false;
        letterOutputgroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_InputField.text);
        //Debug.Log(m_Letter.text);
    }

    public void Openbutton()
    {
        lettersound.Play();
        SendButtongroup.blocksRaycasts = true;
        SendButtongroup.interactable = true;

        CLetterObject.SetActive(true);
    }

    public void Closebutton()
    {
        lettersound.Play();
        Healing.instance.healingLetter();
        CLetterObject.SetActive(false);

        letterOutputgroup.alpha = 0;
        letterOutputgroup.interactable = false;
        letterOutputgroup.blocksRaycasts = false;

        SendButtongroup.blocksRaycasts = true;
        SendButtongroup.interactable = true;

        m_InputField.text = "";
        m_Letter.text = " ";

        if (StaticVal.questID == 400) StaticVal.questID += 10;
        StaticVal.Touchenable = 1;
    }

    public void Sendbutton()
    {
        lettersound.Play();
        Debug.Log(m_Letter.text.ToString());

        string fileName = "/mytextfile.txt";
        var sr = File.CreateText(Application.persistentDataPath + fileName);
        sr.WriteLine(m_Letter.text.ToString());
        sr.Close();

        SendButtongroup.blocksRaycasts = false;
        SendButtongroup.interactable = false;

        socket.instance.TextServer();
    }

    public void getLetter()
    {
        letterOutputtext.text = letterData[letterInt];

        letterOutputgroup.alpha = 1;
    }

}