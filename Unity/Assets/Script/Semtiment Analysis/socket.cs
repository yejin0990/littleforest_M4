using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;


public class socket : MonoBehaviour
{
    public static socket instance;
    Dictionary<int, string[]> talkData;

    public Sprite Image { get; private set; }

    public string ipAd;
    public string temperature = "";
    public string weatherState = "";

    private void Awake()
    {
        instance = this;
        //사진 감정분석 결과 대사
        talkData = new Dictionary<int, string[]>();
        
        //알수없음
        talkData.Add(10, new string[] { "너의 표정을 읽지 못하겠어...\n다시 제대로 사진찍을꺼면 한번 더 찾아와줘~!" });
        //Happy
        talkData.Add(20, new string[] { "아하! 네 표정 알겠어! 지금 무척 행복한 표정이구나?!\n너가 기뻐하니까 나도 기분이 좋네" });
        //Fear
        talkData.Add(30, new string[] { "뭐지...? 내가 잘못본건가...?\n지금 두려운 일이 있는거야?" });
        //Sad
        talkData.Add(40, new string[] { "흠.. 내가 잘못본게 아니라면 너는 지금 슬프구나...\n슬프하지마 nonono~\n혼자가 아냐 nonono~" });
        //Angry
        talkData.Add(50, new string[] { "화가 잔뜩 나있구나.. 오늘 무슨 일이 있던거야?\n화를 조금 가라앉히는 건 어떨까?" });
        //Surprise
        talkData.Add(60, new string[] { "왜 놀랐어!! 놀랄 일이 뭐가 있다고..!" });
        //여러사람
        talkData.Add(70, new string[] { "여러 명의 사람들이 있어서 \n너가 누군지 정확히 모르겠어...","너만 있는 사진이 좋아~\n다시 찍을 꺼면 다시 찾아와줘~!" });
        
        //select
        talkData.Add(100, new string[] { "어떻게 알았지?","그 정도면 뭐...","전혀 아닌데?" });

        //선택 후
        talkData.Add(110, new string[] { "역시 내 눈썰미는 정확하다니까~~\n앗 지금 이장님이 널 찾는거 같은데 한번 가볼래?",
        "내 눈썰미는 역시 정확하다니까~!"});
        talkData.Add(120, new string[] { "표정이 조금 애매하긴 했지만...\n일단 어느정도는 인정한다는 거지?!\n앗 지금 이장님이 널 찾는거 같은데 한번 가볼래?",
        "표정이 조금 애매하긴 했지만\n어느 정도는 인정한다는 거지?"});
        talkData.Add(130, new string[] {  "그럼 다시 한번 기회를 줘!\n꼭 나에게 다시 찾아와서 사진을 보여줘야해~!",
            "그럼 내게 다시 기회를 줄 수 있어?\n다시 와서 사진을 한번만 더 보여줘..." });
    }

    void Start()
    {
        string externalip = new System.Net.WebClient().DownloadString("http://ipinfo.io/ip").Trim();
        Debug.Log(externalip);
        ipAd = externalip.ToString();
    }

    // coroutine
    public void ImageServer_C()
    {
        StartCoroutine("StartgoC");
        Debug.Log("Image Server Start!");
    }
    public void ImageServer_G()
    {
        StartCoroutine("StartgoG");
    }

    public void RecordServer()
    {
        StartCoroutine("RecordStartgo");
    }

    public void TextServer()
    {
        StartCoroutine("TextStartgo");
    }

    public void WeatherServer()
    {
        StartCoroutine("WeatherStartgo");
    }

    IEnumerator StartgoC()
    {
        yield return UploadPNG();
    }
    IEnumerator StartgoG()
    {
        yield return UploadPNG1();
    }

    IEnumerator RecordStartgo()
    {
        yield return UploadWAV();
    }
    
    IEnumerator TextStartgo()
    {
        yield return UploadTEXT();
    }

    IEnumerator WeatherStartgo()
    {
        yield return UploadWeather();
    }
    //카메라 사진을 서버와 통신하여 감정분석
    IEnumerator UploadPNG()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        

