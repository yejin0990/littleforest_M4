using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class market : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public string[] NPCsentences;
    public Text cointext;

    public int nowSelect = 0;

    public CanvasGroup itemPurchase;
    public Image Purchaseimage;
    public Text ItemName;
    public Text ItemDesc;
    public Text ItemPrice;
    public Text Purchasetext;
    public Button buyOKbutton;

    public Image firstItemImage;
    public Image secondItemImage;
    public Image thirdItemImage;

    public List<Item> marketItems = new List<Item>();
    public AudioSource Clickitems;



    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();

        talkData.Add(10, new string[] { "아이템을 사고 싶으면 사고 싶은 아이템을 클릭해줘.\n당연하겠지만 돈이 있어야 살 수 있어." });
        talkData.Add(20, new string[] { "아이템은 주민들이 필요한거에 맞춰져있어.\n필요한건 잘 찾으면 있을 꺼야." });
        Clickitems = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        itemPurchase.alpha = 0;
        itemPurchase.blocksRaycasts = false;
        itemPurchase.interactable = false;

        marketItems.Add(ItemDatabase.instance.items[0]);
        marketItems.Add(ItemDatabase.instance.items[1]);
        marketItems.Add(ItemDatabase.instance.items[2]);

    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = StaticVal.playerCoin.ToString();

        if (StaticVal.questID >= 800)
        {
            marketItems[0] = ItemDatabase.instance.items[7];
            marketItems[1] = ItemDatabase.instance.items[8];
            marketItems[2] = ItemDatabase.instance.items[9];
        }
        else if (StaticVal.questID >= 750)
        {
            marketItems[0] = ItemDatabase.instance.items[5];
            marketItems[1] = ItemDatabase.instance.items[6];
            marketItems[2] = ItemDatabase.instance.items[7];
        }
        else if (StaticVal.questID >= 700)
        {
            marketItems[0] = ItemDatabase.instance.items[3];
            marketItems[1] = ItemDatabase.instance.items[4];
            marketItems[2] = ItemDatabase.instance.items[5];
        }

        firstItemImage.sprite = marketItems[0].itemImage;
        secondItemImage.sprite = marketItems[1].itemImage;
        thirdItemImage.sprite = marketItems[2].itemImage;

    }

    public void tigerclick()
    {
        if (StaticVal.Touchenable == 1)
        {
            StaticVal.Touchenable = 0;
            int random = Random.Range(1, 3);
            NPCsentences = talkData[(random * 10)];
            miniTalkmanager.instance.Ondialogue(NPCsentences);
        }
    }

    public void buyCancel()
    {
        Clickitems.Play();
        itemPurchase.alpha = 0;
        itemPurchase.blocksRaycasts = false;
        itemPurchase.interactable = false;

        StaticVal.Touchenable = 1;
    }

    public void buyOK()
    {

        Clickitems.Play();

        StaticVal.playerCoin -= marketItems[nowSelect].itemprice;

        itemPurchase.alpha = 0;
        itemPurchase.blocksRaycasts = false;
        itemPurchase.interactable = false;
        Inventory.instance.slotsAdd(marketItems[nowSelect]);
        Inventory.instance.slotImageChange();

        StaticVal.Touchenable = 1;
    }

    public void FirstItemClick()
    {
        if (StaticVal.Touchenable == 1)
        {
            Clickitems.Play();
            StaticVal.Touchenable = 0;

            nowSelect = 0;
            Purchaseimage.sprite = marketItems[0].itemImage;
            ItemName.text = marketItems[0].itemName;
            ItemDesc.text = marketItems[0].itemDesc;
            ItemPrice.text = "가격 : " + marketItems[0].itemprice.ToString();

            if (StaticVal.playerCoin < marketItems[0].itemprice)
            {
                buyOKbutton.interactable = false;
                Purchasetext.text = "코인이 모자라서 구매하실 수 없습니다.";
            }
            else
            {
                buyOKbutton.interactable = true;
                Purchasetext.text = "구매하시겠습니까?";
            }

            itemPurchase.alpha = 1;
            itemPurchase.blocksRaycasts = true;
            itemPurchase.interactable = true;
        }
    }

    public void SecondItemClick()
    {
        if (StaticVal.Touchenable == 1)
        {
            Clickitems.Play();
            StaticVal.Touchenable = 0;

            nowSelect = 1;
            Purchaseimage.sprite = marketItems[1].itemImage;
            ItemName.text = marketItems[1].itemName;
            ItemDesc.text = marketItems[1].itemDesc;
            ItemPrice.text = "가격 : " + marketItems[1].itemprice.ToString();

            if (StaticVal.playerCoin < marketItems[1].itemprice)
            {
                buyOKbutton.interactable = false;
                Purchasetext.text = "코인이 모자라서 구매하실 수 없습니다.";
            }
            else
            {
                buyOKbutton.interactable = true;
                Purchasetext.text = "구매하시겠습니까?";
            }

            itemPurchase.alpha = 1;
            itemPurchase.blocksRaycasts = true;
            itemPurchase.interactable = true;
        }
    }

    public void ThirdItemClick()
    {
        if (StaticVal.Touchenable == 1)
        {
            Clickitems.Play();
            StaticVal.Touchenable = 0;
            nowSelect = 2;
            Purchaseimage.sprite = marketItems[2].itemImage;
            ItemName.text = marketItems[2].itemName;
            ItemDesc.text = marketItems[2].itemDesc;
            ItemPrice.text = "가격 : " + marketItems[2].itemprice.ToString();

            if (StaticVal.playerCoin < marketItems[2].itemprice)
            {
                buyOKbutton.interactable = false;
                Purchasetext.text = "코인이 모자라서 구매하실 수 없습니다.";
            }
            else
            {
                buyOKbutton.interactable = true;
                Purchasetext.text = "구매하시겠습니까?";
            }

            itemPurchase.alpha = 1;
            itemPurchase.blocksRaycasts = true;
            itemPurchase.interactable = true;
        }
    }
}
