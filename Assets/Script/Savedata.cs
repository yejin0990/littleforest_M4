using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savedata : MonoBehaviour
{
    public static Savedata instance;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < Inventory.instance.slots.Count; i++)
        {
            GoogleManager.Instance.LoadFromCloud1((string dataToLoad) =>
            { Inventory.instance.slots[i].itemName = (dataToLoad); });
        }*/

        GoogleManager.Instance.LoadFromCloud2((string dataToLoad) =>
        { StaticVal.questID = int.Parse(dataToLoad); });
        Debug.Log("success id");

        GoogleManager.Instance.LoadFromCloud3((string dataToLoad) =>
        { StaticVal.playerCoin = int.Parse(dataToLoad); });
        Debug.Log("success coin");

        GoogleManager.Instance.LoadFromCloud4((string dataToLoad) =>
        { Healing.healing_QuestionVal = float.Parse(dataToLoad); });

        Debug.Log("success question");

        GoogleManager.Instance.LoadFromCloud5((string dataToLoad) =>
        { Healing.healing_PictureVal = float.Parse(dataToLoad); });

        Debug.Log("success pic");

        GoogleManager.Instance.LoadFromCloud6((string dataToLoad) =>
        { Healing.healing_LetterVal = float.Parse(dataToLoad); });

        Debug.Log("success letter");

        GoogleManager.Instance.LoadFromCloud7((string dataToLoad) =>
        { Healing.healing_BambooVal = float.Parse(dataToLoad); });

        Debug.Log("success bamboo");

        GoogleManager.Instance.LoadFromCloud8((string dataToLoad) =>
        { Healing.de_healingVal = float.Parse(dataToLoad); });

        Debug.Log("success cloud load");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SaveData()
    {
        for (int i = 0; i < Inventory.instance.slots.Count; i++)
        {
            GoogleManager.Instance.SaveToCloud1(Inventory.instance.slots[i].itemName);
        }
        GoogleManager.Instance.SaveToCloud2(StaticVal.questID.ToString());
        GoogleManager.Instance.SaveToCloud3(StaticVal.playerCoin.ToString());
        GoogleManager.Instance.SaveToCloud4(Healing.healing_QuestionVal.ToString());
        GoogleManager.Instance.SaveToCloud5(Healing.healing_PictureVal.ToString());
        GoogleManager.Instance.SaveToCloud6(Healing.healing_LetterVal.ToString());
        GoogleManager.Instance.SaveToCloud7(Healing.healing_BambooVal.ToString());
        GoogleManager.Instance.SaveToCloud8(Healing.de_healingVal.ToString());
    }

}
