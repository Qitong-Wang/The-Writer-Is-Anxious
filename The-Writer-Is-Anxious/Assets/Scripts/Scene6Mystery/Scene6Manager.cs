using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene6Manager : NormalSceneManager
{

    /// <summary>
    /// Default is 0, at dialogueText.
    /// </summary>
    int dialogueType = 0;
    public bool romanceStyle = false;
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
    public GameObject objTagText;
    //Option
    public Text dialogueOption1;
    public Text dialogueOption2;
    public Text dialogueOption3;
    public GameObject objOptionBar;
    public GameObject objOption1;
    public GameObject objOption2;
    public GameObject objOption3;
    public int option1LineNumber;
    public int option2LineNumber;
    public int option3LineNumber;

    //Mystery Style objects
    public GameObject objMysteryDialogueTag;
    public GameObject objMysteryDialogue;
    //Objects
    public int love = 0;
    public GameObject objPrincess;
    public GameObject objMan;
    public GameObject objCapBoy;
    public GameObject objKnight;
    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene6Mystery") as TextAsset;
        dialogueIndexDictionary = new Dictionary<string, int>();
        ReadTextFile();
        otherObjActive = false;
        ReadDialogue("Mystery Open");

    }
    public override void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
        for (int i = 0; i < dialogueList.Count; i++)
        {
            if (dialogueList[i][0] == '(')
            {

                if (dialogueList[i].Contains("end") == false && dialogueList[i].Contains("(#") == false
                    && dialogueList[i].Contains("(Jump") == false)
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
        if (dialogueList[step].Contains("(Think)"))
        {
            
            string dialogueContent = dialogueList[step].Substring(7, dialogueList[step].Length - 7);
            dialogueText.text = dialogueContent;
            step++;
        }
        else if (dialogueList[step].Contains("(Mystery Open)"))
        {
            romanceStyle = false;
            objMysteryDialogueTag.SetActive(true);
            otherObjActive = false;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#PrincessAppear)"))
        {
            objPrincess.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#PrincessDisappear)"))
        {
            objPrincess.SetActive(false);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#KnightAppear)"))
        {
            objKnight.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#KnightDisappear)"))
        {
            objKnight.SetActive(false);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#ManAppear)"))
        {
            objMan.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#ManDisappear)"))
        {
            objMan.SetActive(false);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#CapBoyAppear)"))
        {
            objCapBoy.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#CapBoyDisappear)"))
        {
            objCapBoy.SetActive(false);
            step++;
            NextStep();
        }
     
        else if (dialogueList[step].Contains("(#Princess)"))
        {
            if (romanceStyle == true)
            {
                objNameTag.SetActive(true);
            }
            else
            {
                objMysteryDialogue.SetActive(false);
                objMysteryDialogueTag.SetActive(true);
            }
            objTagText.SetActive(true);
            nameTagText.text = "Princess";
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#Knight)"))
        {
            if(romanceStyle == true)
            {
                objNameTag.SetActive(true);
            }
            else
            {
                objMysteryDialogue.SetActive(false);
                objMysteryDialogueTag.SetActive(true);
            }
            objTagText.SetActive(true);
            nameTagText.text = "Knight";
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#Man)"))
        {
            if(romanceStyle == true)
            {
                objNameTag.SetActive(true);
            }
            else
            {
                objMysteryDialogue.SetActive(false);
                objMysteryDialogueTag.SetActive(true);
            }
            objTagText.SetActive(true);
            nameTagText.text = "Man";
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#CapBoy)"))
        {
            if(romanceStyle == true)
            {
                objNameTag.SetActive(true);
            }
            else
            {
                objMysteryDialogue.SetActive(false);
                objMysteryDialogueTag.SetActive(true);
            }
            objTagText.SetActive(true);
            nameTagText.text = "CapBoy";
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#RomanceStyle)"))
        {
            romanceStyle = true;
            objMysteryDialogue.SetActive(false);
            objMysteryDialogueTag.SetActive(false);
            dialogueObj.SetActive(true);
        }
        else if (dialogueList[step].Contains("(#Love+10)"))
        {
            love += 10;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(CheckLove_1)"))
        {
            if (love >= 60)
            {
                step++;
                NextStep();
            }
            else
            {
                step = dialogueIndexDictionary["MysteryStep1"];
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(Jump"))
        {
            string[] optionNumbers = dialogueList[step].Split(" "[0]);
            step = dialogueIndexDictionary[optionNumbers[1]];
            NextStep();
        }
        else if (dialogueList[step].Contains("(option3"))
        {
            string[] optionNumbers = dialogueList[step].Split(" "[0]);
            objOptionBar.SetActive(true);
            objOption1.SetActive(true);
            objOption2.SetActive(true);
            objOption3.SetActive(true);
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
