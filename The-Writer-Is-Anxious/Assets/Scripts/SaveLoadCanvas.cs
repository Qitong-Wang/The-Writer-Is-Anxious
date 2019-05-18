using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveLoadCanvas : MonoBehaviour
{
    public Text[] fileInfo;
    public GameObject saveLoadCanvas;
    public GameObject titleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshLoadInfo()
    {
        for (int i = 1; i <= 4; i++)
        {
            fileInfo[i - 1].text = GlobalManager.instance.saveManager.LoadInfo(i);
        }
    }
    public void LoadButton(int i)
    {
        GlobalManager.instance.saveManager.Load(i);
    }
    public void TitleCancelButton()
    {
        titleCanvas.SetActive(true);
        saveLoadCanvas.SetActive(false);
    }
}
