using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene1Manager : NormalSceneManager
{
  
    /// <summary>
    /// Default is 0, at dialogueText. 1 is at Idialogue. 2 is at editorDialogue. 3 is at sadDialogue
    /// </summary>
    int dialogueType = 0;
   
    public GameObject objI;
    public GameObject objTable;
    public GameObject objTableDialogue;
    public GameObject objTableRing;

    //Scene of memory
    public GameObject memoryMask;
    public GameObject mainCamera;
    public GameObject objMemory;
    public GameObject objIDialogue;
    public GameObject objEditorDialogue;
    public Text IDialogue;
    public Text editorDialogue;
    public Vector3 startCameraPosition;
    public Vector3 memoryCameraPosition;
    private float fraction;
    public float speed;
    private bool cameraMoveToMemory = false;
    private bool cameraMoveToNormal = false;
    
    //Sad
    public GameObject objDivisionLineRight;
    public GameObject objSadDialogue;
    public Text sadDialogue;
    public GameObject objSad;
    public GameObject objStare;
    public GameObject objStarePaper;
    public StarePaper starePaper;
    //Crumble
    public GameObject objNotebook;
    public GameObject objCrumble;
    //public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene1Start") as TextAsset;
        ReadTextFile();
        
     }   

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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
                StartCoroutine("ResetTriggerTrue");
               
                NextStep();
                fraction = 0;
                }
        }
        if (cameraMoveToNormal == true)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                mainCamera.transform.position = Vector3.Lerp(memoryCameraPosition, startCameraPosition, fraction);
                
            }
            else
            {
                cameraMoveToNormal = false;
                StartCoroutine("ResetTriggerTrue");
                memoryMask.SetActive(false);
                NextStep();
            }
        }
        //End memory. Begin Sad

    }
   
    public override void NextStep()
    {
       
        print(dialogueList[step]);
        if (dialogueList[step][0] == '@')
        {
            ClickAction();
        }
        else if (dialogueList[step][0] == '(')
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
            else if (dialogueType == 3)
            {
                sadDialogue.text = dialogueList[step];
                step++;
            }

        }
    }
   
    public override void StepAction()
    {

        if (dialogueList[step].Contains("(stop @)"))
        {
            triggerObj.SetActive(false);
            StartCoroutine("ResetTriggerTrue");
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(I_table.png)"))
        {
            objI.SetActive(false);
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
            memoryMask.SetActive(true);
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
        else if (dialogueList[step].Contains("(SadDialogueStart)"))
        {
            objSadDialogue.SetActive(true);
            dialogueType = 3;
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(SadDialogueEnd)"))
        {
            objSadDialogue.SetActive(false);
            dialogueType = 0;
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(I_sad appear)"))
        {
            cameraMoveToNormal = true;
            step++;
            trigger = false;
            objTable.SetActive(false);
            objDivisionLineRight.SetActive(true);
            objSad.SetActive(true);
        }
        else if (dialogueList[step].Contains("(I_stare1_paper)"))
        {
            objNotebook.SetActive(true);
            objSad.SetActive(false);
            objStarePaper.SetActive(true);
            objStare.SetActive(true);
            step++;   
        }
        else if (dialogueList[step].Contains("(stare enlarge)"))
        {
            objSad.SetActive(false);
            objStare.SetActive(true);
            starePaper.enlarge = true;
            trigger = false;
            step++;
        }
        else if (dialogueList[step].Contains("(stare left)"))
        {
            trigger = false;
            objSadDialogue.SetActive(false);
            step++;
            objNotebook.GetComponent<Notebook>().moveLeft1 = true;
            
        }


    }


    public override Text GetSuitableText()
    {
        if (dialogueType == 0)
        {
            return dialogueText;
            

        }
        else if (dialogueType == 1)
        {
            return IDialogue;
        }
        else if (dialogueType == 2)
        {
            return editorDialogue;
            
        }
        else if (dialogueType == 3)
        {
            return sadDialogue;

        }
        else
        {
            return null;
        }
    }
   

   
}
