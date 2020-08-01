using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*힐링지수 바에 저장된 데이터를 시작시에 바로 로드
(이 스크립트는 스타트씬에서 로드된 데이터를 저장해서 메인씬의 힐링지수바에 적용시킴)
*/
public class StartHealing : MonoBehaviour
{
    public static float healing_QuestionVal;
    public static float healing_PictureVal;
    public static float healing_LetterVal;
    public static float healing_BambooVal;
    public static string currentPicEmotion;
    public static string currentmikeEmotion;

    public static float de_healingVal;

    public static StartHealing instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
