using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class miniTalkmanager : MonoBehaviour, IPointerDownHandler
{
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;  //queue : 선입선출
    Dictionary<int, string[]> talkData;

    public string currentSentence;

    public float typingSpeed = 0.1f;
    private bool istyping;
    public Animator miniDialogue;

    public static miniTalkmanager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<String>();
    }


    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        miniDialogue.SetBool("miniAppear", true);
        dialoguegroup.blocksRaycasts = true;

        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        StaticVal.Touchenable = 0;

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
        }
        else
        {
            miniDialogue.SetBool("miniAppear", false);
            dialoguegroup.blocksRaycasts = false;

            StaticVal.Touchenable = 1;

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
            nextText.SetActive(true);
            istyping = false;

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping) NextSentence();
    }
}