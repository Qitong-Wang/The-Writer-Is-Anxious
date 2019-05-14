using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// Save Data
    /// </summary>
    /// <param name="saveNumber">the index of save file</param>
    public void Save(int saveNumber)
    {
       PlayerPrefs.SetString("save"+ saveNumber.ToString(),SaveDataHelper.Serialize<SaveData>(GlobalManager.instance.saveData));
    }

    /// <summary>
    /// Load Data
    /// </summary>
    /// <param name="saveNumber">the idnex of load file</param>
    public void Load(int saveNumber)
    {
        if (PlayerPrefs.HasKey("save" + saveNumber.ToString()))
        {
            GlobalManager.instance.saveData = SaveDataHelper.Deserialize<SaveData>(PlayerPrefs.GetString("save" + saveNumber.ToString()));
        }
        else
        {
            GlobalManager.instance.saveData = new SaveData();
            Save(saveNumber);
        }
        Debug.Log(SaveDataHelper.Serialize<SaveData>(GlobalManager.instance.saveData));
     
    }

}
