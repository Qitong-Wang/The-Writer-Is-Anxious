using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public bool death;
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
        player.hp = sm.hp; // =save
        player.coins = sm.coin;
        player.UpdateCoinText();
        player.UpdateHPText();
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
    public void Death()
    {
        endFight = true;
        dragon.GetComponent<Animator>().SetTrigger("Finish");
        fires.transform.GetChild(0).gameObject.SetActive(false);
        fires.transform.GetChild(1).gameObject.SetActive(false);
        fires.transform.GetChild(2).gameObject.SetActive(false);
        death = true;
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        StartCoroutine(tm.ShowText("...You don't feel good. Your eyesight starts to blur...", 0));
    }

    IEnumerator DeathEnding()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        sm.dragonWord = "But the hero was killed by Dragon.";
        SceneManager.LoadScene("SceneEnd");
    }
    public override void TapToContinue(bool ray = false)
    {
        waitingTap = true;
    }

    IEnumerator SceneStart()
    {
        sound.Play(2);
        player.StopPlayer();
        yield return new WaitForSeconds(0.5f);
        Wait();
    }

    public override void StateCheck()
    {
        if (state == 1)
        {
            if (death)
            {
                StartCoroutine(DeathEnding());
                return;
            }
            sm.dragonWord = "After an intense fight, the hero slayed the dragon and saved the princess.";
            sm.hp = player.hp;
            sm.saveP++;
            sound.Stop();
            SceneManager.LoadScene("SceneRomance");
        }
    }

    private void Wait()
    {
        if (death)
            return;
        tm.textBoxes[0].GetComponent<Text>().text = waitTxt;
        choiceA.SetActive(true);
        choiceA.GetComponentInChildren<Text>().text = "Attack";
        choiceA.GetComponent<Button>().onClick.AddListener(ChooseAttack);
    }

    public void ChooseAttack()
    {
        if (death)
            return;
        choiceA.SetActive(false);
        choiceA.GetComponentInChildren<Text>().text = "";
        choiceA.GetComponent<Button>().onClick.RemoveListener(ChooseAttack);
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        if (death)
            yield break;
        dragon.GetComponent<Animator>().SetTrigger("Hurt");
        tm.textBoxes[0].GetComponent<Text>().text = atkTxt;
        yield return new WaitForSeconds(2f);
        //dragon.GetComponent<Animator>().SetTrigger("Finish");
        StartCoroutine(DragonAtk());
    }

    private IEnumerator DragonAtk()
    {
        if (death)
            yield break;
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
        if (death)
            yield break;
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
        if (death)
            yield break;
        dragon.GetComponent<Animator>().SetTrigger("Finish");
        tm.textBoxes[0].GetComponent<Text>().text = avoidTxt;
        yield return new WaitForSeconds(2f);
        Wait();
    }

    private IEnumerator Kill()
    {
        if (death)
            yield break;
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
