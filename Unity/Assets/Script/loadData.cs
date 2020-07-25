using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        for (int i = 0; i < Inventory.instance.slots.Count; i++)
        {
            PlayerPrefs.SetString("slots"+i,Inventory.instance.slots[i].itemName);
        }
        PlayerPrefs.SetInt("questID", StaticVal.questID);
        PlayerPrefs.SetInt("playerCoin", StaticVal.playerCoin);
        PlayerPrefs.SetFloat("healing_QuestionVal", Healing.healing_QuestionVal);
        PlayerPrefs.SetFloat("healing_PictureVal", Healing.healing_PictureVal);
        PlayerPrefs.SetFloat("healing_LetterVal", Healing.healing_LetterVal);
        PlayerPrefs.SetFloat("healing_BambooVal", Healing.healing_BambooVal);
        PlayerPrefs.SetFloat("de_healingVal", Healing.de_healingVal);

        Debug.Log("success save");
    }

    public void load()
    {
        if (PlayerPrefs.HasKey("slots"))
        {
            for (int i = 0; i < Inventory.instance.slots.Count; i++)
            {
                Inventory.instance.slots[i].itemName = PlayerPrefs.GetString("slots" + i);
                Inventory.instance.slotLoadData(Inventory.instance.slots[i].itemName);
            }
            Debug.Log("load slots");

        }
        if (PlayerPrefs.HasKey("questID"))
        {
            StaticVal.questID = PlayerPrefs.GetInt("questID");
            Debug.Log("load questID"+ StaticVal.questID);
        }

        if (PlayerPrefs.HasKey("playerCoin"))
        {
            StaticVal.playerCoin = PlayerPrefs.GetInt("playerCoin");
            Debug.Log("load playerCoin:"+ StaticVal.playerCoin);
        }

        if (PlayerPrefs.HasKey("healing_QuestionVal"))
        {
            StartHealing.healing_QuestionVal = PlayerPrefs.GetFloat("healing_QuestionVal");
            Debug.Log("load healing_QuestionVal:"+ Healing.healing_QuestionVal);
        }

        if (PlayerPrefs.HasKey("healing_PictureVal"))
        {
            StartHealing.healing_PictureVal = PlayerPrefs.GetFloat("healing_PictureVal");
        }

        if (PlayerPrefs.HasKey("healing_LetterVal"))
        {
            StartHealing.healing_LetterVal = PlayerPrefs.GetFloat("healing_LetterVal");
        }

        if (PlayerPrefs.HasKey("healing_BambooVal"))
        {
            StartHealing.healing_BambooVal = PlayerPrefs.GetFloat("healing_BambooVal");
        }
        if (PlayerPrefs.HasKey("currentPicEmotion"))
        {
            StartHealing.currentPicEmotion = PlayerPrefs.GetString("currentPicEmotion");
        }

        if (PlayerPrefs.HasKey("currentmikeEmotion"))
        {
            StartHealing.currentmikeEmotion = PlayerPrefs.GetString("currentmikeEmotion");
        }

        if (PlayerPrefs.HasKey("de_healingVal"))
        {
            StartHealing.de_healingVal = PlayerPrefs.GetFloat("de_healingVal");

        }

        if (PlayerPrefs.HasKey("songliking"))
        {
            StaticVal.songliking = PlayerPrefs.GetInt("songliking");

        }

        if (PlayerPrefs.HasKey("movieliking"))
        {
            StaticVal.movieliking = PlayerPrefs.GetInt("movieliking");

        }


        else
            Debug.Log("nothing load");

        Healing.instance.helingValLoad();


    }

}
