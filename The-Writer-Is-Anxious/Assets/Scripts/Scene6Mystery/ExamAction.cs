using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamAction : MonoBehaviour
{
    public Scene6Manager scene6Manager;
    /// <summary>
    /// 0: Gunfire 1:News 2: Capboy 3: Blood 4: Immunity 5: Wait 6: Next
    /// </summary>
    public int actionIndex;
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
            string result = "Answer_" + scene6Manager.currentExamIndex + "_" + actionIndex;
            scene6Manager.ReadDialogue(result);
            scene6Manager.StartCoroutine("ResetTriggerTrue");
            scene6Manager.otherObjActive = false;


        }
        
    }
}
