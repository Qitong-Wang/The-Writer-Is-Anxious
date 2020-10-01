using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class StateEvidence
{
    [TextArea]
    public string intro;
    public bool fail;
    public string special;
}

public class SceneSixth : GlobalManager
{

    public GameObject things;
    public GameObject things2;

    public GameObject princess;
    public GameObject man;
    public GameObject capboy;

    public int love;
    public int hp;

    //romance dialogue
    public GameObject nameR;
    public GameObject diaR;
    public GameObject choiceA;
    public GameObject choiceB;
    public GameObject choiceC;
    public GameObject frames;

    //mystery dialogue
    public GameObject nameM;
    public GameObject diaMname;
    public GameObject diaM;

    public List<string> choices;
    [TextArea]
    public List<string> replies1;
    [TextArea]
    public List<string> replies2;
    [TextArea]
    public List<string> replies3;
    [TextArea]
    public List<string> replies4;
    private List<string> chosen;
    private int index = 0;
    private bool onChoice = false;

    public GameObject smoke;
    public GameObject bang;
    public GameObject eye;

    [TextArea]
    public List<string> death;

    public GameObject CG;

    //evidence
    public bool gunfire = false;
    [TextArea]
    public List<string> gunfireT;
    public bool news = false;
    [TextArea]
    public string newsT;
    public bool cboy = false;
    [TextArea]
    public string cboyT;
    public bool blood = false;
    [TextArea]
    public string bloodT;
    public bool immunity = false;
    [TextArea]
    public string immunityT;

    //CROSS
    public GameObject sideBar;
    public GameObject diaCE;
    public GameObject evidencePanel;
    
    public int stateInt;
    [TextArea]
    public List<string> statements;

    public GameObject next;
    public GameObject wait;

    public List<StateEvidence> state1;
    public List<StateEvidence> state2;
    public List<StateEvidence> state3;
    public List<StateEvidence> state4;
    public List<StateEvidence> state3new;
    public List<StateEvidence> state4new;
    public List<StateEvidence> state4new2;
    public List<StateEvidence> state5;

    [TextArea]
    public List<string> toState3new;
    [TextArea]
    public List<string> toState4new;
    [TextArea]
    public List<string> toState4new2;
    [TextArea]
    public List<string> toState5;
    [TextArea]
    public List<string> win;

    public int beforestate5 = 0;
    public bool finalround;

    private Coroutine current;
    [TextArea]
    public List<string> mysDeath;
    public bool mysDie;
    // Start is called before the first frame update
    void Start()
    {
        sm.mystery = true;
        love = sm.love; // load
        hp = sm.hp; //load
        StartCoroutine(SceneStart());
    }

