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

    List<string> dialogueList;
    public GameObject objTable;
    public GameObject objTableDialogue;
    public GameObject objTableRing;
    public int step = 0;
    public float cameraMoveLeft = -17.85f;
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
       
    }
    void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
       
    }
    public void NextStep()
    {
       
        if (dialogueList[step][0] == '(')
        {
            StepAction();
        }
        else
        {
            dialogueText.text = dialogueList[step];
            step++;
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
            resetTrigger = true;
            objTableRing.SetActive(false);
            step++;
           

        }



    }
}
