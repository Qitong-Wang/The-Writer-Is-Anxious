using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Option : MonoBehaviour
{
    public int optionIndex;
    public Scene4Manager scene4Manager;
    public GameObject objOption1;
    public GameObject objOption2;
    public GameObject objOption3;
    public GameObject objOptionBar;
    
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
        //Player choose the left option
        if (optionIndex == 1)
        {
            scene4Manager.step = scene4Manager.option1LineNumber;

        }
        else if(optionIndex == 2)
        {
            scene4Manager.step = scene4Manager.option2LineNumber;
        }
        else
        {
            scene4Manager.step = scene4Manager.option3LineNumber;
        }
        objOption1.SetActive(false);
        objOption2.SetActive(false);
        objOption3.SetActive(false);
        objOptionBar.SetActive(false);
        scene4Manager.StartCoroutine("ResetTriggerTrue");
        scene4Manager.NextStep();
    }
}
