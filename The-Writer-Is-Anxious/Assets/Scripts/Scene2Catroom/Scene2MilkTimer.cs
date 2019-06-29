using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene2MilkTimer : MonoBehaviour
{
    public Text TimerText;
    public bool startTimer;
    public float time;
    bool finishTime = false;
    public Scene2Manager scene2Manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            time -= Time.deltaTime;
            if (scene2Manager.pickupBowl == true && scene2Manager.trigger == false && scene2Manager.otherObjActive == true && scene2Manager.dialogueObj.activeSelf == false)
            {
                scene2Manager.ReadDialogue("milkWithBowl");
                startTimer = false;
            }
            if (time <= 0)
            {
                time = 0;
                finishTime = true;
                startTimer = false;
               
            }
            TimerText.text = "The milk box is falling. It seems like you only have " + (int)time + " seconds left.";
            

        }
        if (finishTime == true && scene2Manager.trigger== false && scene2Manager.otherObjActive == true&& scene2Manager.dialogueObj.activeSelf == false)
        {
            scene2Manager.ReadDialogue("milkTimerFinish");
            finishTime = false;
        }
       
    }
   
}
