using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject saveLoadCanvasObj;
    public SaveLoadCanvas saveLoadCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
       
        GlobalManager.instance.saveManager.LoadDataMemory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        
        GlobalManager.instance.InitializeSaveData();
        
    }
    public void LoadButton()
    {
        titleCanvas.SetActive(false);
        saveLoadCanvasObj.SetActive(true);
        saveLoadCanvas.RefreshLoadInfo();
    }

}
