
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public CanvasGroup menugroup;
    public AudioSource bgmSource;
    public CanvasGroup SettingMenugroup;
    public CanvasGroup bgmON2group;
    public CanvasGroup bgmOFF2group;
    public CanvasGroup BagMenugroup;
    public CanvasGroup questMenu1group;
    public CanvasGroup questMenu2group;
    public CanvasGroup healingPapergroup;

    public CanvasGroup uigroup;

    public AudioSource eaudioSource;
    public AudioSource baudioSource;

    public static Menu instance;

    public GameObject album1;
    public GameObject album2;
    public GameObject album3;
    public GameObject album4;
    public GameObject album5;
    public GameObject album6;
    public GameObject album7;

    void Awake()
    {
        instance = this;

        eaudioSource = GetComponent<AudioSource>();
        baudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        if((StaticVal.scenenumber == 4)||(StaticVal.scenenumber == 5)||(StaticVal.scenenumber == 5))
        {
            uigroup.alpha = 0;
            uigroup.blocksRaycasts = false;
            uigroup.interactable = false;
        }
        else
        {
            uigroup.blocksRaycasts = true;
            uigroup.interactable = true;
            uigroup.alpha = 1;
        }
    }

    public void ShowMenu()
    {
        if (menugroup.alpha == 0)
        {
            menugroup.alpha = 1;
            menugroup.blocksRaycasts = true;
            menugroup.interactable = true;
        }
        else
        {
            menugroup.alpha = 0;
            menugroup.blocksRaycasts = false;
            menugroup.interactable = false;
        }

        eaudioSource.Play();
    }

    public void bgmON2()
    {
        GameObject.Find("BGMOFFButton").GetComponent<Image>().color = new Color(1, 1, 1);
        GameObject.Find("BGMONButton").GetComponent<Image>().color = new Color(52/255f, 233/255f, 1);
        bgmON2group.blocksRaycasts = false;
        bgmOFF2group.blocksRaycasts = true;
        Backgroundm.instance.bgmON();
        eaudioSource.Play();
    }

    public void bgmOFF2()
    {
        GameObject.Find("BGMONButton").GetComponent<Image>().color = new Color(1, 1, 1);
        GameObject.Find("BGMOFFButton").GetComponent<Image>().color = new Color(52/255f, 233/255f, 1);
        bgmON2group.blocksRaycasts = true;
        bgmOFF2group.blocksRaycasts = false;
        Backgroundm.instance.bgmOFF();
        eaudioSource.Play();

    }



    public void SettingMenuOpen()
    {
        if(StaticVal.Touchenable == 1)
        {
            SettingMenugroup.alpha = 1;
            SettingMenugroup.blocksRaycasts = true;
            SettingMenugroup.interactable = true;
            StaticVal.Touchenable = 0;

            menugroup.alpha = 0;
            menugroup.blocksRaycasts = false;
            menugroup.interactable = false;

        }
        eaudioSource.Play();
    }

    public void SettingMenuClose()
    {
        SettingMenugroup.alpha = 0;
        SettingMenugroup.blocksRaycasts = false;
        SettingMenugroup.interactable = false;
        StaticVal.Touchenable = 1;

        eaudioSource.Play();
    }

    public void BagMenuOpen()
    {
        if (StaticVal.Touchenable == 1)
        {
            BagMenugroup.alpha = 1;
            BagMenugroup.blocksRaycasts = true;
            BagMenugroup.interactable = true;
            StaticVal.Touchenable = 0;

            menugroup.alpha = 0;
            menugroup.blocksRaycasts = false;
            menugroup.interactable = false;
        }
        eaudioSource.Play();
    }

    public void BagMenuClose()
    {
        BagMenugroup.alpha = 0;
        BagMenugroup.blocksRaycasts = false;
        BagMenugroup.interactable = false;
        StaticVal.Touchenable = 1;

        eaudioSource.Play();
    }

    public void QuestMenuOpen()
    {
        if (StaticVal.Touchenable == 1)
        {
            questMenu1group.alpha = 1;
            questMenu1group.interactable = true;
            questMenu1group.blocksRaycasts = true;
            StaticVal.Touchenable = 0;

            menugroup.alpha = 0;
            menugroup.blocksRaycasts = false;
            menugroup.interactable = false;
        }

        eaudioSource.Play();
    }

    public void QuestMenu1to2()
    {
        questMenu1group.alpha = 0;
        questMenu1group.interactable = false;
        questMenu1group.blocksRaycasts = false;
        questMenu2group.alpha = 1;
        questMenu2group.interactable = true;
        questMenu2group.blocksRaycasts = true;

        baudioSource.Play();
    }

    public void QuestMenu2to1()
    {
        questMenu2group.alpha = 0;
        questMenu2group.interactable = false;
        questMenu2group.blocksRaycasts = false;
        questMenu1group.alpha = 1;
        questMenu1group.interactable = true;
        questMenu1group.blocksRaycasts = true;

        baudioSource.Play();
    }

    public void QuestClose()
    {
        questMenu1group.alpha = 0;
        questMenu1group.interactable = false;
        questMenu1group.blocksRaycasts = false;
        questMenu2group.alpha = 0;
        questMenu2group.interactable = false;
        questMenu2group.blocksRaycasts = false;
        StaticVal.Touchenable = 1;

        eaudioSource.Play();
    }

    public void ShowHealingPaper()
    {
        healingPapergroup.alpha = 1;
        healingPapergroup.blocksRaycasts = true;
        healingPapergroup.interactable = true;

        eaudioSource.Play();
    }

    public void CancelHealingPaper()
    {
        healingPapergroup.alpha = 0;
        healingPapergroup.blocksRaycasts = false;
        healingPapergroup.interactable = false;

        eaudioSource.Play();
    }
}
