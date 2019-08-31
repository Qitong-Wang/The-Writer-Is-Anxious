using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene31Manager : NormalSceneManager
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

  
    //Option
    public Text dialogueOption1;
    public Text dialogueOption2;
    public GameObject objOption1;
    public GameObject objOption2;
    public int option1LineNumber;
    public int option2LineNumber;

    
 
    public SpriteRenderer knightSprite;
    public GameObject objKingDialogue;
    public bool getSword = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene31King") as TextAsset;
        dialogueIndexDictionary = new Dictionary<string, int>();
        ReadTextFile();
        otherObjActive = false;
        ReadDialogue("King open");

    }
    public override void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
        for (int i = 0; i < dialogueList.Count; i++)
        {
            if (dialogueList[i][0] == '(')
            {

                if (dialogueList[i].Contains("end") == false && dialogueList[i].Contains("(stop @)") == false
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
        else if (dialogueList[step].Contains("(end)"))
        {
            dialogueObj.SetActive(false);
            otherObjActive = true;
            trigger = false;
        }
        else if (dialogueList[step].Contains("(KnightAppear)"))
        {
            StartCoroutine(FadeTo(255, 20));
            step++;
            NextStep();

        }
       
        else if (dialogueList[step].Contains("(Check)"))
        {
           if (getSword == true)
            {
                step = dialogueIndexDictionary["Ending"];
                NextStep();
            }
            else
            {
                getSword = true;
                step++;
                NextStep();
            }

        }
        else if (dialogueList[step].Contains("(SwordAnimation)"))
        {
           
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(option"))
        {
            string[] optionNumbers = dialogueList[step].Split(" "[0]);
            objOption1.SetActive(true);
            objOption2.SetActive(true);
            option1LineNumber = dialogueIndexDictionary[optionNumbers[1]];
            option2LineNumber = dialogueIndexDictionary[optionNumbers[2]];
            step++;
            dialogueOption1.text = dialogueList[step];
            step++;
            dialogueOption2.text = dialogueList[step];
            trigger = false;
            step++;

        }
        else if (dialogueList[step].Contains("(Jump"))
        {
            string[] optionNumbers = dialogueList[step].Split(" "[0]);
            step = dialogueIndexDictionary[optionNumbers[1]];
            NextStep();
        }
        else if (dialogueList[step].Contains("(NoKing)"))
        {
            objKingDialogue.SetActive(false);
            step++;
            NextStep();
        }

        else if (dialogueList[step].Contains("(optionEnd)"))
        {
            objOption1.SetActive(false);
            objOption2.SetActive(false);
            step++;
            NextStep();
        }

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

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = knightSprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(255, 255, 255, Mathf.Lerp(alpha, aValue, t));
            knightSprite.color = newColor;
            yield return null;
        }
    }


}
