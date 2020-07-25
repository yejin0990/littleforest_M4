using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explanation : MonoBehaviour
{
    public static Explanation instance;
    public GameObject explanationObject;

    public Text explanationText;
    Dictionary<string, string> explanationData;

    private void Awake()
    {
        instance = this;

        explanationData = new Dictionary<string, string>();

        //초기대답
        explanationData.Add("처음", "리틀 포레스트에 오신 것을 환영합니다.\n" +
            "바깥 세상에서 지친 당신을 위해\n" +
            "힐링할 수 있도록 마을 주민들께 말해 놓았습니다.\n" +
            "먼저 이 마을의 이장님인 이장임을 찾아가 보세요.");
        explanationData.Add("구글핏", "");
        explanationData.Add("음성", "");
        explanationData.Add("편지", "");
    }

    // Start is called before the first frame update
    void Start()
    {
        explanationObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openExplanation()
    {
        explanationText.text = explanationData["처음"];
        explanationObject.SetActive(true);
    }

    public void closeExplanation()
    {
        explanationObject.SetActive(false);
    }
}
