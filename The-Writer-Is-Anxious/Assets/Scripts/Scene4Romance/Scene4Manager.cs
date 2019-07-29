using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene4Manager : NormalSceneManager
{

    /// <summary>
    /// Default is 0, at dialogueText. 1 is option1, 2 is option2
    /// </summary>
    int dialogueType = 0;
    /// <summary>
    /// Key is the name of the tag. value is the index of line
    /// </summary>\
    public Dictionary<string, int> dialogueIndexDictionary;
    /// <summary>
    /// Whether player can interactive with other objects in the game
    /// </summary>
    public bool otherObjActive = false;

    //NameTag
    public Text nameTagText;
    public GameObject objNameTag;
    //Option
    public Text dialogueOption1;
    public Text dialogueOption2;
    public Text dialogueOption3;
    public GameObject objOptionBar;
    public int option1LineNumber;
    public int option2LineNumber;
    public int option3LineNumber;

    //Objects
    public GameObject objPrincess;
   
    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene4Romance") as TextAsset;
        dialogueIndexDictionary = new Dictionary<string, int>();
        ReadTextFile();
        otherObjActive = false;
        ReadDialogue("Romance Open");

    }
    public override void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
        for (int i = 0; i < dialogueList.Count; i++)
        {
            if (dialogueList[i][0] == '(')
            {

                if (dialogueList[i].Contains("end") == false && dialogueList[i].Contains("(stop @)") == false)
                {
                    //Add the tag to the dictionary. 
                    dialogueIndexDictionary.Add(dialogueList[i].Substring(1, dialogueList[i].Length - 3), i);
                }
            }
        }
        foreach (KeyValuePair<string, int> kvp in dialogueIndexDictionary)
        {
            print(kvp.Key);
            print(kvp.Value);
        }

    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //Begin memory

        //End memory. Begin Sad

    }

    public override void NextStep()
    {
        print(step);
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


        }
    }

    public override void StepAction()
    {

        
        if (dialogueList[step].Contains("(end)"))
        {
            dialogueObj.SetActive(false);
            otherObjActive = true;
            trigger = false;
        }
        else if (dialogueList[step].Contains("(Romance Open)"))
        {
            dialogueObj.SetActive(true);
            objNameTag.SetActive(true);
            otherObjActive = false;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(PrincessAppear)"))
        {
            objPrincess.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(Princess)"))
        {
            objNameTag.SetActive(true);
            nameTagText.text = "Princess";
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(option3"))
        {
            string[] optionNumbers = dialogueList[step].Split(" "[0]);
            objOptionBar.SetActive(true);
            option1LineNumber = dialogueIndexDictionary[optionNumbers[1]];
            option2LineNumber = dialogueIndexDictionary[optionNumbers[2]];
            option3LineNumber = dialogueIndexDictionary[optionNumbers[3]];
            step++;
            dialogueOption1.text = dialogueList[step];
            step++;
            dialogueOption2.text = dialogueList[step];
            step++;
            dialogueOption3.text = dialogueList[step];
            trigger = false;
            step++;

        }
        /*
        else if (dialogueList[step].Contains("(optionEnd)"))
        {
            objOptionBar.SetActive(false);
            step++;
            NextStep();
        }
        */
        else
        {

            step++;
            NextStep();
        }


    }

    public void ReadDialogue(string tagName)
    {
        otherObjActive = false;
        step = dialogueIndexDictionary[tagName];
        print(tagName);
        print(step);
        NextStep();
    }
    public override Text GetSuitableText()
    {
        if (dialogueType == 0)
        {
            return dialogueText;


        }

        else
        {
            return null;
        }
    }




}
