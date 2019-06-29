using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene2ShelfBelow : MonoBehaviour
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
            if (scene2Manager.afterDoratosCat == false)
            {
                scene2Manager.ReadDialogue("ShelfBelow");
                scene2Manager.StartCoroutine("ResetTriggerTrue");
                scene2Manager.otherObjActive = false;
                scene2Manager.dialogueObj.SetActive(true);
            }
            else
            {
                scene2Manager.ReadDialogue("ShelfBelowAfterDoratosCat");
                scene2Manager.StartCoroutine("ResetTriggerTrue");
                scene2Manager.otherObjActive = false;
                scene2Manager.dialogueObj.SetActive(true);
            }
            
        }
    }
}
