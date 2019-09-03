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
    public GameObject objDialogueText;
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

    public bool[] evidenceUnlock = new bool[5]{ false, false, false, false, false };
    public int currentExamIndex = 1;
    public bool unlockExam31 = false;
    public bool unlockExam41 = false;
    public bool unlockExam42 = false;
    public bool finishExam = false;
    
    //Objects
    public int love = 0;
    public GameObject objPrincess;
    public GameObject objMan;
    public GameObject objCapBoy;
    public GameObject objMainBG;
    public GameObject objSceneEvidence;
    public GameObject objEvidenceBar;
    public GameObject[] objExamEvidenceUnlock;
    public GameObject objEvidenceBarCloseButton;
    public GameObject objExamAction;
    public GameObject objEvidenceAction;
    public GameObject objEvidenceBook;
    public GameObject objObjection;

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
                    && dialogueList[i].Contains("(Jump") == false )
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
            objDialogueText.SetActive(false);
            objTagText.SetActive(false);
            objNameTag.SetActive(false);
            objMysteryDialogueTag.SetActive(false);
            objMysteryDialogue.SetActive(false);
            otherObjActive = true;
            trigger = false;
        }
        else if (dialogueList[step].Contains("(Think)"))
        {
            
            string dialogueContent = dialogueList[step].Substring(7, dialogueList[step].Length - 7);
            dialogueText.text = dialogueContent;
            step++;
        }
        else if (dialogueList[step].Contains("(Mystery Open)"))
        {
            romanceStyle = false;
            objMysteryDialogueTag.SetActive(true);
            objTagText.SetActive(true);
            objDialogueText.SetActive(true);
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
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#MysteryWithTag)"))
        {
            romanceStyle = false;
            objMysteryDialogue.SetActive(false);
            objMysteryDialogueTag.SetActive(true);
            dialogueObj.SetActive(true);
            objTagText.SetActive(true);
            objDialogueText.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#MysteryWithoutTag)"))
        {
            romanceStyle = false;
            objMysteryDialogue.SetActive(true);
            objMysteryDialogueTag.SetActive(false);
            dialogueObj.SetActive(true);
            objTagText.SetActive(false);
            objDialogueText.SetActive(true);
            step++;
            NextStep();
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
        else if (dialogueList[step].Contains("(#ShowBackground1)"))
        {
            objSceneEvidence.SetActive(true);
            objMainBG.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(Examination_"))
        {
            if (dialogueList[step].Contains("(Examination_1)")){
                currentExamIndex = 1;
            }
            else if (dialogueList[step].Contains("(Examination_2)"))
            {
                currentExamIndex = 2;
            }
            else if (dialogueList[step].Contains("(Examination_3)"))
            {
                currentExamIndex = 3;
            }
            else if (dialogueList[step].Contains("(Examination_31)"))
            {
                currentExamIndex = 31;
            }
            else if (dialogueList[step].Contains("(Examination_4)"))
            {
                currentExamIndex = 4;
            }
            else if (dialogueList[step].Contains("(Examination_41)"))
            {
                currentExamIndex = 41;
            }
            else if (dialogueList[step].Contains("(Examination_42)"))
            {
                currentExamIndex = 42;
            }
            else if (dialogueList[step].Contains("(Examination_5)"))
            {
                currentExamIndex = 5;
            }
            otherObjActive = true;
            trigger = false;
            dialogueText.text = dialogueList[step+1];

        }
        else if (dialogueList[step].Contains("(ExamBegin3)"))
        {
            if (unlockExam31 == true)
            {
                ReadDialogue("ExamBegin31");
            }
            else
            {
                step++;
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(ExamBegin4)"))
        {
            if (unlockExam41 == true && unlockExam42 == true)
            {
                ReadDialogue("ExamBegin42");
            }
            else if (unlockExam41 == true && unlockExam42 == false)
            {
                ReadDialogue("ExamBegin41");
            }
            else
            {
                step++;
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(ExamBegin41)"))
        {
            if (unlockExam42 == true)
            {
                ReadDialogue("ExamBegin42");
            }
            else
            {
                step++;
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(CheckCondition31)"))
        {
            if (unlockExam42 == true)
            {
                ReadDialogue("SatisfyCondition31");
            }
            else
            {
                step++;
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(CheckCondition42)"))
        {
            if (unlockExam31 == true)
            {
                ReadDialogue("SatisfyCondition42");
            }
            else
            {
                step++;
                NextStep();
            }
        }
        else if (dialogueList[step].Contains("(#TestimonyUpdate3)"))
        {
            unlockExam31 = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#TestimonyUpdate4)"))
        {
            unlockExam41 = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#TestimonyUpdate41)"))
        {
            unlockExam42 = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#ObjectionSign)"))
        {
            objEvidenceBook.SetActive(false);
            finishExam = true;
            objObjection.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#EvidenceBarDisappear)"))
        {
            objObjection.SetActive(false);
            objEvidenceBook.SetActive(false);
            objEvidenceBar.SetActive(false);
            objEvidenceAction.SetActive(false);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#ShowBG)"))
        {
            objMainBG.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#ShowExaminationAction)"))
        {
            objMainBG.SetActive(false);
            objMysteryDialogueTag.SetActive(true);
            objTagText.SetActive(true);
            objDialogueText.SetActive(true);
            objSceneEvidence.SetActive(false);
            objEvidenceBar.SetActive(true);
            objEvidenceBarCloseButton.SetActive(false);
            dialogueObj.SetActive(true);
            objEvidenceAction.SetActive(true);
            for (int i = 0; i < evidenceUnlock.Length; i++)
            {
                if (evidenceUnlock[i] == true)
                {
                    objExamEvidenceUnlock[i].SetActive(true);
                }
                else
                {
                    objExamEvidenceUnlock[i].SetActive(false);
                }
            }
            objExamAction.SetActive(true);
            step++;
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
        else
        {
            print("here");  
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
