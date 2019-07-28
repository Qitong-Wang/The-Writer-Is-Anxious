using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene31Option : MonoBehaviour
{
    public bool optionLeft;
    public Scene31Manager scene31Manager;
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
        //Player choose the left option
        if (optionLeft == true)
        {
            scene31Manager.step = scene31Manager.option1LineNumber;

        }
        else
        {
            scene31Manager.step = scene31Manager.option2LineNumber;
        }
        objOption1.SetActive(false);
        objOption2.SetActive(false);
        scene31Manager.StartCoroutine("ResetTriggerTrue");
        scene31Manager.NextStep();
    }
}