        byte[] bytes = nativecam.instance.bytes;
        

        Debug.Log("socket  "+bytes[0]);
        

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("image", bytes);
        



        // Upload to a cgi script
        WWW w = new WWW("http://35.184.192.93:443/", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Finished Uploading Screenshot");
            Debug.Log(w.text);
        }

        if(w.text != null)
        {
            int talknum = whichEmotion(w.text);
            string[] talkdata = talkData[talknum];
            StaticVal.selectID = 3;
            isSelectsentences(talknum);
            Talkmanager.instance.Ondialogue(talkdata);
        }
        
    }
    
    //갤러리선택 사진을 서버와 통신하여 감정분석
    IEnumerator UploadPNG1()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

       //갤러리에서 선택된 이미지 바이트로 변환
        byte[] bytes = GalleryPickup.instance.bytes;


        Debug.Log("socket  " + bytes[0]);


        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("image", bytes);




        // Upload to a cgi script
        WWW w = new WWW("http://35.184.192.93:443/", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Finished Uploading Screenshot");
            Debug.Log(w.text);
        }

        if (w.text != null)
        {
            int talknum = whichEmotion(w.text);
            string[] talkdata = talkData[talknum];
            StaticVal.selectID = 3;
            isSelectsentences(talknum);
            Talkmanager.instance.Ondialogue(talkdata);
        }
    }

    //녹음된 파일을 서버와 통신하여 감정분석
        IEnumerator UploadWAV()
    {
        yield return new WaitForEndOfFrame();


        string path = Application.persistentDataPath + "/myfile.wav";
        byte[] bytes = File.ReadAllBytes(path);
        Debug.Log("저장"+ bytes.ToString());


        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("image", bytes);

        // Upload to a cgi script
        WWW w = new WWW("http://35.184.192.93:443/", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Finished Uploading Screenshot");
            Debug.Log(w.text);
        }

        if (w.text != null)
        {
            mike.instance.miketalkNum = whichMikeEmotion(w.text);
            mike.instance.mikeOutput();
        }
    }
    //편지 텍스트를 서버와 통신하여 감정분석
    IEnumerator UploadTEXT()
    {
        string path = Application.persistentDataPath + "/mytextfile.txt";
        byte[] bytes = File.ReadAllBytes(path);

        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("text", bytes);

        // Upload to a cgi script
        WWW w = new WWW("http://35.184.192.93:443/", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Finished Uploading Screenshot");
            Debug.Log(w.text);
            CLetter.instance.letterInt = whichLetterEmotion(w.text);
            CLetter.instance.getLetter();
        }
    }
    //위치정보를 서버와 통신하여 날씨받아오기
    IEnumerator UploadWeather()
    {

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(ipAd);

        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("weather", bytes);

        // Upload to a cgi script
        WWW w = new WWW("http://35.184.192.93:443/", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("날씨");
            Debug.Log(w.text);
            howWeather(w.text);
        }
    }
    //사진 감정분석 결과에 따라 힐링지수반영
    public int whichEmotion(string text)
    {
        bool happy = text.Contains("happy");
        bool fear = text.Contains("fear");
        bool sad = text.Contains("sad");
        bool angry = text.Contains("angry");
        bool surprised = text.Contains("surprised");

        int emotion_num = 0;

        if (happy == true) { emotion_num++; }
        if (fear == true) { emotion_num++; }
        if (sad == true) { emotion_num++; }
        if (angry == true) { emotion_num++; }
        if (surprised == true) { emotion_num++; }

        if (emotion_num > 1) { return 70; }
        else if (happy == true) {
            Debug.Log("행복");
            Healing.instance.currentPicEmotion = "행복한 표정";
            Healing.healing_PictureVal = 0.05f;
            return 20; }
        else if (fear == true) {
            Healing.healing_PictureVal = -0.02f;
            Healing.instance.currentPicEmotion = "두려운 표정";
            Debug.Log("두려움");
            return 30; }
        else if (sad == true) {
            Healing.healing_PictureVal = -0.05f;
            Healing.instance.currentPicEmotion = "슬픈 표정";
            Debug.Log("슬픔");
            return 40; }
        else if (angry == true) {
            Healing.healing_PictureVal = -0.05f;
            Healing.instance.currentPicEmotion = "화난 표정";
            Debug.Log("화남");
            return 50; }
        else if (surprised == true) {
            Healing.healing_PictureVal = 0.0f;
            Healing.instance.currentPicEmotion = "놀란 표정";
            Debug.Log("놀람");
            return 60; }
        else {
            Debug.Log("아무것도 없어.....");
            return 10; }
    }

    //텍스트 감정분석결과에 따라 힐링지수 반영
    public int whichLetterEmotion(string text)
    {
        char sp = '\n';

        string[] splitText = text.Split(sp);

        Debug.Log(splitText[10].ToString());
     
        if (splitText[10].Contains("-"))
        {
            Healing.healing_LetterVal = float.Parse(splitText[10]);
            return 21;
        }
        else if (splitText[9].Contains("0.0"))
        {
            Healing.healing_LetterVal = float.Parse(splitText[10]);
            return 31;
        }
        else
        {
            Healing.healing_LetterVal = float.Parse(splitText[10]);
            return 11;
        }
    }

    //음성 감정분석결과에 따라 힐링지수 반영
    public int whichMikeEmotion(string text)
    {

        if (text.Contains("angry"))
        {
            Healing.healing_BambooVal = -0.05f;
            Healing.instance.currentmikeEmotion = "화난 목소리";
            return 11;
        }
        else if (text.Contains("calm")){
            Healing.healing_BambooVal = 0.02f;
            Healing.instance.currentmikeEmotion = "침착한 목소리";
            return 21;
        }
        else if (text.Contains("fearful"))
        {
            Healing.healing_BambooVal = -0.02f;
            Healing.instance.currentmikeEmotion = "두려운 목소리";
            return 31;
        }
        else if (text.Contains("happy"))
        {
            Healing.healing_BambooVal = 0.05f;
            Healing.instance.currentmikeEmotion = "행복한 목소리";
            return 41;
        }
        else if (text.Contains("sad"))
        {
            Healing.healing_BambooVal = -0.05f;
            Healing.instance.currentmikeEmotion = "슬픈 목소리";
            return 51;
        }
        else
        {
            return 0;
        }
    }
    //날씨결과에 따라 날씨 이미지 변환
    public void howWeather(string text)
    {
        char sp = '\n';
        string[] splitText = text.Split(sp);
        string s = splitText[10].ToString();
        string[] splitText2 = s.Split(',');

        Debug.Log(splitText2[0]);
        // temperature = float.Parse(splitText2[0]);
        temperature = splitText2[0];
        weatherState = splitText2[1];

    }

    public void isSelectsentences(int talknum)
    {
        string[] blank = { "", "", "" };

        if ((talknum == 10) || (talknum == 70))
        {
            Talkmanager.instance.isSelectData(blank);
        }
        else
        {
            Talkmanager.instance.isSelectData(talkData[100]);
        }
        Talkmanager.instance.isSelectData(blank);
        Talkmanager.instance.isSelectData(blank);
    }

    public void ImageResultGood()
    {
        isSelectsentences(0);
        if(StaticVal.questID < 400) Talkmanager.instance.addSentence(talkData[110][0]);
        else Talkmanager.instance.addSentence(talkData[110][1]);
        Healing.instance.healingPicture();
        if (StaticVal.questID == 300) Questmanager.instance.quest300End();
    }
    public void ImageResultSoso()
    {
        isSelectsentences(0);
        if (StaticVal.questID < 400) Talkmanager.instance.addSentence(talkData[120][0]);
        else Talkmanager.instance.addSentence(talkData[120][1]);
        Healing.instance.healingPicture();
        if (StaticVal.questID == 300) Questmanager.instance.quest300End();
    }
    public void ImageResultBad()
    {
        isSelectsentences(0);
        if (StaticVal.questID < 400) Talkmanager.instance.addSentence(talkData[130][0]);
        else Talkmanager.instance.addSentence(talkData[130][1]);
    }
}
