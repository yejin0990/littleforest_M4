using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
