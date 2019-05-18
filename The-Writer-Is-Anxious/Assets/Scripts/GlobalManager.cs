using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    public SaveData saveData;
    public SaveDataMemory saveDataMemory;
    public SaveManager saveManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
       

    }
    // Start is called before the first frame update
    void Start()
    {
        //For Debug. Create a null data
  
        saveData = new SaveData
        {
            life = 3,
            name = new bool[2]
            {
                false,false
            },

        };
        
       /*
        saveDataMemory = new SaveDataMemory
        {
            unlockStory = new bool[2]
                {
            false,false
            },
        };
        */
      
    }

    public void InitializeSaveData()
    {
        saveData = new SaveData
        {
            life = 3,
            name = new bool[2]
            {
                    false,false
            },

        };
    }
    public void InitializeSaveDataMemory()
    {
        saveDataMemory = new SaveDataMemory
        {
            unlockStory = new bool[2]
            {
                false,false
            },
        };
    }
   
}
