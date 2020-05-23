using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotData
{
    public bool isMountable;
    public bool isCatMounted;
}

[System.Serializable]
public class SaveFileData
{
    
    public long gold;
    public long catnip;
    public long wood;
    public SlotData[] slotInfo;
    // private RareCatCollectionList


    public void print()
    {
        Debug.Log("Gold: " + gold + ", Catnip: " + catnip + ", Wood: " + wood + '\n' + "CatSlot: " + slotInfo);
    }

    public void loadData()
    {
        CatSlotList catSlotList;
        UserInfo userInfo = (UserInfo)GameObject.FindObjectOfType(typeof(UserInfo));
        gold = userInfo.getGold();
        catnip = userInfo.getCatnip();
        wood = userInfo.getWood();

        catSlotList = (CatSlotList)GameObject.FindObjectOfType(typeof(CatSlotList));
        slotInfo = new SlotData[catSlotList.transform.childCount];
        for (int i = 0; i < slotInfo.Length; i++)
        {
            slotInfo[i] = new SlotData();
            slotInfo[i].isMountable = catSlotList.transform.GetChild(i).gameObject.GetComponent<CatSlot>().isMountable;
            slotInfo[i].isCatMounted = catSlotList.transform.GetChild(i).gameObject.GetComponent<CatSlot>().isCatMounted;
            // Debug.Log(slotInfo[i].isMountable + " " + slotInfo[i].isCatMounted);
        }
    }
}
