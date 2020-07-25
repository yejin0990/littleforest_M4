using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Talkmanager : MonoBehaviour, IPointerDownHandler
{
    public Text dialogueText;
    public Text select1Text;
    public Text select2Text;
    public Text select3Text;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    //public CanvasGroup healinggroup;
    public Queue<string> sentences;  //queue : 선입선출
    public Queue<string> selectSentences;
    Dictionary<int, string[]> talkData;

    public string currentSentence;

    public CanvasGroup selectgroup;

    public float typingSpeed = 0.001f;
    private bool istyping;
    public Animator animDialogue;

    private bool isselect;  //선택창뜨면 1

    public AudioSource Clicksound;

    public static Talkmanager instance;

    private void Awake()
    {
        instance = this;
        Clicksound = GetComponent<AudioSource>();
    }

    void Start()
    {
        sentences = new Queue<String>();
        selectSentences = new Queue<String>();

        selectgroup.alpha = 0;
        selectgroup.interactable = false;
        selectgroup.blocksRaycasts = false;
    }


    public void Ondialogue(string[] lines)
    {
        StaticVal.Touchenable = 0;

        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }
        animDialogue.SetBool("appear", true);
        dialoguegroup.blocksRaycasts = true;
        
        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));

            select1Text.text = selectSentences.Dequeue();
            select2Text.text = selectSentences.Dequeue();
            select3Text.text = selectSentences.Dequeue();
        }
        else
        {
            animDialogue.SetBool("appear", false);
            dialoguegroup.blocksRaycasts = false;

            selectSentences.Clear();
            select1Text.text = "";
            select2Text.text = "";
            select3Text.text = "";

            if (StaticVal.selectID == 1) Healing.instance.healingValCalculation();
            StaticVal.Touchenable = 1;
            StaticVal.selectID = 0;
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        //dialogueText == currentSentence 이면 대사 한줄 끝
        if (dialogueText.text.Equals(currentSentence))
        {
            if (select1Text.text == "")
            {
                nextText.SetActive(true);
                istyping = false;
            }
            else
            {
                selectgroup.alpha = 1;
                selectgroup.blocksRaycasts = true;
                selectgroup.interactable = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping) NextSentence();
    }

    /* 여기부터는 버튼 */
    public void isSelectData(string[] selectdata)
    {
        foreach (string line in selectdata)
        {
            selectSentences.Enqueue(line);
        }
    }

    /*
    선택 버튼 -  힐링지수를 + 하던지 사진선택을 하던지 아이템을 선택하던지
        -> 각각 기능이 다르기 때문에 select id를 통해 구분!
    */

    public void firstSelect()
    {
        Clicksound.Play();
        selectgroup.alpha = 0;
        selectgroup.interactable = false;
        selectgroup.blocksRaycasts = false;

        if (StaticVal.selectID == 2) ImageSelectOK();
        else if (StaticVal.selectID == 1) HealingGreat();
        else if (StaticVal.selectID == 3) socket.instance.ImageResultGood();
        else if (StaticVal.selectID == 4) Newspapers.instance.liking_firstClick();

        nextText.SetActive(true);
        istyping = false;
        NextSentence();
    }

    public void secondSelect()
    {
        Clicksound.Play();
        selectgroup.alpha = 0;
        selectgroup.interactable = false;
        selectgroup.blocksRaycasts = false;

        if (StaticVal.selectID == 2) gallerySelectOK();
        else if (StaticVal.selectID == 1) HealingGood();
        else if (StaticVal.selectID == 3) socket.instance.ImageResultSoso();
        else if (StaticVal.selectID == 4) Newspapers.instance.liking_secondClick();

        nextText.SetActive(true);
        istyping = false;
        NextSentence();
    }

    public void thirdSelect()
    {
        Clicksound.Play();
        selectgroup.alpha = 0;
        selectgroup.interactable = false;
        selectgroup.blocksRaycasts = false;

        if (StaticVal.selectID == 2) ImageSelectNO();
        else if (StaticVal.selectID == 1) HealingBad();
        else if (StaticVal.selectID == 3) socket.instance.ImageResultBad();
        else if (StaticVal.selectID == 4) Newspapers.instance.liking_thirdClick();


        nextText.SetActive(true);
        istyping = false;
        NextSentence();
    }

    public void addSentence(string s)
    {
        sentences.Enqueue(s);
    }


    public void ImageSelectOK()
    {
        nativecam.instance.takepicture();
    }

    public void gallerySelectOK()
    {
        GalleryPickup.instance.sajingolra();
    }

    public void ImageSelectNO()
    {
        addSentence("알겠어.. 다음에 꼭 보여주길 바래");
    }


    public void HealingGreat()
    {
        Healing.instance.healing_QuestionQueue.Enqueue(1.0f);
    }

    public void HealingGood()
    {
        Healing.instance.healing_QuestionQueue.Enqueue(0.5f);
    }

    public void HealingBad()
    {
        Healing.instance.healing_QuestionQueue.Enqueue(0.05f);
    }
}