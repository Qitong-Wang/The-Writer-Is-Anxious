using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFifth: GlobalManager
{
    public GameObject princess;
    public GameObject princessGun;

    public GameObject choiceA;
    public GameObject choiceB;
    public GameObject choiceC;

    public GameObject name;
    public GameObject dBox;
    public GameObject frames;

    public GameObject teamIcons;
    public List<int> Team;
    public List<HealthBar> TeamHealth;

    public GameObject forward;

    public int love;

    public GameObject firstZ;

    public List<string> choices;
    [TextArea]
    public List<string> replies;

    //random barks
    public bool random = false;
    public List<string> firstZombieClose;
    public List<string> firstZombieFar;
    private bool princessShotgun = false;

    [TextArea]
    public List<string> knightKill;
    [TextArea]
    public List<string> princessKill;

    private Animator cA;

    //beforecave
    public GameObject beforeCave;

    public List<string> beforeCaveNormal;
    public List<string> beforeCaveCombat;
    public List<string> beforeCaveLast;

    private Coroutine current;
    private bool killed;

    //incave
    public GameObject inCave;
    public GameObject leave;
    public List<string> inCaveText;

    //forest
    public GameObject forest;
    public GameObject zf1;
    public GameObject zf2;
    public List<string> forest1;
    public List<string> forest2;

    //barren
    public GameObject barren;
    public List<string> barren1;
    public List<string> barren2;
    public List<string> barren3;
    public List<string> barren4;
    public StopSign ss;
    public Animator zombiecrow;

    //city
    public GameObject city;
    public List<string> city1;
    public List<string> city2;
    public List<string> city3;
    public List<string> city4;
    public List<string> city5;
    public List<string> city6;
    public List<string> city7; //save none
    public QTE q1;
    public QTE q2;
    public GameObject giant;
    private bool finishedQTE = false;

    public GameObject Closetext;

    public bool death;
    // Start is called before the first frame update
    void Start()
    {
        sm.horror = true;
        love = sm.love; // read from sm

        StartCoroutine(FirstZombie());
        cA = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        Team = new List<int>(4);
        Team.Add(sm.hp); //knight's health
    }

    public override void StateCheck()
    {
        tm.textBoxes[1].gameObject.SetActive(false);
        princess.transform.GetChild(0).gameObject.SetActive(false);
        if (state == 1)
        {
            rayTap = false;
            waitingTap = false;
            tm.ClearText();
            random = false;
            StopAllCoroutines();
            firstZ.SetActive(false);
            dBox.SetActive(true);
            if (princessShotgun)
            {
                StartCoroutine(tm.ShowText(princessKill[0]));
                love -= 10;
            } else
            {
                StartCoroutine(tm.ShowText(knightKill[0]));
                love += 20;
            }
        } else if (state == 2)
        {
            frames.SetActive(true);
            name.SetActive(true);
            if (princessShotgun)
            {
                princessGun.SetActive(true);
                StartCoroutine(tm.ShowText(princessKill[1]));
            }
            else
            {
                princess.SetActive(true);
                StartCoroutine(tm.ShowText(knightKill[1]));
            }
        } else if (state == 3)
        {
            if (!princessShotgun)
            {
                sm.horrorWord1 = "They both panicked. In this emergency, the hero picked up his sword and slayed it. He saved the princess again.";
                sm.saveP++;
                SetChoice(0, choices[0], replies[0], 0);
                SetChoice(1, choices[1], replies[1], 0);
                SetChoice(2, choices[2], replies[2], 0);
            } else
            {
                sm.horrorWord1 = "They both panicked. In this emergency, the hero did not do anything. At last, it was the princess who shot the creature to death, and saved both of them.";
                SetChoice(0, choices[3], replies[3], 0);
                SetChoice(1, choices[4], replies[4], 0);
                SetChoice(2, choices[5], replies[5], 0);
            }
            
        }
        else if (state == 4)
        {
            princessGun.SetActive(false);
            princess.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 5)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 6)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 7)
        {
            SetChoice(0, choices[6], replies[6], 0);
            SetChoice(1, choices[7], replies[7], 10);
        }
        else if (state == 8)
        {
            name.SetActive(false);
            princess.SetActive(false);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 9)
        {
            name.SetActive(true);
            princess.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 10)
        {
            SetChoice(0, choices[8], replies[8], 0);
            SetChoice(1, choices[9], replies[9], 0);
        }
        else if (state == 11)
        {
            StartCoroutine(GoToCave());
            
        }
        else if (state == 12)
        {
            StartCoroutine(tm.ShowText("Princess: Crap! They're here!", 1, false));
            cA.SetTrigger("Next");
            StopCoroutine(current);
            forward.SetActive(false);
            current = StartCoroutine(RandomBarks(beforeCaveCombat));
            StartCoroutine(Zombie(firstZ));
        }
        else if (state == 13)
        {
            
            firstZ.SetActive(false);
            StopCoroutine(current);
            forward.SetActive(true);
            random = true;
            current = StartCoroutine(RandomBarks(beforeCaveLast));
        }
        else if (state == 14)
        {
            cA.SetTrigger("Next");
            forward.SetActive(true);
        } else if (state == 15)
        {
            cA.SetTrigger("Next");
            forward.SetActive(true);
        } else if (state == 16)
        {
            StartCoroutine(EnterCave());
        }
        else if (state == 17)
        {
            inCave.transform.GetChild(1).gameObject.SetActive(true);
            TapToContinue();
        }
        else if (state == 18)
        {
            inCave.transform.GetChild(2).gameObject.SetActive(false);
            inCave.transform.GetChild(3).gameObject.SetActive(true);
            TapToContinue();
        }
        else if (state == 19)
        {
            inCave.transform.GetChild(3).gameObject.SetActive(false);
            inCave.transform.GetChild(4).gameObject.SetActive(true);
            inCave.transform.GetChild(4).gameObject.tag = "current";
            TapToContinue(true);
        }
        else if (state == 20)
        {
            inCave.transform.GetChild(4).gameObject.SetActive(false);
            inCave.transform.GetChild(5).gameObject.SetActive(true);
            leave.SetActive(true);
            current = StartCoroutine(RollingBarks(inCaveText, 2));
            TapInspect();
        } else if (state == 21)
        {
            StartCoroutine(ExitCave());
        }
        else if (state == 22)
        {
            cA.SetTrigger("Next");
            forest.transform.GetChild(0).gameObject.SetActive(true);
            forward.SetActive(true);
        }
        else if (state == 23)
        {

            StopCoroutine(current);

            int jz = Random.Range(0, 2);
            if (jz == 0)
                StartCoroutine(tm.ShowText("Princess: They notice us!", 1, false));
            else if (jz == 1)
                StartCoroutine(tm.ShowText("Man: Let the show begin!", 1, false));
            else
                StartCoroutine(tm.ShowText("Cap Boy: Troubles.", 1, false));

            cA.SetTrigger("Next");
            
            
            forward.SetActive(false);
            StartCoroutine(Zombie(zf1, true));
        }
        else if (state == 24)
        {
            int jz = Random.Range(0, 2);
            if (jz == 0)
                StartCoroutine(tm.ShowText("Princess: Another one!", 1, false));
            else
                StartCoroutine(tm.ShowText("Cap Boy: Troubles.", 1, false));
            zf1.SetActive(false);
            StopCoroutine(current);
            StartCoroutine(Zombie(zf2, true));
        }
        else if (state == 25)
        {
            zf2.SetActive(false);
            forward.SetActive(true);
        }
        else if (state == 26)
        {
            cA.SetTrigger("Next");
            forest.transform.GetChild(1).gameObject.SetActive(true);
            current = StartCoroutine(RollingBarks(forest2));
            forward.SetActive(true);
        }
        else if (state == 27)
        {
            StartCoroutine(EnterBarrenland());

        }
        else if (state == 28)
        {
            cA.SetTrigger("Next");
            zombiecrow.SetTrigger("Zombie");
            StopCoroutine(current);
            current = StartCoroutine(RollingBarks(barren2));
            forward.SetActive(true);
        }
        else if (state == 29)
        {
            cA.SetTrigger("Next");
            StopCoroutine(current);
            ss.NextSprite();
            if (love > 50)
            {
                
                current = StartCoroutine(RollingBarks(barren3));
            }
            forward.SetActive(true);

        }
        else if (state == 30)
        {
            barren.transform.GetChild(0).gameObject.SetActive(true);
            ss.NextSprite();
            cA.SetTrigger("Next");
            StopCoroutine(current);
            current = StartCoroutine(RollingBarks(barren4));
            forward.SetActive(true);
        }
        else if (state == 31)
        {
            StartCoroutine(EnterCity());
        }
        else if (state == 32)
        {
            StartCoroutine(MeetGiant());
        }
        else if (state == 33)
        {
            giant.SetActive(false);
            StopCoroutine(current);
            current = StartCoroutine(RollingBarks(city6));
            forward.SetActive(true);
        }
        else if (state == 34)
        {
            cA.SetTrigger("Next");
            forward.SetActive(true);
        }
        else if (state == 35)
        {
            cA.SetTrigger("Next");
            forward.SetActive(true);
        }
        else if (state == 36)
        {
            StartCoroutine(CloseDoor());
        } else if (state == 37)
        {
            sm.hp = Team[0];
            sm.love = love;
            sound.Stop();
            SceneManager.LoadScene("SceneMystery");
        }
    }

    public void Leave()
    {
        leave.SetActive(false);
        StopCoroutine(current);
        state++;
        StateCheck();
    }

    public void GoForward()
    {
        forward.SetActive(false);
        state++;
        StateCheck();
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (rayInspect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.GetComponent<InteractableHorror>())
                {
                    hit.collider.gameObject.GetComponent<InteractableHorror>().Inspect();
                }
            }
            return;
        }
        if (rayTap)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.tag == "current")
                {
                    hit.collider.gameObject.tag = "Untagged";
                    killed = true;
                    rayTap = false;
                    state++;
                    StateCheck();
                    tm.ClearText();
                    if (random)
                    {
                        random = false;
                    }
                }
            }
            return;
        }
        if (!waitingTap)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            waitingTap = false;

            if (death)
            {
                StartCoroutine(DeathEnding());
                return;
            }
            state++;
            StateCheck();
        }
    }

    public void SetChoice(int i, string c, string r, int suki)
    {
        if (i == 0)
        {
            choiceA.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = c;
            choiceA.GetComponent<Button>().onClick.AddListener(delegate { Choose(r, suki); });
        } else if (i == 1)
        {
            choiceB.SetActive(true);
            choiceB.GetComponentInChildren<Text>().text = c;
            choiceB.GetComponent<Button>().onClick.AddListener(delegate { Choose(r, suki); });
        } else if (i == 2)
        {
            choiceC.SetActive(true);
            choiceC.GetComponentInChildren<Text>().text = c;
            choiceC.GetComponent<Button>().onClick.AddListener(delegate{ Choose(r, suki); });
        }
    }

    public void Choose(string r, int suki)
    {
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
        choiceA.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceB.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceC.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        StartCoroutine(tm.ShowText(r));
        love += suki;
        if (suki > 0)
        {
            princess.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    IEnumerator FirstZombie()
    {
        firstZ.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        random = true;
        Coroutine fzf = StartCoroutine(RandomBarks(firstZombieFar));
        yield return new WaitForSeconds(10f);
        if (state > 0)
        {
            yield break;
        }
        firstZ.GetComponent<Animator>().SetTrigger("Close");
        StopCoroutine(fzf);
        yield return new WaitForSeconds(1f);
        Coroutine fzc = StartCoroutine(RandomBarks(firstZombieClose));
        yield return new WaitForSeconds(10f);
        StopCoroutine(fzc);
        if (state > 0)
        {
            yield break;
        } else
        {
            princessShotgun = true;
            rayTap = false;
            state++;
            StateCheck();
            
        }
        //xiayige state
    }

    IEnumerator Zombie(GameObject z)
    {
        z.SetActive(true);
        z.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        killed = false;
        while (!killed)
        {
            yield return new WaitForSeconds(5f);
            if (killed)
            {
                break;
            } else
            {
                Team[Random.Range(0, Team.Count)]--;
                SetAllHealth();
            }
            
        }
    }

    IEnumerator Zombie(GameObject z, bool check)
    {
        
        z.SetActive(true);
        z.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        killed = false;
        while (!killed)
        {
            yield return new WaitForSeconds(5f);
            if (killed)
            {
                break;
            }
            else
            {
                int r = Random.Range(0, Team.Count);
                Team[r]--;
                if (r == 0)
                {
                    int rr = Random.Range(0, 1);
                    if (rr == 0)
                        StartCoroutine(tm.ShowText("Princess: You got bitten!", 1, false));
                    else
                        StartCoroutine(tm.ShowText("Man: Watch out!", 1, false));
                } else if (r == 1)
                    StartCoroutine(tm.ShowText("Princess: Uh!", 1, false));
                else if (r == 2)
                    StartCoroutine(tm.ShowText("Man: That bite is good.", 1, false));
                else if (r == 3)
                    StartCoroutine(tm.ShowText("Cap Boy: Mmm...!", 1, false));

                SetAllHealth();
            }

        }
    }

    public void SetAllHealth()
    {
        if (Team[0] < 5)
        {
            sm.noHurt = false;
        }
        if (Team[0] <= 0)
        {
            Death();
            return;
        }
        for (int i = 0; i < Team.Count; i++)
        {
            TeamHealth[i].SetHealth(Team[i]);
        }
    }

    public void Death()
    {
        rayTap = false;
        forward.SetActive(false);
        death = true;
        StopCoroutine(current);
        StartCoroutine(tm.ShowText("...You don't feel good. Your eyesight starts to blur...", 1));
    }

    IEnumerator DeathEnding()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        sm.horrorWord2 = "But the hero didn't survive.";
        SceneManager.LoadScene("SceneEnd");
    }

    IEnumerator RandomBarks(List<string> l)
    {
        tm.textBoxes[1].gameObject.SetActive(true);
        while (random)
        {
            tm.textBoxes[1].GetComponent<Text>().text = l[Random.Range(0, l.Count)];
            //StartCoroutine(tm.ShowText(l[Random.Range(0,l.Count)],1, false));
            yield return new WaitForSeconds(3f);
        }
        yield break;
    }

    IEnumerator RollingBarks(List<string> l, int box = 1)
    {
        tm.textBoxes[1].gameObject.SetActive(true);
        for (int i = 0; i < l.Count; i++)
        {
            tm.textBoxes[box].GetComponent<Text>().text = l[i];
            yield return new WaitForSeconds(3f);
        }
        StartCoroutine(tm.ShowText("", box, false));
    }

    IEnumerator GoToCave()
    {
        sound.Play(4);
        SetAllHealth();
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        princess.SetActive(false);
        dBox.SetActive(false);
        name.SetActive(false);
        frames.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        beforeCave.SetActive(true);
        teamIcons.SetActive(true);
        forward.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        random = true;
        current = StartCoroutine(RandomBarks(beforeCaveNormal));
    }

    IEnumerator EnterCave()
    {
        random = false;
        tm.ClearAllText();

        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        cA.SetTrigger("Back");
        beforeCave.SetActive(false);
        forward.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        inCave.SetActive(true);
        fadeBlack.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        inCave.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
    }

    IEnumerator ExitCave()
    {
        rayInspect = false;
        tm.ClearAllText();
        tm.textBoxes[2].SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        inCave.SetActive(false);
        leave.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        forest.SetActive(true);
        Team.Add(5);
        Team.Add(5);
        Team.Add(5);
        teamIcons.transform.GetChild(2).gameObject.SetActive(true);
        teamIcons.transform.GetChild(3).gameObject.SetActive(true);
        forward.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        current = StartCoroutine(RollingBarks(forest1));
    }

    IEnumerator EnterBarrenland()
    {
        StopCoroutine(current);
        tm.ClearAllText();
        forward.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        forest.SetActive(false);
        cA.SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
        barren.SetActive(true);
        forward.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        current = StartCoroutine(RollingBarks(barren1));
    }

    IEnumerator EnterCity()
    {
        StopCoroutine(current);
        tm.ClearAllText();
        forward.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        barren.SetActive(false);
        cA.SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
        city.SetActive(true);
        forward.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        current = StartCoroutine(RollingBarks(city1));
    }

    IEnumerator MeetGiant()
    {
        StopCoroutine(current);
        cA.SetTrigger("Next");
        yield return new WaitForSeconds(0.5f);
        current = StartCoroutine(RollingBarks(city2));
        forward.SetActive(false);
        giant.SetActive(true);
        yield return new WaitForSeconds(2f);
        city.transform.GetChild(1).gameObject.SetActive(true);
        city.transform.GetChild(2).gameObject.SetActive(true);
        q1.transform.parent.gameObject.SetActive(true);
        q2.transform.parent.gameObject.SetActive(true);
    }

    public void SaveQTE(int i)
    {
        if (finishedQTE)
        {
            return;
        }
        if (i == 0)
        {
            StartCoroutine(SavePrincess());
        } else if (i == 1)
        {
            StartCoroutine(SaveBoy());
        } else
        {
            StartCoroutine(SaveNone());
        }
        finishedQTE = true;
    }

    IEnumerator SavePrincess()
    {
        sm.saveQTE = "princess";
        sm.horrorWord2 = "When they nearly arrived, the hero saved the princess from the attack of a huge zombie. And they all survived and made it to the safe house.";
        sm.saveP++;
        q1.start = false;
        q2.start = false;
        q1.transform.parent.gameObject.SetActive(false);
        q2.transform.parent.gameObject.SetActive(false);
        city.transform.GetChild(1).gameObject.SetActive(false);
        city.transform.GetChild(2).gameObject.SetActive(false);
        StopCoroutine(current);
        current = StartCoroutine(RollingBarks(city4));
        Team[3] = 0;
        SetAllHealth();
        yield return new WaitForSeconds(7f);
        love += 20;
        giant.GetComponent<Animator>().SetTrigger("Far");
        yield return new WaitForSeconds(2f);
        giant.GetComponent<GiantZombie>().start = true;
        giant.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        
        yield return new WaitForSeconds(9f);
        StartCoroutine(GiantZombie());
        if (killed)
        {
            yield break;
        }
        StopCoroutine(current);
        random = true;
        current = StartCoroutine(RandomBarks(city5));
    }

    IEnumerator SaveBoy()
    {
        sm.saveQTE = "boy";
        sm.horrorWord2 = "When they nearly arrived, the hero saved the boy from the attack of a huge zombie, instead of the princess. And they all survived and made it to the safe house.";
        q1.start = false;
        q2.start = false;
        q1.transform.parent.gameObject.SetActive(false);
        q2.transform.parent.gameObject.SetActive(false);
        city.transform.GetChild(1).gameObject.SetActive(false);
        city.transform.GetChild(2).gameObject.SetActive(false);
        StopCoroutine(current);
        current = StartCoroutine(RollingBarks(city3));
        Team[1] = 0;
        SetAllHealth();
        yield return new WaitForSeconds(7f);
        love -= 20;
        giant.GetComponent<Animator>().SetTrigger("Far");
        yield return new WaitForSeconds(2f);
        giant.GetComponent<GiantZombie>().start = true;
        giant.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        
        yield return new WaitForSeconds(9f);

        StartCoroutine(GiantZombie());
        if (killed)
        {
            yield break;
        }
        StopCoroutine(current);
        random = true;
        current = StartCoroutine(RandomBarks(city5));
    }

    IEnumerator SaveNone()
    {
        sm.saveQTE = "none";
        sm.horrorWord2 = "When they nearly arrived, the hero saved no one from the attack of a huge zombie when he could have. Luckily, they all survived and made it to the safe house.";
        q1.start = false;
        q2.start = false;
        q1.transform.parent.gameObject.SetActive(false);
        q2.transform.parent.gameObject.SetActive(false);
        city.transform.GetChild(1).gameObject.SetActive(false);
        city.transform.GetChild(2).gameObject.SetActive(false);
        StopCoroutine(current);
        current = StartCoroutine(RollingBarks(city7));
        Team[1] = 0;
        Team[3] = 0;
        SetAllHealth();
        yield return new WaitForSeconds(7f);
        love -= 20;
        giant.GetComponent<Animator>().SetTrigger("Far");
        yield return new WaitForSeconds(2f);
        giant.GetComponent<GiantZombie>().start = true;
        giant.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
        
        yield return new WaitForSeconds(9f);

        StartCoroutine(GiantZombie());
        if (killed)
        {
            yield break;
        }
        StopCoroutine(current);
        random = true;
        current = StartCoroutine(RandomBarks(city5));
    }

    IEnumerator GiantZombie()
    {
        killed = false;
        while (!killed)
        {
            yield return new WaitForSeconds(5f);
            if (killed)
            {
                break;
            }
            else
            {
                int r = Random.Range(0, Team.Count);
                Team[r]--;
                
                SetAllHealth();
            }

        }
    }

    IEnumerator CloseDoor()
    {
        StopCoroutine(current);
        yield return new WaitForSeconds(0.5f);
        tm.ClearAllText();
        forward.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        city.SetActive(false);
        teamIcons.SetActive(false);
        cA.SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
        Closetext.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(0.5f);
        Closetext.tag = "current";
        TapToContinue(true);
    }
}
