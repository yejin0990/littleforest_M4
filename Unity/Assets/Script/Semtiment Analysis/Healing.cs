using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
힐링 지수 계산
*/

public class Healing : MonoBehaviour
{
    public static Healing instance;
    
    public Slider healingBar;   // 힐링 바

    public static float  healing_QuestionVal;   // 질문 결과 계산
    public static float healing_PictureVal;     // 사진 결과 계산
    public static float healing_LetterVal;      // 텍스트 분석 계산
    public static float healing_BambooVal;      // 음성 녹음 계산

    public static float de_healingVal;  // 힐링지수 변화량

    public Queue<float> healing_QuestionQueue;
    public float healingVal = 0;

    public Text pictureText; 
    public Text letterText;
    public Text bambooText;
    public Text happyScoreText;
    
    //힐링 진단서 필드
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

    void Start()
    {
        // 게임 시작할 때 저장되어있던 값 받아오기
        if(StartHealing.instance == null)
        {
            helingValLoad2();
        }
        else
            helingValLoad();

        healing_QuestionQueue = new Queue<float>();
    }

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

    // 질문 계산
    public void healingValCalculation()
    {   
        // 비율은 "한국 성인의 행복한 삶의 구성요인 탐색 및 척도 개발" 논문 참고
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

    // 사진 감정 분석 후 결과 계산
    public void healingPicture()
    {
        // 감정 분석 결과가 angry, happy 등 감정을 표현하는 단어로 나오기 때문에 값은 임의로 설정
        pictureText.text = currentPicEmotion;
        healingVal += healingVal * 0.5f * healing_PictureVal * 2.0f / 3.0f;
        StaticVal.newspaperOpenNum++;
        de_healingVal += healing_PictureVal;
    }

    // 음성 감정 분석 후 결과 계산
    public void healingBamboo()
    {
        // 감정 분석 결과가 angry, happy 등 감정을 표현하는 단어로 나오기 때문에 값은 임의로 설정
        bambooText.text = currentmikeEmotion;
        healingVal += healingVal * 0.5f * healing_BambooVal * 2.0f / 3.0f;
        StaticVal.newspaperOpenNum++;
        Debug.Log("bamboo text",bambooText);
        de_healingVal += healing_BambooVal;
    }

    // 편지(텍스트) 감정 분석 후 결과 계산
    public void healingLetter()
    {
        // 감정 분석 결과가 수치로 나오기 때문에 그대로 활용
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

    // 계산 후 힐링 진단서에 띄우기
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