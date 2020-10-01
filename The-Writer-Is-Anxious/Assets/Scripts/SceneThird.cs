using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneThird : GlobalManager
{
    public Player player;
    public GameObject interactButton;
    public GameObject choiceA;
    public GameObject choiceB;

    public bool death;
    private bool checkstate;
    void Start()
    {
        sm.adventure = true;
        choiceA = GameObject.Find("ChoicePanel").transform.GetChild(0).gameObject;
        choiceB = GameObject.Find("ChoicePanel").transform.GetChild(1).gameObject;
        interactButton = GameObject.Find("ChoicePanel").transform.GetChild(2).gameObject;

        player = FindObjectOfType<Player>();
        player.hp = 5;
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
            if (death)
            {
                StartCoroutine(Death());
                return;
            }
            StartCoroutine(BeforeFight());
        } else if (state == 4)
        {
            if (death)
            {
                StartCoroutine(DeathEnding());
                return;
            }
            StartFight();
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
        sm.adventureWord = "The hero died on the way.";
        SceneManager.LoadScene("SceneEnd");
    }


    IEnumerator Next()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(0.5f);
        sound.Play(1);
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
        sound.Stop();
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
       
    }

    void StartFight()
    {
        sm.adventureWord = "The hero made it to the dragon's place.";
        sm.coin = player.coins;
        sm.hp = player.hp;
        SceneManager.LoadScene("SceneRPGDragon");
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
