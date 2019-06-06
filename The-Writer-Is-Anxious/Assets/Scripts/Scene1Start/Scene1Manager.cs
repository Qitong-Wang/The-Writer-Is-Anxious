using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene1Manager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueObj;
    bool trigger = true;
    /// <summary>
    /// When trigger is false, use resetTrigger to make trigger to true (by using GetMouseButtonUp)
    /// </summary>
    bool resetTrigger = false;
    int dialogueType = 0; //Default is 0, at dialogueText. 1 is at Idialogue. 2 is a t editorDialogue

    List<string> dialogueList;
    public GameObject objTable;
    public GameObject objTableDialogue;
    public GameObject objTableRing;
    //Scene of memory
    public GameObject mainCamera;
    public GameObject objMemory;
    public GameObject objIDialogue;
    public GameObject objEditorDialogue;
    public Text IDialogue;
    public Text editorDialogue;
    public int step = 0;
    public Vector3 startCameraPosition;
    public Vector3 memoryCameraPosition;
    private float fraction;
    public float speed;
    private bool cameraMoveToMemory = false;
    private TextAsset textAsset;


    
    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene1Start") as TextAsset;
        ReadTextFile();
        
     }   

    // Update is called once per frame
    void Update()
    {
        if (trigger == true && Input.GetMouseButtonDown(0) )
        {
            NextStep();
        }
        if (resetTrigger == true && Input.GetMouseButtonUp(0))
        {
            trigger = true;
            resetTrigger = false;
        }
        //Begin memory
        if (cameraMoveToMemory == true)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                mainCamera.transform.position = Vector3.Lerp(startCameraPosition, memoryCameraPosition, fraction);
            }
            else
            {
                cameraMoveToMemory = false;
                resetTrigger = true;
                trigger = true;
                NextStep();
            }
        }
       
    }
    void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
       
    }
    public void NextStep()
    {
        print(dialogueList[step]);
        if (dialogueList[step][0] == '(')
        {
            StepAction();

        }
        else
        {
            if (dialogueType == 0)
            {
                dialogueText.text = dialogueList[step];
                step++;
            }
            else if (dialogueType == 1)
            {
                IDialogue.text = dialogueList[step];
                step++;
            }
            else if (dialogueType == 2)
            {
                editorDialogue.text = dialogueList[step];
                step++;
            }

        }
    }

    void StepAction()
    {
        
        if (dialogueList[step].Contains("(I_table.png)"))
        {
            objTable.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(I_table_dialogue.png)"))
        {
            objTableDialogue.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(dialogue fades out)"))
        {
            objTableDialogue.SetActive(false);
            objTableRing.SetActive(true);
            step++;
            trigger = false;
        }
        else if (dialogueList[step].Contains("(division_line)"))
        {
            objMemory.SetActive(true);
            objTableRing.SetActive(false);
            dialogueObj.SetActive(false);
            cameraMoveToMemory = true;
            step++;

        }
        else if (dialogueList[step].Contains("(IDialogueStart)"))
        {
            objIDialogue.SetActive(true);
            dialogueType = 1;
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(IDialogueEnd)"))
        {
            objIDialogue.SetActive(false);
            dialogueType = 0;
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(EditorDialogueStart)"))
        {
            objEditorDialogue.SetActive(true);
            dialogueType = 2;
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(EditorDialogueEnd)"))
        {
            objEditorDialogue.SetActive(false);
            dialogueType = 0;
            step++;
            NextStep();

        }



    }
}
