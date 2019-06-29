using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene2FrigerUp : MonoBehaviour
{

    public Scene2Manager scene2Manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (scene2Manager.otherObjActive == true)
        {
            if (scene2Manager.afterDropMilk == false)
            {
                scene2Manager.ReadDialogue("frigerUp");
                scene2Manager.StartCoroutine("ResetTriggerTrue");
                scene2Manager.otherObjActive = false;
                scene2Manager.dialogueObj.SetActive(true);
            }
            else
            {
                scene2Manager.ReadDialogue("frigerUpDropMilk");
                scene2Manager.StartCoroutine("ResetTriggerTrue");
                scene2Manager.otherObjActive = false;
                scene2Manager.dialogueObj.SetActive(true);
            }

        }
    }
}
