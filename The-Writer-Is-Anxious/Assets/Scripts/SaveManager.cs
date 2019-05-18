using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 0 is SaveDataMemory 1-4 are Save Data
/// </summary>
public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// Save Data
    /// </summary>
    /// <param name="saveNumber">the index of save file</param>
    public void Save(int saveNumber)
    {
        GlobalManager.instance.saveData.time = System.DateTime.Now.ToString();
        PlayerPrefs.SetString("save"+ saveNumber.ToString(),SaveDataHelper.Serialize<SaveData>(GlobalManager.instance.saveData));
    }

    /// <summary>
    /// Save Data Memory
    /// </summary>
    public void SaveMemory()
    {
       
        PlayerPrefs.SetString("save0", SaveDataHelper.Serialize<SaveDataMemory>(GlobalManager.instance.saveDataMemory));
    }

    /// <summary>
    /// Load Data. Return true if load successfully. Otherwise return false
    /// </summary>
    /// <param name="saveNumber">the index of load file</param>
    public bool Load(int saveNumber)
    {
        if (PlayerPrefs.HasKey("save" + saveNumber.ToString()))
        {
            GlobalManager.instance.saveData = SaveDataHelper.Deserialize<SaveData>(PlayerPrefs.GetString("save" + saveNumber.ToString()));
            Debug.Log(SaveDataHelper.Serialize<SaveData>(GlobalManager.instance.saveData));
            return true;
        }
        else
        {
            Debug.Log("No such files!");
            return false;
            //GlobalManager.instance.saveData = new SaveData();
            //Save(saveNumber);
        }

    }
    /// <summary>
    /// Load DataMemory
    /// </summary>
    public void LoadDataMemory()
    {
        GlobalManager.instance.saveDataMemory = SaveDataHelper.Deserialize<SaveDataMemory>(PlayerPrefs.GetString("save0"));
        Debug.Log(SaveDataHelper.Serialize<SaveDataMemory>(GlobalManager.instance.saveDataMemory));
    }
    /// <summary>
    /// In the Save Menu, show the short info of the saveData
    /// </summary>
    /// <param name="saveNumber">the index of load file</param>
    /// <returns></returns>
    public string LoadInfo(int saveNumber)
    {
        if (PlayerPrefs.HasKey("save" + saveNumber.ToString()))
        {
            SaveData saveData = SaveDataHelper.Deserialize<SaveData>(PlayerPrefs.GetString("save" + saveNumber.ToString()));
            string info = saveData.time;
            return info;
        }
        else
        {
            return "No Data";
          
        }
    }

}
