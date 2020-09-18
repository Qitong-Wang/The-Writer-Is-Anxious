using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneThird : GlobalManager
{
    public Player player;
    public GameObject interactButton;
    public GameObject choiceA;
    public GameObject choiceB;

    private bool checkstate;
    void Start()
    {
        choiceA = GameObject.Find("ChoicePanel").transform.GetChild(0).gameObject;
        choiceB = GameObject.Find("ChoicePanel").transform.GetChild(1).gameObject;
        interactButton = GameObject.Find("ChoicePanel").transform.GetChild(2).gameObject;

        player = FindObjectOfType<Player>();
        player.hp = 3;
        player.coins = 0;
        StartCoroutine(SceneStart());
    }

    public override void Update()
    {
        if (!waitingTap)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            //print("tya");
            waitingTap = false;
            
            if (checkstate)
            {
                state++;
                StateCheck();
                checkstate = false;
                tm.ClearText();
                return;
            }
            tm.textBoxes[0].GetComponent<Text>().text = "";
            FindObjectOfType<Player>().ActivatePlayer();
        }
    }

    public override void StateCheck()
    {
        if (state == 1)
        {
            StartCoroutine(Next());
        } else if (state == 2)
        {
            StartAdventure();
        } else if (state == 3)
        {
            StartCoroutine(BeforeFight());
        } else if (state == 4)
        {
            StartFight();
        }
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(1f);
        player.StopPlayer();
        interactButton.SetActive(false);
        StartCoroutine(tm.ShowText());
        yield return null;
    }

    void StartAdventure()
    {
        player.ActivatePlayer();
    }

    IEnumerator BeforeFight()
    {
        player.StopPlayer();
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
       
    }

    void StartFight()
    {
        //scenetransfer;
    }
    public override void TapToContinue(bool ray = false)
    {
        waitingTap = true;
        checkstate = true;
    }

    public override void TapFinish()
    {
        waitingTap = true;
    }
}
