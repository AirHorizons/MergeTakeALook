using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class FileSaveLoader : MonoBehaviour
{

    private string filePath = "Assets/savedata.json";

    // Start is called before the first frame update
    void Start()
    {
        ReadFile();

        InvokeRepeating("WriteFile", 2.0f, 1.0f);
    }

    private void ReadFile()
    {
        if (File.Exists(filePath))
        {
            // read json file and convert to SaveFileData format
            StreamReader reader = new StreamReader(filePath);
            string data = reader.ReadToEnd();
            SaveFileData saveFileData = JsonToObj<SaveFileData>(data);

            // transfer data to UserInfo and CatSlot, TODO: RareCatCollection
            UserInfo userInfo = (UserInfo)GameObject.FindObjectOfType(typeof(UserInfo));
            userInfo.setGold(saveFileData.gold);
            userInfo.setCatnip(saveFileData.catnip);
            userInfo.setWood(saveFileData.wood);

            CatSlotList catSlotList = (CatSlotList)GameObject.FindObjectOfType(typeof(CatSlotList));
            for (int i=0; i<catSlotList.transform.childCount; i++)
            {
                catSlotList.transform.GetChild(i).gameObject.GetComponent<CatSlot>().isMountable = saveFileData.slotInfo[i].isMountable;
                catSlotList.transform.GetChild(i).gameObject.GetComponent<CatSlot>().isCatMounted = saveFileData.slotInfo[i].isCatMounted;
            }
            reader.Close();
        }
    }

    private void WriteFile()
    {
        SaveFileData saveFileData = new SaveFileData();
        saveFileData.loadData();
        System.IO.File.WriteAllText(filePath, ObjToJson(saveFileData), System.Text.Encoding.Default);
    }

    string ObjToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    T JsonToObj<T>(string jsondata)
    {
        return JsonUtility.FromJson<T>(jsondata);
    }
}
