using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject saveLoadCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {

    }
    public void LoadButton()
    {
        titleCanvas.SetActive(false);
        saveLoadCanvas.SetActive(true);
    }

}
