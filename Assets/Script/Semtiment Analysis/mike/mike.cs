using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        instance = this;

        miketalkData = new Dictionary<int, string>();

        //초기대답
        miketalkData.Add(0, "무슨 말인지 잘 들리지 않습니다.");
        //angry
        miketalkData.Add(11, "화난 감정은 다 털어놓으셨습니까?");
        //calm
        miketalkData.Add(21, "매우 침착한 목소리입니다.");
        //fearful
        miketalkData.Add(31, "두려운 일이 있으셨군요.");
        //happy
        miketalkData.Add(41, "행복한 일이 있었군요!");
        //sad
        miketalkData.Add(51, "슬픈 감정은 다 털어놓으셨습니까?");

        Closeclick = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mikegroup.alpha = 0;
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;

        mikeOutputObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void saveMike()
    {
        SavWav.Save("myfile", myAudioClip);
        socket.instance.RecordServer();
        miketext.text = "결과 받음";
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;
    }

    public void playmike()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myAudioClip;
        audio.Play();
    }

    public void openMikeUI()
    {
        
        mikegroup.alpha = 1;
        mikegroup.interactable = true;
        mikegroup.blocksRaycasts = true;

        StaticVal.Touchenable = 0;
        BambooBgm.instance.bamboobgmstop();

    }

    public void closeMikeUI()
    {
        mikegroup.alpha = 0;
        mikegroup.interactable = false;
        mikegroup.blocksRaycasts = false;

        playgroup.blocksRaycasts = false;
        savegroup.interactable = false;
        savegroup.blocksRaycasts = false;
        savegroup.interactable = false;

        mikeOutputObject.SetActive(false);

        Healing.instance.healingBamboo();
        StaticVal.Touchenable = 1;


        if (StaticVal.questID == 410) StaticVal.questID += 10;
        BambooBgm.instance.bambooMusicPlay();
        Closeclick.Play();

       
    }

    public void mikeOutput()
    {
        miketext.text = miketalkData[miketalkNum] + "\n혹시 결과가 마음에 안들면 다시 녹음해주세요.";
        mikeOutputObject.SetActive(true);
        mikegroup.interactable = true;
        mikegroup.blocksRaycasts = true;
    }
    
    public void sceneChange()
    {
        if (StaticVal.Touchenable == 1)
        {
            Closeclick.Play();
            //BambooBgm.instance.Bamboobackmusic.Stop();
            StaticVal.Touchenable = 1;
            StaticVal.scenenumber = 2;
            SceneManager.LoadScene(StaticVal.scenenumber);
            //Backgroundm.instance.AudioSource.Play();

        }
    }
}
