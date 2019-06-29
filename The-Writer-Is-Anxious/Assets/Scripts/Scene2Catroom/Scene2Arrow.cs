using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// O is catRoom. 1 is Kitchen, 2 is entry way.
/// catroom - kitchen - entry way - catroom
/// roomIndex is stored in Scene2Manager
/// </summary>
public class Scene2Arrow : MonoBehaviour
{
    public GameObject catRoom;
    public GameObject kitchen;
    public GameObject entryWay;
    public Scene2Manager scene2Manager;
    public bool right;
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
            scene2Manager.StartCoroutine("ResetTriggerTrue");
            if (right == true)
            {
                if (scene2Manager.roomIndex == 0)
                {
                    scene2Manager.roomIndex = 1;
                    catRoom.SetActive(false);
                    kitchen.SetActive(true);
                    if (scene2Manager.afterDropMilk == true)
                    {
                        scene2Manager.ReadDialogue("KitchenDropMilk");
                    }
                    else
                    {
                        scene2Manager.ReadDialogue("Kitchen");
                    }
                    scene2Manager.otherObjActive = false;
                    scene2Manager.dialogueObj.SetActive(true);
                }
                else if (scene2Manager.roomIndex == 1)
                {
                    scene2Manager.roomIndex = 2;
                    kitchen.SetActive(false);
                    entryWay.SetActive(true);
                }
                else
                {
                    scene2Manager.roomIndex = 0;
                    entryWay.SetActive(false);
                    catRoom.SetActive(true);
                    scene2Manager.ReadDialogue("Catroom");
                    scene2Manager.otherObjActive = false;
                    scene2Manager.dialogueObj.SetActive(true);
                }
            }
            else
            {
                if (scene2Manager.roomIndex == 0)
                {
                    scene2Manager.roomIndex = 2;
                    catRoom.SetActive(false);
                    entryWay.SetActive(true);
                }
                else if (scene2Manager.roomIndex == 1)
                {
                    scene2Manager.roomIndex = 0;
                    kitchen.SetActive(false);
                    catRoom.SetActive(true);
                    scene2Manager.ReadDialogue("Catroom");
                    scene2Manager.otherObjActive = false;
                    scene2Manager.dialogueObj.SetActive(true);
                }
                else
                {
                    scene2Manager.roomIndex = 1;
                    entryWay.SetActive(false);
                    kitchen.SetActive(true);
                    if (scene2Manager.afterDropMilk == true)
                    {
                        scene2Manager.ReadDialogue("KitchenDropMilk");
                    }
                    else
                    {
                        scene2Manager.ReadDialogue("Kitchen");
                    }
                    
                    scene2Manager.otherObjActive = false;
                    scene2Manager.dialogueObj.SetActive(true);
                }
            }
        }
    }
}
