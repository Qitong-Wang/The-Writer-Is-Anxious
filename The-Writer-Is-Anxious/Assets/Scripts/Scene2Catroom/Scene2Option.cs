using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Option : MonoBehaviour
{
    public bool optionLeft;
    public Scene2Manager scene2Manager;
    public GameObject objOption1;
    public GameObject objOption2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseOption()
    {
        print(1);
        //Player choose the left option
        if (optionLeft == true)
        {
            scene2Manager.step = scene2Manager.option1LineNumber;
          
        }
        else
        {
            scene2Manager.step = scene2Manager.option2LineNumber;
        }
        objOption1.SetActive(false);
        objOption2.SetActive(false);
        scene2Manager.StartCoroutine("ResetTriggerTrue");
        scene2Manager.NextStep();
    }
}
