using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
대나무 숲에서 음성 감정 분석 UI
*/

[RequireComponent(typeof(AudioSource))]
public class mike : MonoBehaviour
{
    public static mike instance;

    public AudioClip myAudioClip;
    public CanvasGroup mikegroup;
    public CanvasGroup playgroup;
    public CanvasGroup savegroup;

    Dictionary<int, string> miketalkData;
    public int miketalkNum;

    public GameObject mikeOutputObject;
    public Text miketext;

    public AudioSource Closeclick;

    // 결과 대사 data
    private void Awake()
    {
        instance = this;

        miketalkData = new Dictionary<int, string>();

        // 알수없음
        miketalkData.Add(0, "무슨 말인지 잘 들리지 않습니다.");
        // angry
        miketalkData.Add(11, "화난 감정은 다 털어놓으셨습니까?");
        // calm
        miketalkData.Add(21, "매우 침착한 목소리입니다.");
        // fearful
        miketalkData.Add(31, "두려운 일이 있으셨군요.");
        // happy
        miketalkData.Add(41, "행복한 일이 있었군요!");
        // sad
        miketalkData.Add(51, "슬픈 감정은 다 털어놓으셨습니까?");

        Closeclick = GetComponent<AudioSource>();
    }

    void Start()
    {
        mikegroup.alpha = 0;
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;

        mikeOutputObject.SetActive(false);
    }

    // 녹음 버튼
    public void recordMike()
    {
        foreach (string device in Microphone.devices)
        {
            Debug.Log(device);
        }
        myAudioClip = Microphone.Start(null,false, 10, 44100);

        playgroup.blocksRaycasts = true;
        savegroup.interactable = true;
        savegroup.blocksRaycasts = true;
        savegroup.interactable = true;
    }
    
    // 저장 버튼
    public void saveMike()
    {
        SavWav.Save("myfile", myAudioClip);
        socket.instance.RecordServer();
        miketext.text = "결과 받음";
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;
    }

    // 재생 버튼 ( 녹음 된 목소리를 들어봄 )
    public void playmike()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myAudioClip;
        audio.Play();
    }

    // 구덩이 누르면 UI 뜸
    public void openMikeUI()
    {
        mikegroup.alpha = 1;
        mikegroup.interactable = true;
        mikegroup.blocksRaycasts = true;

        StaticVal.Touchenable = 0;
        BambooBgm.instance.bamboobgmstop();
    }

    // UI 닫기 버튼
    public void closeMikeUI()
    {
        // UI 관련 비활성화
        mikegroup.alpha = 0;
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;

        playgroup.blocksRaycasts = false;
        savegroup.interactable = false;
        savegroup.blocksRaycasts = false;
        savegroup.interactable = false;

        mikeOutputObject.SetActive(false);

        Healing.instance.healingBamboo();   // 녹음 결과 힐링지수 계산
        StaticVal.Touchenable = 1;

        // 퀘스트 진행을 위해
        if (StaticVal.questID == 410) StaticVal.questID += 10;
        BambooBgm.instance.bambooMusicPlay();
        Closeclick.Play();
    }

    // 결과 띄우기
    public void mikeOutput()
    {
        miketext.text = miketalkData[miketalkNum] + "\n혹시 결과가 마음에 안들면 다시 녹음해주세요.";
        mikeOutputObject.SetActive(true);
        mikegroup.interactable = true;
        mikegroup.blocksRaycasts = true;
    }
    
    // 메인 씬으로 이동
    public void sceneChange()
    {
        if (StaticVal.Touchenable == 1)
        {
            Closeclick.Play();
            StaticVal.Touchenable = 1;
            StaticVal.scenenumber = 2;
            SceneManager.LoadScene(StaticVal.scenenumber);
        }
    }
}
