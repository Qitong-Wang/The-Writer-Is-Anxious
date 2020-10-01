using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSecond : GlobalManager
{

    public GameObject frames;

    public GameObject myRoom;
    public GameObject arrows;

    public GameObject choicePanel;

    public GameObject currentObject;
    
    private List<CatChoices> currentChoices;
    public int room;

    public bool doorOpened = false;

    public GameObject bowl;
    public GameObject door;
    public CatPicture catpic;
    public GameObject cat;

    [TextArea]
    public string hearSome;
    [TextArea]
    public string milkFallingText;

    public bool milkCountDown = false;
    public Text countUI;
    public GameObject milk;
    public GameObject table;
    public GameObject knight;

    public bool death;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneStart());
        room = 1;
    }

    public override void StateCheck()
    {
        if (state == 1)
        {
            StartCoroutine(Next());
        }
        else if (state == 2)
        {
            StartCoroutine(Next());
        }
        else if (state == 3)
        {
            StartCoroutine(Next());
        }
        else if (state == 4)
        {
            StartCoroutine(TextGone());
        }
        else if (state == 5)
        {
            StartCoroutine(InspectRoom());
        }
        else if (state == 6)
        {
            if (death == true)
            {
                StartCoroutine(DeathEnding());
                return;
            }
            StartCoroutine(Knight());
        }
        else if (state == 7)
        {
            StartCoroutine(NextScene());
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowTextCat());
    }

    IEnumerator SceneStart()
    {
        
        yield return new WaitForSeconds(0.5f);
        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        sound.Play(0);
        myRoom.SetActive(true);
        arrows.SetActive(true);
        GameObject.Find("White").SetActive(false);
        frames.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowTextCat());
    }

    IEnumerator TextGone()
    {
        yield return new WaitForSeconds(0.5f);
        frames.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        fadeBlack.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1.5f);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator InspectRoom()
    {
        yield return new WaitForSeconds(0.5f);
        TapInspect();
    }

    public override void Inspect(Interactable i)
    {
        if (currentObject)
        {
            currentObject.GetComponent<SpriteRenderer>().sprite = currentObject.GetComponent<Interactable>().originalImage;
        }

        

        if (i.left)
        {
            room -= 1;
            if(room < 0)
            {
                room = 0;
            }
            tm.textBoxes[0].GetComponent<Text>().text = "";
            choicePanel.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Left");
            return;
        } else if (i.right)
        {
            room += 1;
            if (room >2)
            {
                room = 2;
            }
            tm.textBoxes[0].GetComponent<Text>().text = "";
            choicePanel.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            return;
        }
        currentObject = i.gameObject;
        if (i.changedImage)
        {
            currentObject.GetComponent<SpriteRenderer>().sprite = currentObject.GetComponent<Interactable>().changedImage;
        }
        if (milkCountDown)
        {
            tm.textBoxes[0].GetComponent<Text>().text = i.milkText;
            i.Use();
            return;
        }
        tm.textBoxes[0].GetComponent<Text>().text = i.intro;

        i.Use();

        if (i.hasChoice)
        {
            choicePanel.SetActive(true);
            choicePanel.transform.GetChild(0).gameObject.SetActive(false);
            choicePanel.transform.GetChild(1).gameObject.SetActive(false);
            currentChoices = new List<CatChoices> {};
            currentChoices.Clear();
            for (int j = 0; j <i.choices.Count; j++)
            {
                choicePanel.transform.GetChild(j).gameObject.SetActive(true);
                choicePanel.transform.GetChild(j).gameObject.GetComponentInChildren<Text>().text = i.choices[j].intro;
                currentChoices.Add(i.choices[j]);
            }
            /*
            choicePanel.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = i.choices[0].intro;
            choicePanel.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = i.choices[1].intro;
            currentChoices = new List<CatChoices> {i.choices[0], i.choices[1] };
            */
        } else
        {
            choicePanel.SetActive(false);
            choicePanel.transform.GetChild(0).gameObject.SetActive(false);
            choicePanel.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void ChoiceA()
    {
        choicePanel.SetActive(false);
        choicePanel.transform.GetChild(0).gameObject.SetActive(false);
        choicePanel.transform.GetChild(1).gameObject.SetActive(false);
        if (currentChoices[0].order == "text")
        {
            tm.textBoxes[0].GetComponent<Text>().text = currentChoices[0].newText;
            return;
        } else if (currentChoices[0].order == "death")
        {
            rayInspect = false;
            death = true;
            StartCoroutine(Death());
        } else if (currentChoices[0].order == "dorato")
        {
            if (doorOpened)
            {
                tm.textBoxes[0].GetComponent<Text>().text = "Ah. Cat's bowl is already full.";
                return;
            }
            rayInspect = false;
            //door Coroutine
            StartCoroutine(FeedDorato());
        } else if (currentChoices[0].order == "rotten")
        {
            if (doorOpened)
            {
                tm.textBoxes[0].GetComponent<Text>().text = "Ah. Cat's bowl is already full.";
                return;
            }
            rayInspect = false;
            StartCoroutine(FeedRotten());
        } else if (currentChoices[0].order == "push")
        {
            table.GetComponent<Table>().Push();
            if (!milkCountDown)
            {
                choicePanel.SetActive(true);
                choicePanel.transform.GetChild(0).gameObject.SetActive(true);
            }
            
        }
    }

    IEnumerator Death()
    {
        StartCoroutine(tm.ShowText("...You don't feel good. Your eyesight starts to blur...", 0));
        yield return null;
    }

    IEnumerator DeathEnding()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        sm.fantasy = "The hero died in the Cat's house because of eating rotten food.";
        SceneManager.LoadScene("SceneEnd");
    }

    public void ChoiceB()
    {
        choicePanel.SetActive(false);
        choicePanel.transform.GetChild(0).gameObject.SetActive(false);
        choicePanel.transform.GetChild(1).gameObject.SetActive(false);
        if (currentChoices[1].order == "text")
        {
            tm.textBoxes[0].GetComponent<Text>().text = currentChoices[1].newText;
            return;
        }
        else if (currentChoices[1].order == "death")
        {
            rayInspect = false;
            death = true;
            StartCoroutine(Death());
        }
        else if (currentChoices[1].order == "dorato")
        {
            if (doorOpened)
            {
                tm.textBoxes[0].GetComponent<Text>().text = "Ah. Cat's bowl is already full.";
                return;
            }
            rayInspect = false;
            //door Coroutine
            StartCoroutine(FeedDorato());
        }
        else if (currentChoices[1].order == "rotten")
        {
            if (doorOpened)
            {
                tm.textBoxes[0].GetComponent<Text>().text = "Ah. Cat's bowl is already full.";
                return;
            }
            rayInspect = false;
            StartCoroutine(FeedRotten());
        }
    }

    IEnumerator FeedDorato()
    {
        tm.textBoxes[0].GetComponent<Text>().text = "";
        doorOpened = true;
        cat.GetComponent<Animator>().SetTrigger("Dorato");
        sm.catRoom = "dorato";
        //move back to catroom
        yield return new WaitForSeconds(0.5f);
        if (room == 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        } else if (room == 2)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Left");
            yield return new WaitForSeconds(0.5f);
        }
        room = 1;
        tm.textBoxes[0].GetComponent<Text>().text = hearSome;
        door.GetComponent<Door>().OpenTheDoor();
        bowl.GetComponent<Bowl>().FillBowl(0);
        catpic.UpdatePic(0);

        rayInspect = true;
        sm.fantasy = "The hero got out of Cat's house.";
    }

    IEnumerator FeedRotten()
    {
        tm.textBoxes[0].GetComponent<Text>().text = "";
        doorOpened = true;
        sm.catRoom = "rotten";
        cat.GetComponent<Animator>().SetTrigger("Rotten");
        //move back to catroom
        yield return new WaitForSeconds(0.5f);
        if (room == 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        }
        else if (room == 2)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Left");
            yield return new WaitForSeconds(0.5f);
        }
        room = 1;
        tm.textBoxes[0].GetComponent<Text>().text = hearSome;
        door.GetComponent<Door>().OpenTheDoor();
        bowl.GetComponent<Bowl>().FillBowl(1);
        catpic.UpdatePic(1);

        rayInspect = true;
        sm.fantasy = "The hero successfully pissed Cat off. She did not even want to stay in the same room with him for one more second. The hero was expelled from the house.";
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.5f);
        tm.textBoxes[0].GetComponent<Text>().text = milkFallingText;
        
        milk.GetComponent<Animator>().SetTrigger("Shake");
        for (int i = 10; i > 0; i--)
        {
            if (milkCountDown == false)
            {
                countUI.gameObject.SetActive(false);
                StartCoroutine(FeedMilk());
                yield break;
            }
            yield return new WaitForSeconds(1f);
            countUI.text = i.ToString();
        }
        milkCountDown = false;
        countUI.gameObject.SetActive(false);
        StartCoroutine(SpillMilk());
    }

    IEnumerator FeedMilk()
    {
        doorOpened = true;
        cat.GetComponent<Animator>().SetTrigger("Milk");
        sm.catRoom = "milk";
        tm.textBoxes[0].GetComponent<Text>().text = "";
        rayInspect = false;
        //move back to kitchen
        yield return new WaitForSeconds(0.5f);
        if (room == 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        }
        else if (room == 1)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        }
        room = 2;
        bowl.GetComponent<Animator>().SetTrigger("Catch");
        yield return new WaitForSeconds(1.2f);
        milk.SetActive(false);
        tm.textBoxes[0].GetComponent<Text>().text = "Safe.";
        yield return new WaitForSeconds(1f);
        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Left");
        bowl.GetComponent<Animator>().SetTrigger("Milk");
        yield return new WaitForSeconds(0.5f);

        fadeBlack.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);

        tm.textBoxes[0].GetComponent<Text>().text = hearSome;
        door.GetComponent<Door>().OpenTheDoor();
        bowl.GetComponent<Bowl>().FillBowl(2);
        catpic.UpdatePic(2);

        rayInspect = true;

        sm.fantasy = "The hero won Cat's heart by feeding her favorite milk to her. When the hero left, Cat missed him so much that she went on her own adventure to find the hero...";
    }

    IEnumerator SpillMilk()
    {
        tm.textBoxes[0].GetComponent<Text>().text = "";
        rayInspect = false;
        //move back to kitchen
        yield return new WaitForSeconds(0.5f);
        if (room == 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        }
        else if (room == 1)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Right");
            yield return new WaitForSeconds(0.5f);
        }
        room = 2;
        milk.GetComponent<Animator>().SetTrigger("Spill");

        tm.textBoxes[0].GetComponent<Text>().text = "Uh-oh.";
        milk.GetComponent<Interactable>().intro = "Uh-oh.";
        GameObject.Find("friger_upper").GetComponent<Interactable>().intro = "Spilled milk does not make you any taller.";

        rayInspect = true;
        sm.milk = "And, the hero also spilled the milk. When Cat found that, she cried, deeply.";
    }

    IEnumerator Knight()
    {
        knight.SetActive(true);
        StartCoroutine(tm.ShowText());
        yield return null;
    }

    IEnumerator NextScene()
    {
        //scenemanage
        sound.Stop();
        SceneManager.LoadScene("SceneRPG");
        yield return null;
        
    }
}
