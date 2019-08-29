using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene2Manager : NormalSceneManager
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

    public int roomIndex;
    //Option
    public Text dialogueOption1;
    public Text dialogueOption2;
    public GameObject objOption1;
    public GameObject objOption2;
    public int option1LineNumber;
    public int option2LineNumber;
   
    //Catroom
    bool firstVisit = false;
    public GameObject objCatroom;
    public GameObject objBowl;
    public GameObject objItemBowl;
    public bool pickupBowl = false;
    public SpriteRenderer shelfMiddle;
    public Sprite shelfMiddleNormal;
    public Sprite shelfMiddleTmp;
    public SpriteRenderer shelfBelow;
    public Sprite shelfBelowNormal;
    public Sprite shelfBelowDoratos;
    public bool afterDoratosCat = false;
    public GameObject objBowlWithDoratos;
    public SpriteRenderer meow;
    public Sprite thankfulMeow;
    public bool afterRottenFoodCat = false;
    public SpriteRenderer cat;
    public Sprite shockedCat;
    public SpriteRenderer tail;
    public Sprite shockedTail;
    public GameObject objMeow;
    public GameObject objBowlWithRootenFood;
    public GameObject objBowlWithMilk;
    public Sprite cheerfulMeow;

    //Kitchen
    public GameObject objKitchen;
    public bool afterFrigerAppear = false;
    public SpriteRenderer frigerBelow;
    public Sprite rottenFood;
    public GameObject objMilkTimer;
    public GameObject objMilk;
    public GameObject objMilkOnFloor;
    public bool afterDropMilk = false;
    public GameObject objmilkInBowl;
    public bool afterMilkBowl = false;
    public bool afterMilkCat = false;


    //EntryWay
    public GameObject objEntryWay;
    public SpriteRenderer lockedDoor;
    public Sprite openedDoor;
    public SpriteRenderer catPicture;
    public Sprite catPicCheer;
    public Sprite catPicAngry;
    public Sprite catPicNormal;
    public GameObject objKnight;

    


    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene2Catroom") as TextAsset;
        dialogueIndexDictionary = new Dictionary<string, int>();
        ReadTextFile();
        otherObjActive = false;
        ReadDialogue("Catroom Open");

    }
    public override void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
        for (int i = 0; i < dialogueList.Count; i++)
        {
            if (dialogueList[i][0] == '(')
            {
               
                if(dialogueList[i].Contains("end") == false && dialogueList[i].Contains("(stop @)") == false
                   && dialogueList[i].Contains("(#") == false)
                {
                    //Add the tag to the dictionary. 
                    dialogueIndexDictionary.Add(dialogueList[i].Substring(1,dialogueList[i].Length-3), i );
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
        else if (dialogueList[step].Contains("(Catroom Open)"))
        {
            dialogueObj.SetActive(true);
            otherObjActive = false;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(pickup bowl)"))
        {
            Destroy(objBowl);
            objItemBowl.SetActive(true);
            pickupBowl = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(shelfmiddle start)"))
        {
            shelfMiddle.sprite = shelfMiddleTmp;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(shelfmiddle end)"))
        {
            shelfMiddle.sprite = shelfMiddleNormal;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(shelfbelow start)"))
        {
            shelfBelow.sprite = shelfBelowDoratos;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(shelfbelow end)"))
        {
            shelfBelow.sprite = shelfBelowNormal;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(DoratosCat)"))
        {
            if (pickupBowl == false)
            {
                ReadDialogue("DoratosCatWithoutBowl");
            }
            else
            {
                ReadDialogue("DoratosCatWithBowl");
            }
        }
        else if (dialogueList[step].Contains("(afterDoratosCat)"))
        {
            afterDoratosCat = true;
            objBowlWithDoratos.SetActive(true);
            objBowlWithDoratos.transform.SetParent(objCatroom.transform);
            objItemBowl.SetActive(false);
            pickupBowl = false;
            meow.sprite = thankfulMeow;
            lockedDoor.sprite = openedDoor;
            catPicture.sprite = catPicNormal;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(RottonFoodAppear)"))
        {
            frigerBelow.sprite = rottenFood;
            afterFrigerAppear = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(RottenFoodCat)"))
        {
            if (pickupBowl == true)
            {
                ReadDialogue("RottenFoodWithBowl");
            }
            else
            {
                ReadDialogue("RottenFoodWithoutBowl");
            }
        }
        else if (dialogueList[step].Contains("(afterRottenFoodCat)"))
        {
            objBowlWithRootenFood.transform.SetParent(objCatroom.transform);
            objBowlWithRootenFood.SetActive(true);
            objKitchen.SetActive(false);
            objCatroom.SetActive(true);
            cat.sprite = shockedCat;
            tail.sprite = shockedTail;
            Destroy(objMeow);
            pickupBowl = false;
            objItemBowl.SetActive(false);
            roomIndex = 0;
            catPicture.sprite = catPicAngry;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(milkTimer)"))
        {
            objMilkTimer.SetActive(true);
            objMilkTimer.GetComponent<Scene2MilkTimer>().startTimer = true;
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(milkTimerFinish)"))
        {
            StartCoroutine("ResetTriggerTrue");
            otherObjActive = false;
            dialogueObj.SetActive(true);
            objMilkTimer.SetActive(false);
            if (pickupBowl == false)
            {
                
                objMilkOnFloor.transform.parent = objKitchen.transform;
                objMilkOnFloor.SetActive(true);
                afterDropMilk = true;
            }
            Destroy(objMilk);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(milkWithBowl)"))
        {
            StartCoroutine("ResetTriggerTrue");
            otherObjActive = false;
            dialogueObj.SetActive(true);
            objMilkTimer.SetActive(false);
            step++;
            NextStep();

        }
        else if (dialogueList[step].Contains("(afterMilkBowl)"))
        {
            StartCoroutine("ResetTriggerTrue");
            objmilkInBowl.SetActive(true);
            pickupBowl = false;
            Destroy(objMilk);
            objItemBowl.SetActive(false);
            afterMilkBowl = true;
            objEntryWay.SetActive(false);
            objKitchen.SetActive(true);
            objCatroom.SetActive(false);
            roomIndex = 1;
            step++;
            NextStep();
            
        }
        else if (dialogueList[step].Contains("(GetOutCottage)"))
        {
            objKnight.SetActive(true);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(afterMilkBowlCatroom)"))
        {
            objmilkInBowl.SetActive(false);
            objBowlWithMilk.transform.SetParent(objCatroom.transform);
            objBowlWithMilk.SetActive(true);
            objKitchen.SetActive(false);
            objCatroom.SetActive(true);
            roomIndex = 0;
            meow.sprite = cheerfulMeow;
            lockedDoor.sprite = openedDoor;
            catPicture.sprite = catPicCheer;
            step++;
            afterMilkCat = true;
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
        else if (dialogueList[step].Contains("(optionEnd)"))
        {
            objOption1.SetActive(false);
            objOption2.SetActive(false);
            step++;
            NextStep();
        }
        else if (dialogueList[step].Contains("(#Shove)"))
        {
            objMilk.GetComponent<Animator>().SetTrigger("shake");
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




}
