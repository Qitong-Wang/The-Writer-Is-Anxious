using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene2Obj : MonoBehaviour
{
 
    public Scene2Manager scene2Manager;
    public string triggerName;
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
            scene2Manager.ReadDialogue(triggerName);
            scene2Manager.StartCoroutine("ResetTriggerTrue");
            scene2Manager.otherObjActive = false;
            scene2Manager.dialogueObj.SetActive(true);
        }
    }
}
