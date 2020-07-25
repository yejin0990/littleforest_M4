using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public static Healing instance;
    
    public Slider healingBar;

    public static float  healing_QuestionVal;
    public static float healing_PictureVal;
    public static float healing_LetterVal;
    public static float healing_BambooVal;

    public static float de_healingVal;

    public Queue<float> healing_QuestionQueue;
    public float healingVal = 0;

    public Text pictureText;
    public Text letterText;
    public Text bambooText;
    public Text happyScoreText;
    
    //힐링 진단서 필드 !
    public string currentPicEmotion="";
    public string currentmikeEmotion="";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        healingBar.value = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(StartHealing.instance == null)
        {
            helingValLoad2();
        }
        else
            helingValLoad();

        healing_QuestionQueue = new Queue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        healingBar.value = healingVal;
    }

    void FixedUpdate()
    {        
        int t = DateTime.Now.Hour;
        if (t == 5)
        {
            healing_LetterVal = 0;
            healing_BambooVal = 0;
            healing_PictureVal = 0;
            de_healingVal = 0;

            MoneyTree.instance.CointreeObject.SetActive(true);
        }
    }

    public void healingValCalculation()
    {
        healing_QuestionVal = 0;
        healing_QuestionVal += 0.01f * healing_QuestionQueue.Dequeue();  // 플러스 질문
        healing_QuestionVal += 0.14f * healing_QuestionQueue.Dequeue(); //경제력
        healing_QuestionVal += 0.105f * healing_QuestionQueue.Dequeue(); //외모
        healing_QuestionVal += 0.07f * healing_QuestionQueue.Dequeue(); //건강
        healing_QuestionVal += 0.04f * healing_QuestionQueue.Dequeue(); //이성친구
        healing_QuestionVal += 0.095f * healing_QuestionQueue.Dequeue(); //타인과의 원만한 관계
        healing_QuestionVal += 0.185f * healing_QuestionQueue.Dequeue(); //자기수용감
        healing_QuestionVal += 0.145f * healing_QuestionQueue.Dequeue(); //자기계발
        healing_QuestionVal += 0.065f * healing_QuestionQueue.Dequeue(); //책임감
        healing_QuestionVal += 0.155f * healing_QuestionQueue.Dequeue(); //여가활동

        healingVal += healing_QuestionVal;
        happyScoreText.text = healing_QuestionVal.ToString() + "점이양!";
    }

    public void healingPicture()
    {
        pictureText.text = currentPicEmotion;
        healingVal += healingVal * 0.5f * healing_PictureVal * 2.0f / 3.0f;
        StaticVal.newspaperOpenNum++;
        de_healingVal += healing_PictureVal;
    }

    public void healingBamboo()
    {
        bambooText.text = currentmikeEmotion;
        healingVal += healingVal * 0.5f * healing_BambooVal * 2.0f / 3.0f;
        StaticVal.newspaperOpenNum++;
        Debug.Log("bamboo text",bambooText);
        de_healingVal += healing_BambooVal;
    }

    public void healingLetter()
    {
        if(healing_LetterVal > 0)
        {
            letterText.text = "긍정: "+(healing_LetterVal*100.0f).ToString();
        }
        else if (healing_LetterVal < 0)
        {
            letterText.text = "부정: " + (-healing_LetterVal * 100.0f).ToString();
        }
        else
        {
            letterText.text = "그냥 저냥";
        }
        StaticVal.newspaperOpenNum++;
        healingVal += healingVal * 0.5f * (healing_LetterVal * 0.5f) * 2.0f / 3.0f;
        de_healingVal += (healing_LetterVal * 0.5f);
    }
    public void helingValLoad()
    {
        healing_QuestionVal = StartHealing.healing_QuestionVal;
        healing_PictureVal = StartHealing.healing_PictureVal;
        healing_LetterVal = StartHealing.healing_LetterVal;
        healing_BambooVal = StartHealing.healing_BambooVal;
        de_healingVal = StartHealing.de_healingVal;
        currentPicEmotion = StartHealing.currentPicEmotion;
        currentmikeEmotion = StartHealing.currentmikeEmotion;
        if (healing_LetterVal != 0.0) healingLetter();
        if(healing_PictureVal != 0.0) healingPicture();
        if (healing_BambooVal != 0.0) healingBamboo();
        if(healing_QuestionVal != 0.0)
        {
            healingVal += healing_QuestionVal;
            happyScoreText.text = healing_QuestionVal.ToString() + "점이양!";
        }
    }

    public void helingValLoad2()
    {
        if (healing_LetterVal != 0.0) healingLetter();
        if (healing_PictureVal != 0.0) healingPicture();
        if (healing_BambooVal != 0.0) healingBamboo();
        if (healing_QuestionVal != 0.0)
        {
            healingVal += healing_QuestionVal;
            happyScoreText.text = healing_QuestionVal.ToString() + "점이양!";
        }
    }
}