    public override void StateCheck()
    {
        if (state == 1)
        {
            StartCoroutine(tm.ShowText());
        } else if (state == 2)
        {
            nameM.GetComponentInChildren<Text>().text = "Cap Boy";
            princess.SetActive(false);
            capboy.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 3)
        {
            nameM.GetComponentInChildren<Text>().text = "Man";
            capboy.SetActive(false);
            man.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 4)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 5)
        {
            nameM.GetComponentInChildren<Text>().text = "Cap Boy";
            man.SetActive(false);
            capboy.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 6)
        {
            nameM.GetComponentInChildren<Text>().text = "Man";
            capboy.SetActive(false);
            man.SetActive(true);
            man.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 7)
        {
            nameM.GetComponentInChildren<Text>().text = "Cap Boy";
            man.SetActive(false);
            man.transform.GetChild(0).gameObject.SetActive(false);
            capboy.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 8)
        {
            nameM.GetComponentInChildren<Text>().text = "Princess";
            capboy.SetActive(false);
            princess.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 9)
        {
            nameM.SetActive(false);
            diaMname.SetActive(false);
            nameR.SetActive(true);
            diaR.SetActive(true);
            frames.SetActive(true);
            things.SetActive(false);
            nameR.GetComponentInChildren<Text>().text = "Princess";
            princess.SetActive(true);
            StartCoroutine(tm.ShowText(2));
        }
        else if (state == 10)
        {
            SetChoice(0, choices[0], replies1, 10);
            SetChoice(1, choices[1], replies2, 0);
            SetChoice(2, choices[2], replies3, 0);
        }
        else if (state == 11)
        {
            nameR.SetActive(false);
            diaR.SetActive(false);
            frames.SetActive(false);
            princess.SetActive(false);
            StartCoroutine(Smokes());
        }
        else if (state == 12)
        {
            nameM.SetActive(false);
            diaMname.SetActive(false);
            
            StartCoroutine(Bang());
        }
        else if (state == 13)
        {
            
            if (love < 50)
            {
                StartCoroutine(Shot2());
            } else
            {
                StartCoroutine(NoneShot2());
            }
        }
        else if (state== 14)
        {
            if (love < 50)
            {
                sm.mysteryWord1 = "Suddenly, the room is filled with smoke. When the hero was trying to find others, he heard a shot. And then he was struggled in pain. He didn't know who killed him, and he never had the chance to figure it out.";
                SceneManager.LoadScene("SceneEnd");
            } else
            {
                sm.mysteryWord1 = "Suddenly, the room is filled with smoke. When the hero was trying to find others, he heard a shot. When the smoke is gone, they found the cap boy dead. The princess said he was attacked by the zombies.";
                nameM.SetActive(false);
                diaMname.SetActive(false);
                StartCoroutine(SmokeGone());
                sound.Play(5);
            }
        }
        else if (state == 15)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 16)
        {
            man.SetActive(false);
            princess.SetActive(true);
            princess.transform.GetChild(0).gameObject.SetActive(true);
            nameM.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 17)
        {
            nameM.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 18)
        {
            nameM.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 19)
        {
            nameM.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 20)
        {
            nameM.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 21)
        {
            nameM.GetComponentInChildren<Text>().text = "Princess";
            princess.transform.GetChild(0).gameObject.SetActive(false);
            princess.transform.GetChild(3).gameObject.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 22)
        {
            man.SetActive(true);
            princess.SetActive(false);
            nameM.GetComponentInChildren<Text>().text = "Man";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 23)
        {
            man.SetActive(false);

            nameM.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 24)
        {
            
            StartCoroutine(BoyZombie());
        }
        else if (state == 25)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 26)
        {

            StartCoroutine(Explanation());
        }
        else if (state == 27)
        {
            man.SetActive(true);
            princess.SetActive(false);
            nameM.GetComponentInChildren<Text>().text = "Man";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 28)
        {
            man.SetActive(false);
            princess.SetActive(true);
            nameM.GetComponentInChildren<Text>().text = "Princess";
            princess.transform.GetChild(3).gameObject.SetActive(false);
            princess.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 29)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 30)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 31)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 32)
        {
            nameM.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 33)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 34)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 35)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 36)
        {
            rayInspect = true;
            nameM.SetActive(false);
            diaMname.SetActive(false);
            princess.SetActive(false);
            things.transform.GetChild(0).gameObject.SetActive(true);
            things.transform.GetChild(1).gameObject.SetActive(true);
            GetEvidence(0);
            
        }
        else if (state == 37)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 38)
        {
            StartCoroutine(StartCE());
        }
        else if (state == 40)
        {
            StartCoroutine(Win());
        }
        else if (state == 41)
        {
            man.SetActive(false);
            princess.SetActive(true);
            nameM.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 42)
        {
            man.SetActive(true);
            princess.SetActive(false);
            nameM.GetComponentInChildren<Text>().text = "Man";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 43)
        {
            man.SetActive(false);
            princess.SetActive(true);
            nameM.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 44)
        {
            rayInspect = true;
            nameM.SetActive(false);
            diaMname.SetActive(false);
            princess.SetActive(false);
            things2.transform.GetChild(0).gameObject.SetActive(true);
            things2.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void GetEvidence(int i)
    {
        rayInspect = false;
        diaM.SetActive(true);
        if (i == 0)
        {
            gunfire = true;
            StartCoroutine(tm.ShowText(gunfireT[0], 1));
        }

    }

    public override void Update()
    {
        if (rayInspect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.GetComponent<InteractableMystery>())
                {
                    hit.collider.gameObject.GetComponent<InteractableMystery>().Inspect();
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
                    rayTap = false;
                    state++;
                    StateCheck();
                    tm.ClearText();


                }
            }
            return;
        }
        if (!waitingTap)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            //print("tya");
            waitingTap = false;

            if (onChoice)
            {
                BeforeKill();
                return;
            }
            if (state == 36 || state == 44)
            {
                rayInspect = true;
                tm.ClearText();
                diaM.SetActive(false);
                diaMname.SetActive(false);
                nameM.SetActive(false);
                return;
            }

            if (state == 38)
            {
                if (mysDie)
                {
                    return;
                }
                Replay();
                return;
            }
                
            state++;
            StateCheck();
            tm.ClearText();
            
        }
    }

    public void SetChoice(int i, string c, List<string> r, int suki)
    {
        if (i == 0)
        {
            choiceA.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = c;
            choiceA.GetComponent<Button>().onClick.AddListener(delegate { Choose(r, suki); });
        }
        else if (i == 1)
        {
            choiceB.SetActive(true);
            choiceB.GetComponentInChildren<Text>().text = c;
            choiceB.GetComponent<Button>().onClick.AddListener(delegate { Choose(r, suki); });
        }
        else if (i == 2)
        {
            choiceC.SetActive(true);
            choiceC.GetComponentInChildren<Text>().text = c;
            choiceC.GetComponent<Button>().onClick.AddListener(delegate { Choose(r, suki); });
        }
    }

    public void SetChoice(int i, bool choose)
    {
        if (i == 0)
        {
            choiceA.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = "Yes";
            choiceA.GetComponent<Button>().onClick.AddListener(delegate { Choose(choose); });
        }
        else if (i == 1)
        {
            choiceB.SetActive(true);
            choiceB.GetComponentInChildren<Text>().text = "No";
            choiceB.GetComponent<Button>().onClick.AddListener(delegate { Choose(choose); });
        }

    }

    public void SetChoiceCE(int i, bool ask = false)
    {
        if (i == 0)
        {
            choiceA.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = "Ask";
            choiceA.GetComponent<Button>().onClick.AddListener(delegate { Ask(ask); });
        }
        else if (i == 1)
        {
            choiceB.SetActive(true);
            choiceB.GetComponentInChildren<Text>().text = "Object";
            choiceB.GetComponent<Button>().onClick.AddListener(delegate { ChooseObject(); });
        }

    }

    public void Ask(bool b = false)
    {
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
        choiceA.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceB.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceC.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        if (finalround)
        {
            StopCoroutine(current);
            current = StartCoroutine(tm.ShowText(state5[0].intro, 3));
            return;
        }
        StopCoroutine(current);
        if (stateInt == 1)
            current = StartCoroutine(tm.ShowText(state1[0].intro, 3));
        else if (stateInt == 2)
            current = StartCoroutine(tm.ShowText(state2[0].intro, 3));
        else if (stateInt == 3)
            current = StartCoroutine(tm.ShowText(state3[0].intro, 3));
        else if (stateInt == 4)
        {
            if (state4[0].special == "state4new")
            {
                current = StartCoroutine(tm.ShowText(toState4new, 3, new List<string>(new string[] { "Princess", "Knight", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "state4new"));
                statements[3] = statements[6];
                state4 = state4new;
                return;
            }
            current = StartCoroutine(tm.ShowText(state4[0].intro, 3));
        }
            
    }


    public void Object(int i)
    {
        sideBar.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
        if (finalround)
        {
            if (state5[i].special == "win")
            {
                StopCoroutine(current);
                current = StartCoroutine(tm.ShowText(win, 3, new List<string>(new string[] { "Princess", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "win"));
                return;
            } else
            {
                StopCoroutine(current);
                current = StartCoroutine(tm.ShowText(state5[i].intro, 3));
                if (state5[i].fail)
                {
                    DecreaseHP();
                }
                return;
            }
            
        }
        StopCoroutine(current);
        if (stateInt == 1)
        {
            
            current = StartCoroutine(tm.ShowText(state1[i].intro, 3));
            if (state1[i].fail)
            {
                DecreaseHP();
            }
        }
        else if (stateInt == 2)
        {
            current = StartCoroutine(tm.ShowText(state2[i].intro, 3));
            if (state2[i].fail)
            {
                DecreaseHP();
            }
        }
        else if (stateInt == 3)
        {
            if (state3[i].special == "state3new")
            {
                current = StartCoroutine(tm.ShowText(toState3new, 3, new List<string>(new string[] {"Knight", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "state3new"));
                
                beforestate5++;
                return;
            }

            if (state3[i].special == "state5" && beforestate5 >= 2)
            {
                current = StartCoroutine(tm.ShowText(toState5, 3, new List<string>(new string[] { "Knight", "Man", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "state5"));
                
                return;
            }
            current = StartCoroutine(tm.ShowText(state3[i].intro, 3));
            if (state3[i].fail)
            {
                DecreaseHP();
            }

        }
        else if (stateInt == 4)
        {
            if (state4[i].special == "state4new2")
            {
                current = StartCoroutine(tm.ShowText(toState4new2, 3, new List<string>(new string[] { "Knight", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(),"state4new2"));
                
                beforestate5++;
                return;
            }

            if (state4[i].special == "state5" && beforestate5 >= 2)
            {
                current = StartCoroutine(tm.ShowText(toState5, 3, new List<string>(new string[] { "Knight", "Man", "Princess" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "state5"));
                
                return;
            }
            current = StartCoroutine(tm.ShowText(state4[i].intro, 3));
            if (state4[i].fail)
            {
                DecreaseHP();
            }

        }
    }

    public void ChooseObject()
    {
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
        choiceA.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceB.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceC.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

        if (gunfire)
        {
            sideBar.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
            sideBar.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(delegate { Object(1); });
        }
        if (news)
        {
            sideBar.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            sideBar.transform.GetChild(3).GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(delegate { Object(2); });
        }
        if (cboy)
        {
            sideBar.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
            sideBar.transform.GetChild(3).GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(delegate { Object(3); });
        }
        if (blood)
        {
            sideBar.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
            sideBar.transform.GetChild(3).GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(delegate { Object(4); });
        }
        if (immunity)
        {
            sideBar.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
            sideBar.transform.GetChild(3).GetChild(4).gameObject.GetComponent<Button>().onClick.AddListener(delegate { Object(5); });
        }
        
    }

    public void Choose(bool choose)
    {
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
        choiceA.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceB.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceC.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        if (choose)
        {
            StartCoroutine(EnterCross());
        } else
        {
            rayInspect = true;
        }
        diaM.SetActive(false);
    }

    public void Choose(List<string> r, int suki)
    {
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
        choiceA.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceB.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        choiceC.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        chosen = r;
        
        love += suki;
        if (suki > 0)
        {
            chosen = replies4;
            if (love < 50)
            {
                sm.tragedy = true;
            }
            //princess.transform.GetChild(0).gameObject.SetActive(true);
            //hearts.SetActive(true);
        }
        onChoice = true;
        BeforeKill();
    }
    private void BeforeKill()
    {
        StartCoroutine(tm.ShowText(chosen[index], 2));
        index++;
        if (index >= chosen.Count)
        {
            onChoice = false;
        }
    }
    IEnumerator SceneStart()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        things.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        nameM.SetActive(true);
        diaMname.SetActive(true);
        princess.SetActive(true);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Smokes()
    {
        smoke.SetActive(true);
        smoke.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        smoke.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        smoke.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Man";
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Bang()
    {
        yield return new WaitForSeconds(1f);
        bang.SetActive(true);
        yield return new WaitForSeconds(1f);
        bang.SetActive(false);
        if (love < 50)
        {
            StartCoroutine(Shot());
        } else
        {
            StartCoroutine(NoneShot());
        }
    }

    IEnumerator Shot()
    {
        GameObject.Find("Red").GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Knight";
        StartCoroutine(tm.ShowText(death[0]));
    }

    IEnumerator NoneShot()
    {
        yield return new WaitForSeconds(1f);
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Knight";
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Shot2()
    {
        
        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);

        StartCoroutine(tm.ShowText(death[1]));
    }

    IEnumerator NoneShot2()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(tm.ShowText());
    }

    IEnumerator SmokeGone()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        smoke.SetActive(false);
        things.SetActive(true);

        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Man";
        man.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(tm.ShowText());
    }

    IEnumerator BoyZombie()
    {
        diaMname.SetActive(false);
        nameM.SetActive(false);
        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        things.SetActive(false);
        CG.SetActive(true);
        fadeBlack.GetComponent<Animator>().SetTrigger("Out");
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Man";
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Explanation()
    {
        diaMname.SetActive(false);
        nameM.SetActive(false);
        fadeBlack.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        things.SetActive(true);
        CG.SetActive(false);
        fadeBlack.GetComponent<Animator>().SetTrigger("Out");
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Princess";
        princess.transform.GetChild(3).gameObject.SetActive(true);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator EnterCross()
    {
        rayInspect = false;
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        things.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        princess.SetActive(true);
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Knight";
        state++;
        StateCheck();
    }

    IEnumerator StartCE()
    {
        diaMname.SetActive(false);
        nameM.SetActive(false);
        yield return new WaitForSeconds(1f);
        //startcross
        SetAllHealth();
        sideBar.SetActive(true);
        diaCE.SetActive(true);
        stateInt = 0;
        current = StartCoroutine(tm.ShowText(statements[stateInt], 3, false));
        stateInt++;
    }

    public void Next()
    {
        diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>().text = "Princess";
        StopCoroutine(current);
        if (finalround)
        {

            current = StartCoroutine(tm.ShowText(statements[stateInt], 3, false));
            next.SetActive(true);
            wait.SetActive(true);
            if (stateInt == 8)
                stateInt = 4;
            else if (stateInt == 4)
            {
                wait.SetActive(false);
                DecreaseHP();
                stateInt = 8;
            }
                
            return;
        }
        if (stateInt == 5)
        {
            stateInt = 0;
        }
        current = StartCoroutine(tm.ShowText(statements[stateInt], 3, false));
        next.SetActive(true);
        wait.SetActive(true);
        if (stateInt == 4)
        {
            DecreaseHP();
            wait.SetActive(false);
        }
        stateInt++;
    }
    
    public void Replay()
    {
        diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>().text = "Princess";
        StopCoroutine(current);
        sideBar.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        sideBar.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
        if (finalround)
        {
            current = StartCoroutine(tm.ShowText(statements[8], 3, false));
            next.SetActive(true);
            wait.SetActive(true);
            return;
        }
        current = StartCoroutine(tm.ShowText(statements[stateInt-1], 3, false));
        next.SetActive(true);
        wait.SetActive(true);
    }

    public void Wait()
    {
        SetChoiceCE(0);
        SetChoiceCE(1);
        next.SetActive(false);
        wait.SetActive(false);
    }

    public void DecreaseHP()
    {
        sm.noHurt = false;
        hp--;
        SetAllHealth();
    }

    public void SetAllHealth()
    {
        GameObject hps = sideBar.transform.GetChild(2).gameObject;
        if (hp == 4)
        {
            hps.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (hp == 3)
        {
            hps.transform.GetChild(0).gameObject.SetActive(false);
            hps.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (hp == 2)
        {
            hps.transform.GetChild(0).gameObject.SetActive(false);
            hps.transform.GetChild(1).gameObject.SetActive(false);
            hps.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (hp == 1)
        {
            hps.transform.GetChild(0).gameObject.SetActive(false);
            hps.transform.GetChild(1).gameObject.SetActive(false);
            hps.transform.GetChild(2).gameObject.SetActive(false);
            hps.transform.GetChild(3).gameObject.SetActive(false);
        }
        else if (hp <= 0)
        {
            sideBar.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            sideBar.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            sideBar.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
            sideBar.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
            sideBar.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
            next.SetActive(false);
            wait.SetActive(false);
            mysDie = true;
            evidencePanel.SetActive(false);
            current = StartCoroutine(tm.ShowText(mysDeath, 3, new List<string>(new string[] { "Man", "Knight", "Knight" }), diaCE.transform.GetChild(4).gameObject.GetComponentInChildren<Text>(), "death"));
        }
    }

    public IEnumerator Die()
    {
        sm.mysteryWord2 = "But no one trusted the hero in the end. Not even himself. The princess was not willing to speak one more word to him. They were forever trapped in this safe house...";
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SceneEnd");
    }

    public void OpenEvidence()
    {
        evidencePanel.SetActive(true);
        if (gunfire)
        {
            evidencePanel.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        if (news)
        {
            evidencePanel.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
        if (cboy)
        {
            evidencePanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }
        if (blood)
        {
            evidencePanel.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        }
        if (immunity)
        {
            evidencePanel.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
        }
    }

    public void CloseEvidence()
    {
        evidencePanel.SetActive(false);
    }

    public void ShowEvidence(int i)
    {
        FindObjectOfType<EvidencePanel>().state = i;
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        sideBar.SetActive(false);
        diaCE.SetActive(false);
        
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        princess.SetActive(false);
        things2.SetActive(true);
        man.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        diaMname.SetActive(true);
        nameM.SetActive(true);
        nameM.GetComponentInChildren<Text>().text = "Man";
        StartCoroutine(tm.ShowText());
    }

    public void NextScene()
    {
        sm.mysteryWord2 = "In the cross-examination, the princess finally told the truth. It was her who killed the boy. But she didn't say the reason - she just wants the hero to open the door. But what's next? Where is the end of this? Nobody knows the answer...";
        SceneManager.LoadScene("SceneEnd");
    }
}
