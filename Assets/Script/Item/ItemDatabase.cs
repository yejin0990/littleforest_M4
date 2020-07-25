using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Add("green", 1, 5, "집지을 때 필요한 지푸라기", ItemType.Pig);
        Add("apple",1, 5, "달콤한 빨간 공", ItemType.Flog);
        Add("board", 1, 5, "지푸라기보다 튼튼한 나무 판자", ItemType.Pig);
        Add("albam",1, 5, "예쁜 갈색 모자를 쓴 열매", ItemType.Flog);
        Add("coffee",1, 5, "먹으면 잠이 안오는 피", ItemType.Flog);
        Add("umbrella", 1, 5, "오를 수는 없지만 들 수 있는 산", ItemType.Flog);
        Add("flower",1, 5, "봄봄봄 봄이왔네요", ItemType.Flog);
        Add("mirror",1, 5, "나를 볼 수 있는 거울", ItemType.Flog);
        Add("note",1, 5, "공부할 때 필요한 공책", ItemType.Dog);
        Add("pencil",1, 500, "공부할 때 필요한 연필", ItemType.Dog);
    }

    void Add(string itemName,int itemValue, int itemPrice, string itemDesc, ItemType itemType)
    {
        items.Add(new Item(itemName,itemValue, itemPrice, itemDesc, itemType, Resources.Load<Sprite>("ItemImages/" + itemName)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
