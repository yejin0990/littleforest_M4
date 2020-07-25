using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questmanager : MonoBehaviour
{
    public static Questmanager instance;
    public List<Item> Items = new List<Item>();

    public GameObject newspaperButtonObject;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Items.Add(ItemDatabase.instance.items[0]);
        Items.Add(ItemDatabase.instance.items[1]);

        if (StaticVal.questID > 130) Menu.instance.album1.SetActive(false);
        if (StaticVal.questID > 210) Menu.instance.album2.SetActive(false);
        if (StaticVal.questID > 300) Menu.instance.album3.SetActive(false);
        if (StaticVal.questID > 550) Menu.instance.album4.SetActive(false);
        if (StaticVal.questID > 620) Menu.instance.album5.SetActive(false);
        if (StaticVal.questID > 780) Menu.instance.album6.SetActive(false);
        if (StaticVal.questID > 840) Menu.instance.album7.SetActive(false);

        if(StaticVal.questID < 420) newspaperButtonObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVal.questID < 400) StaticVal.Post_bamboo_Num = 0;

        if (StaticVal.questID == 610) quest610End();
        else if (StaticVal.questID == 710) quest710End();
        else if (StaticVal.questID == 730) quest730End();
        else if (StaticVal.questID == 750) quest750End();
        else if (StaticVal.questID == 770) quest770End();
        else if (StaticVal.questID == 810) quest810End();
    }

    public void quest0End()
    {
        StaticVal.questID += 100;
        Debug.Log(StaticVal.questID);
    }

    public void quest100End()
    {
        CurrentQuest.instance.quest100();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }

    public void quest110End()
    {
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }

    public void quest120End()
    {
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }

    public void quest130End()
    {
        StaticVal.questID = 200;
        Menu.instance.album1.SetActive(false);
        Debug.Log(StaticVal.questID);
    }


    public void quest200End()
    {
        CurrentQuest.instance.quest200();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest210End()
    {
        StaticVal.questID = 300;
        Menu.instance.album2.SetActive(false);
        CurrentQuest.instance.quest300();
        Debug.Log(StaticVal.questID);
    }


    public void quest300End()
    {
        StaticVal.questID = 400;
        Menu.instance.album3.SetActive(false);
        Debug.Log(StaticVal.questID);
    }
    public void quest400End()
    {
        CurrentQuest.instance.quest400();
        // 우체통 사용 방법 추가
        StaticVal.Post_bamboo_Num += 1;
        Debug.Log(StaticVal.questID);
    }
    public void quest410End()
    {
        // 대나무 숲 사용방법 추가
        StaticVal.Post_bamboo_Num += 1;
        Debug.Log(StaticVal.questID);
    }
    public void quest420End()
    {
        newspaperButtonObject.SetActive(true);
        StaticVal.questID = 500;
        Debug.Log(StaticVal.questID);
    }

    public void quest500End()
    {
        CurrentQuest.instance.quest500();
        StaticVal.questID += 10;
        Inventory.instance.slots.Add(Items[0]);
        Inventory.instance.slotImageChange();
        Debug.Log(StaticVal.questID);
    }
    public void quest510End()
    {
        int c = Inventory.instance.findItem("green");
        Inventory.instance.useItem(c);

        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest520End()
    {
        SubsceneManager.instance.pighouseFirst();
        Inventory.instance.slots.Add(Items[1]);
        Inventory.instance.slotImageChange();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest530End()
    {
        int i = Inventory.instance.findItem("apple");
        Inventory.instance.useItem(i);
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest540End()
    {
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest550End()
    {
        StaticVal.questID = 600;
        Menu.instance.album4.SetActive(false);
        SubsceneManager.instance.pighouseEmpty();
        Debug.Log(StaticVal.questID);
    }

    public void quest600End()
    {
        CurrentQuest.instance.quest600();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest610End()
    {
        Inventory.instance.finditems("board");
        if (Inventory.instance.founditems.Count >= 3)
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest620End()
    {
        int c = Inventory.instance.slots.Count - 1;
        Debug.Log(c.ToString());
        foreach (int i in Inventory.instance.founditems)
        {
            Debug.Log(i.ToString());
            Inventory.instance.useItem(c - i);
        }
        StaticVal.questID = 700;
        SubsceneManager.instance.pighouseSecond();
        Menu.instance.album5.SetActive(false);
        Debug.Log(StaticVal.questID);
    }

    public void quest700End()
    {
        CurrentQuest.instance.quest700();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest710End()
    {
        if (Inventory.instance.findItem("albam") != 9)
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest720End()
    {
        int c = Inventory.instance.findItem("albam");
        Inventory.instance.useItem(c);

        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest730End()
    {
        if (Inventory.instance.findItem("coffee") != 9)
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest740End()
    {
        int c = Inventory.instance.findItem("coffee");
        Inventory.instance.useItem(c);

        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest750End()
    {
        if (Inventory.instance.findItem("umbrella") != 9)
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest760End()
    {
        int c = Inventory.instance.findItem("umbrella");
        Inventory.instance.useItem(c);

        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest770End()
    {
        if ((Inventory.instance.findItem("flower") != 9)&&(Inventory.instance.findItem("mirror") != 9))
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest780End()
    {
        int f = Inventory.instance.findItem("flower");
        int m = Inventory.instance.findItem("mirror");
        Inventory.instance.useItem(f);
        Inventory.instance.useItem(m);

        StaticVal.questID = 800;
        Menu.instance.album6.SetActive(false);
        Debug.Log(StaticVal.questID);
    }

    public void quest800End()
    {
        CurrentQuest.instance.quest800();
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest810End()
    {
        if ((Inventory.instance.findItem("pencil") != 9) && (Inventory.instance.findItem("book") != 9))
        {
            StaticVal.questID += 10;
        }
        Debug.Log(StaticVal.questID);
    }
    public void quest820End()
    {
        int f = Inventory.instance.findItem("pencil");
        int m = Inventory.instance.findItem("book");
        Inventory.instance.useItem(f);
        Inventory.instance.useItem(m);

        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest830End() // 맞춤법 게임하기
    {
        StaticVal.questID += 10;
        Debug.Log(StaticVal.questID);
    }
    public void quest840End()
    {
        Menu.instance.album7.SetActive(false);
        StaticVal.questID = 100; // 끝
        Debug.Log(StaticVal.questID);
    }
}
