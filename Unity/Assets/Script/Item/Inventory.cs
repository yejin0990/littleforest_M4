using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public List<Item> slots = new List<Item>(); // 인벤토리 아이템 리스트

    public List<int> founditems = new List<int>();

    public Image slotImage1;
    public Image slotImage2;
    public Image slotImage3;
    public Image slotImage4;
    public Image slotImage5;
    public Image slotImage6;
    public Image slotImage7;
    public Image slotImage8;
    public Image slotImage9;

    void Awake()
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

    public int findItem(string itemName)    //itemName과 일치하는 이름을 가지면
    {
        int i = 0;
        for (; i < slots.Count; i++)
        {
            if (slots[i].itemName == itemName)
            {
                return i;
            }
        }
        return 9;
    }

    public void finditems(string itemName)
    {
        founditems.Clear();
        founditems.RemoveRange(0, founditems.Count);

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemName == itemName)  //itemName과 일치하는 이름을 가진 것들은
            {
                founditems.Add(i);  //founditems에 인덱스를 리스트 형식으로 반환
            }
        }
    }
    public void useItem(int i)
    {
        slots.RemoveAt(i);
        i += 1;
        switch (i)
        {
            case 9:
                slotImage9.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 8:
                slotImage8.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 7:
                slotImage7.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 6:
                slotImage6.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 5:
                slotImage5.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 4:
                slotImage4.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 3:
                slotImage3.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 2:
                slotImage2.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
            case 1:
                slotImage1.sprite = Resources.Load<Sprite>("ItemImages/itemdefault");
                break;
        }
        Debug.Log(i + "번째 지움");
        slotImageChange();
    }

    public void slotImageChange()
    {
        for (int i = 1; i <= slots.Count; i++)
        {
            switch (i)
            {
                case 9:
                    slotImage9.sprite = slots[8].itemImage;
                    break;
                case 8:
                    slotImage8.sprite = slots[7].itemImage;
                    break;
                case 7:
                    slotImage7.sprite = slots[6].itemImage;
                    break;
                case 6:
                    slotImage6.sprite = slots[5].itemImage;
                    break;
                case 5:
                    slotImage5.sprite = slots[4].itemImage;
                    break;
                case 4:
                    slotImage4.sprite = slots[3].itemImage;
                    break;
                case 3:
                    slotImage3.sprite = slots[2].itemImage;
                    break;
                case 2:
                    slotImage2.sprite = slots[1].itemImage;
                    break;
                case 1:
                    slotImage1.sprite = slots[0].itemImage;
                    break;

            }
        }
        
    }

    public void slotsAdd(Item addSlots)
    {
        slots.Add(addSlots);
        Debug.Log(slots[0].itemName.ToString());
    }

    public void slotLoadData(string name)
    {
        for (int i = 0; i < ItemDatabase.instance.items.Count; i++)
        {
            if (ItemDatabase.instance.items[i].itemName == name)  //itemName과 일치하는 이름을 가진 것들은
            {
                slots.Add(ItemDatabase.instance.items[i]);  //founditems에 인덱스를 리스트 형식으로 반환
            }
        }
    }
}
