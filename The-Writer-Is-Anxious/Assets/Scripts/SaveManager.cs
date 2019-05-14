using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; set; }
    public SaveData saveData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        Load();
        Debug.Log(SaveDataHelper.Serialize<SaveData>(saveData));

    }

    public void Save()
    {
       PlayerPrefs.SetString("save"+1.ToString(),SaveDataHelper.Serialize<SaveData>(saveData));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save" + 1.ToString()))
        {
            saveData = SaveDataHelper.Deserialize<SaveData>(PlayerPrefs.GetString("save" + 1.ToString()));
        }
        else
        {
            saveData = new SaveData();
            Save();
        }
    }

}
