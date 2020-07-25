using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Question : MonoBehaviour
{
    public GameObject questionText;
    public GameObject example1Text;
    public GameObject example2Text;

    public AudioSource gamesound;

    public Text getCoin;

    Dictionary<string, string>[] problems = {
        new Dictionary<string,string>(){
            {"question", "'빈털털이'와 '빈털터리' 어떤 것이 맞는 말입니까?"},
            {"answer", "빈털터리"},
            {"example1", "빈털터리"},
            {"example2", "빈털털이"} },
        new Dictionary<string,string>(){
            {"question", "'갈갈이'와 '갈가리' 어떤 것이 맞는 말입니까?"},
            {"answer", "갈가리"},
            {"example1", "갈갈이"},
            {"example2", "갈가리"}},
        new Dictionary<string,string>(){
            {"question", "'놓여진'와 '놓인' 어떤 것이 맞는 말입니까?"},
            {"answer", "놓인"},
            {"example1", "놓여진"},
            {"example2", "놓인"},},
        new Dictionary<string,string>(){
            {"question", "'수군거리다'와 '수근거리다' 어떤 것이 맞는 말입니까?"},
            {"answer", "수군거리다"},
            {"example1", "수근거리다"},
            {"example2", "수군거리다"}},
        new Dictionary<string,string>(){
            {"question", "'설레임'와 '설렘' 어떤 것이 맞는 말입니까?"},
            {"answer", "설렘"},
            {"example1", "설렘"},
            {"example2", "설레임"}},
        new Dictionary<string,string>(){
            {"question", "속이 '메슥거려요'와 '미슥거려요' 어떤 것이 맞는 말입니까?"},
            {"answer", "메슥거려요"},
            {"example1", "미슥거려요"},
            {"example2", "메슥거려요"}},
        new Dictionary<string,string>(){
            {"question", "'어떻던'과 '어떻든' 어떤 것이 맞는 말입니까?"},
            {"answer", "어떻든"},
            {"example1", "어떻든"},
            {"example2", "어떻던"}},
        new Dictionary<string,string>(){
            {"question", "'곤욕'과 '곤혹' 어떤 것이 맞는 말입니까?"},
            {"answer", "곤혹"},
            {"example1", "곤욕"},
            {"example2", "곤혹"}},

    };

    Dictionary<int, int> Problemsave = new Dictionary<int, int>();
    int i;

    int problemNumber = 0;
    string question = "";
    string answer = "";
    string example1 = "";
    string example2 = "";

    int totalCorrect = 0;
    public GameObject totalCorrectText;
    public GameObject correctIncorrectText;

    int buttoncount = 0;

    public GameObject confirmwindow;


   void Awake()
    {
        gamesound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        problemNumber = Random.Range(0, 7);
        Problemsave.Add(problemNumber, i);

        ShowProblem();

        totalCorrectText.GetComponent<Text>().text = "0";
        correctIncorrectText.GetComponent<Text>().text = "Hi~ 방가워요!";
    }

    void ShowProblem()
    {

        question = problems[problemNumber]["question"];
        answer = problems[problemNumber]["answer"];
        example1 = problems[problemNumber]["example1"];
        example2 = problems[problemNumber]["example2"];
        questionText.GetComponent<Text>().text = question;
        example1Text.GetComponent<Text>().text = example1;
        example2Text.GetComponent<Text>().text = example2;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelectExample(string example)
    {
        Debug.Log(example);
        if (answer.Equals(example))
        {
            totalCorrect += 1;
            totalCorrectText.GetComponent<Text>().text = "맞힌 문제 갯수 :" + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "맞아요!";
        }
        else
        {
            correctIncorrectText.GetComponent<Text>().text = "이거 맏아요?";
        }

        problemNumber = Random.Range(0, 7);
        if (Problemsave.ContainsKey(problemNumber))
        {
            problemNumber = Random.Range(0, 7);
            Problemsave.Add(problemNumber, i);
            ShowProblem();
        }
        else
        {
            Problemsave.Add(problemNumber, i);
            ShowProblem();
        }      
        

        if (buttoncount == 2)
        {
            Debug.Log("ExitGame");
            ShowconfirmBox();
        }
    }

    void ShowconfirmBox()
    {       
        getCoin.text = (totalCorrect * 3).ToString();
        confirmwindow.SetActive(true);
        Backgroundm.instance.AudioSource.Stop();
    }

    public void ExitGame()
    {
        if (StaticVal.questID == 830) Questmanager.instance.quest830End();
        gamesound.Play();
        StaticVal.playerCoin += totalCorrect * 3;
        SceneManager.LoadScene("SubScene");
    }

    public void Example1ButtonClicked()
    {
        gamesound.Play();
        Debug.Log("Example1ButtonClicked");
        SelectExample(example1);
        buttoncount++;
    }

    public void Example2ButtonClicked()
    {
        gamesound.Play();
        Debug.Log("Example2ButtonClicked");
        SelectExample(example2);
        buttoncount++;
    }

}

