using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneThirdDragon : GlobalManager
{
    public GameObject fires;
    public GameObject dragon;
    public GameObject princess;

    private GameObject health;

    public Player player;
    public GameObject interactButton;
    public GameObject choiceA;
    public GameObject choiceB;

    public int round;
    public bool fireGone = true;
    public int fireOn;
    public bool weakness = false;
    public bool endFight = false;

    [TextArea]
    public string waitTxt;
    [TextArea]
    public string atkTxt;
    [TextArea]
    public string dragonatkTxt;
    [TextArea]
    public string avoidTxt;
    [TextArea]
    public string hurtTxt;
    [TextArea]
    public string weakFailTxt;
    // Start is called before the first frame update
    void Start()
    {
       
        round = 0;
        fireOn = 0;
        choiceA = GameObject.Find("ChoicePanel").transform.GetChild(0).gameObject;
        choiceB = GameObject.Find("ChoicePanel").transform.GetChild(1).gameObject;
        interactButton = GameObject.Find("ChoicePanel").transform.GetChild(2).gameObject;
        health = GameObject.Find("Health");

        player = FindObjectOfType<Player>();
        player.hp = 3; // =save

        StartCoroutine(SceneStart());
    }

    public override void Update()
    {
        if (!fireGone)
        {
            if (weakness)
            {
                if (fireOn > 1)
                {
                    weakness = false;
                    tm.textBoxes[0].GetComponent<Text>().text = weakFailTxt;
                } else
                {
                    weakness = false;
                    StartCoroutine(Kill());
                    endFight = true;
                }
            }
            if (fireOn == 0)
            {
                fireGone = true;
                StopCoroutine(DragonAtk());
                StartCoroutine(Avoid());
            }
        }

        if (!waitingTap)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            //print("tya");
            waitingTap = false;

            state++;
            StateCheck();
            tm.ClearText();
        }
    }

    public override void TapToContinue(bool ray = false)
    {
        waitingTap = true;
    }

    IEnumerator SceneStart()
    {
        player.StopPlayer();
        yield return new WaitForSeconds(0.5f);
        Wait();
    }

    public override void StateCheck()
    {
        if (state == 1)
        {
            Debug.Log("next scene");
        }
    }

    private void Wait()
    {
        
        tm.textBoxes[0].GetComponent<Text>().text = waitTxt;
        choiceA.SetActive(true);
        choiceA.GetComponentInChildren<Text>().text = "Attack";
        choiceA.GetComponent<Button>().onClick.AddListener(ChooseAttack);
    }

    public void ChooseAttack()
    {
        choiceA.SetActive(false);
        choiceA.GetComponentInChildren<Text>().text = "";
        choiceA.GetComponent<Button>().onClick.RemoveListener(ChooseAttack);
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        dragon.GetComponent<Animator>().SetTrigger("Hurt");
        tm.textBoxes[0].GetComponent<Text>().text = atkTxt;
        yield return new WaitForSeconds(2f);
        //dragon.GetComponent<Animator>().SetTrigger("Finish");
        StartCoroutine(DragonAtk());
    }

    private IEnumerator DragonAtk()
    {
        tm.textBoxes[0].GetComponent<Text>().text = dragonatkTxt;
        round++;
        fireGone = false;
        if (round == 1)
        {
            dragon.GetComponent<Animator>().SetTrigger("Attack");
            fires.transform.GetChild(0).gameObject.SetActive(true);
            fireOn = 1;
        } else if (round == 2)
        {
            dragon.GetComponent<Animator>().SetTrigger("Attack");
            fires.transform.GetChild(0).gameObject.SetActive(true);
            fires.transform.GetChild(1).gameObject.SetActive(true);
            fireOn = 2;
        }
        else
        {
            dragon.GetComponent<Animator>().SetTrigger("Attack2");
            fires.transform.GetChild(0).gameObject.SetActive(true);
            fires.transform.GetChild(1).gameObject.SetActive(true);
            fires.transform.GetChild(2).gameObject.SetActive(true);
            fireOn = 3;
        }
        yield return new WaitForSeconds(5f);
        if (endFight)
            yield break;
        if (!fireGone)
            StartCoroutine(Hurt());
        
    }

    private IEnumerator Hurt()
    {
        dragon.GetComponent<Animator>().SetTrigger("Finish");
        fires.transform.GetChild(0).gameObject.SetActive(false);
        fires.transform.GetChild(1).gameObject.SetActive(false);
        fires.transform.GetChild(2).gameObject.SetActive(false);

        tm.textBoxes[0].GetComponent<Text>().text = hurtTxt;
        player.DecreaseHP();
        yield return new WaitForSeconds(2f);
        Wait();
    }

    private IEnumerator Avoid()
    {
        dragon.GetComponent<Animator>().SetTrigger("Finish");
        tm.textBoxes[0].GetComponent<Text>().text = avoidTxt;
        yield return new WaitForSeconds(2f);
        Wait();
    }

    private IEnumerator Kill()
    {
        fires.transform.GetChild(0).gameObject.SetActive(false);
        fires.transform.GetChild(1).gameObject.SetActive(false);
        fires.transform.GetChild(2).gameObject.SetActive(false);

        tm.textBoxes[0].GetComponent<Text>().text = "";
        dragon.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        health.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        dragon.SetActive(false);
        princess.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
    }

}
