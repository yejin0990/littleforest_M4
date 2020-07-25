using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public CanvasGroup Exitmenugroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exitmenugroup.alpha = 1;
            Exitmenugroup.interactable = true;
            Exitmenugroup.blocksRaycasts = true;
        }
    }

    public void ExitYes()
    {
        for (int i = 0; i < Inventory.instance.slots.Count; i++)
        {
            PlayerPrefs.SetString("slots" + i, Inventory.instance.slots[i].itemName);
        }
        Debug.Log("success slots");
        PlayerPrefs.SetInt("questID", StaticVal.questID);
        PlayerPrefs.SetInt("playerCoin", StaticVal.playerCoin);
        PlayerPrefs.SetFloat("healing_QuestionVal", Healing.healing_QuestionVal);
        Debug.Log("success question");
        PlayerPrefs.SetFloat("healing_PictureVal", Healing.healing_PictureVal);
        PlayerPrefs.SetFloat("healing_LetterVal", Healing.healing_LetterVal);
        PlayerPrefs.SetFloat("healing_BambooVal", Healing.healing_BambooVal);
        PlayerPrefs.SetFloat("de_healingVal", Healing.de_healingVal);
        PlayerPrefs.SetString("currentPicEmotion", Healing.instance.currentPicEmotion);
        PlayerPrefs.SetString("currentmikeEmotion", Healing.instance.currentmikeEmotion);

        PlayerPrefs.SetInt("songliking",StaticVal.songliking);
        PlayerPrefs.SetInt("movieliking", StaticVal.movieliking);

        Debug.Log("success save");

        Application.Quit();
    }

    public void ExitNo()
    {
        Exitmenugroup.alpha = 0;
        Exitmenugroup.interactable = false;
        Exitmenugroup.blocksRaycasts = false;
    }
}
