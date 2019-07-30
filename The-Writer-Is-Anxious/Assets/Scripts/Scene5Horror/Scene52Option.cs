using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene52Option : MonoBehaviour
{
    public int optionIndex;
    public Scene52HorrorConversationManager scene52Manager;
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
            scene52Manager.step = scene52Manager.option1LineNumber;

        }
        else if (optionIndex == 2)
        {
            scene52Manager.step = scene52Manager.option2LineNumber;
        }
        else
        {
            scene52Manager.step = scene52Manager.option3LineNumber;
        }
        objOption1.SetActive(false);
        objOption2.SetActive(false);
        objOption3.SetActive(false);
        objOptionBar.SetActive(false);
        scene52Manager.StartCoroutine("ResetTriggerTrue");
        scene52Manager.NextStep();
    }
}
