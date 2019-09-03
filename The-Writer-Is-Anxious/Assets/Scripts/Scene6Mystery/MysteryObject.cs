using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MysteryObject : MonoBehaviour
{

    public Scene6Manager scene6Manager;
    public string triggerName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        if (scene6Manager.otherObjActive == true)
        {
            if (triggerName == "Smoke")
            {
                Destroy(gameObject);
            }
            else
            {
                switch (triggerName)
                {
                    case ("ObjGunfire"):
                        scene6Manager.evidenceUnlock[0] = true;
                        if (scene6Manager.finishExam == true)
                        {
                            return;
                        }
                        break;
                    case ("ObjNews"):
                        scene6Manager.evidenceUnlock[1] = true;
                        if (scene6Manager.finishExam == true)
                        {
                            return;
                        }
                        break;
                    case ("ObjCapboy"):
                        scene6Manager.evidenceUnlock[2] = true;
                        if (scene6Manager.finishExam == true)
                        {
                            triggerName = "ObjDoorFinish";
                        }
                        break;
                    case ("ObjBloodStain"):
                        scene6Manager.evidenceUnlock[3] = true;
                        if (scene6Manager.finishExam == true)
                        {
                            return;
                        }
                        break;
                    case ("ObjImmunity"):
                        scene6Manager.evidenceUnlock[4] = true;
                        if (scene6Manager.finishExam == true)
                        {
                            triggerName = "ObjManFinish";
                        }
                        break;
                    case ("objPrincess"):
                        if (scene6Manager.finishExam == true)
                        {
                            triggerName = "ObjPrincessFinish";
                        }
                        break;
                  
                   
                   
                }
                scene6Manager.ReadDialogue(triggerName);
                scene6Manager.StartCoroutine("ResetTriggerTrue");
                scene6Manager.otherObjActive = false;
            }
            
        }
    }
}
