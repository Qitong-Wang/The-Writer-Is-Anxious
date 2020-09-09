using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSecond : GlobalManager
{

    public GameObject frames;

    public GameObject myRoom;
    public GameObject arrows;

    public GameObject choicePanel;

    public GameObject currentObject;
    
    private List<CatChoices> currentChoices;
    public int room;

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
        myRoom.SetActive(true);
        arrows.SetActive(true);
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
        tm.textBoxes[0].GetComponent<Text>().text = i.intro;
        if (i.changedImage)
        {
            currentObject.GetComponent<SpriteRenderer>().sprite = currentObject.GetComponent<Interactable>().changedImage;
        }
        if (i.hasChoice)
        {
            choicePanel.SetActive(true);
            choicePanel.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = i.choices[0].intro;
            choicePanel.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = i.choices[1].intro;
            currentChoices = new List<CatChoices> {i.choices[0], i.choices[1] };
        } else
        {
            choicePanel.SetActive(false);
        }
    }

    public void ChoiceA()
    {
        choicePanel.SetActive(false);
        if (currentChoices[0].order == "text")
        {
            tm.textBoxes[0].GetComponent<Text>().text = currentChoices[0].newText;
            return;
        } else if (currentChoices[0].order == "death")
        {
            rayInspect = false;
            //Death Coroutine
        } else if (currentChoices[0].order == "door")
        {
            rayInspect = false;
            //door Coroutine
        }
    }

    public void ChoiceB()
    {
        choicePanel.SetActive(false);
        if (currentChoices[1].order == "text")
        {
            tm.textBoxes[0].GetComponent<Text>().text = currentChoices[1].newText;
            return;
        }
        else if (currentChoices[1].order == "death")
        {
            rayInspect = false;
            //Death Coroutine
        }
        else if (currentChoices[1].order == "door")
        {
            rayInspect = false;
            //door Coroutine
        }
    }
}
