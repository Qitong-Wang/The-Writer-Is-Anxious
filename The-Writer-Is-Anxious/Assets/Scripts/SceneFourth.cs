using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFourth : GlobalManager
{
    public GameObject princess;

    public GameObject choiceA;
    public GameObject choiceB;
    public GameObject choiceC;

    public GameObject CG;

    public GameObject name;

    public int love;

    [TextArea]
    public List<string> choices;
    [TextArea]
    public List<string> replies;

    public GameObject hearts;
    // Start is called before the first frame update
    void Start()
    {
        sm.romance = true;
        love = 30;
        sound.Play(3);
        StartCoroutine(tm.ShowText());
    }

    public override void StateCheck()
    {
        princess.transform.GetChild(0).gameObject.SetActive(false);
        hearts.SetActive(false);
        if (state == 1)
        {
            SetChoice(0, choices[0], replies[0], 0);
            SetChoice(1, choices[1], replies[1], 10);
            SetChoice(2, choices[2], replies[2], 0);
        } else if (state == 2)
        {
            StartCoroutine(tm.ShowText());
        } else if (state == 3)
        {
            SetChoice(0, choices[3], replies[3], 0);
            SetChoice(1, choices[4], replies[4], -20);
            SetChoice(2, choices[5], replies[5], 20);
        }
        else if (state == 4)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 5)
        {
            SetChoice(0, choices[6], replies[6], 0);
            SetChoice(1, choices[7], replies[7], 0);
            SetChoice(2, choices[8], replies[8], 0);
        }
        else if (state == 6)
        {
            name.GetComponentInChildren<Text>().text = "Knight";
            StartCoroutine(tm.ShowText());
            princess.SetActive(false);
            CG.SetActive(true);
        }
        else if (state == 7)
        {
            name.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 8)
        {
            name.SetActive(false);
            CG.SetActive(false);
            StartCoroutine(tm.ShowText());
        }
        else if (state == 9)
        {
            StartCoroutine(tm.ShowText());
        }
        else if (state == 10)
        {
            name.SetActive(true);
            princess.SetActive(true);
            name.GetComponentInChildren<Text>().text = "Princess";
            StartCoroutine(tm.ShowText());
        }
        else if (state == 11)
        {
            if (love == 60)
            {
                sm.romanceWord = "The hero saved her life. He was handsome, polite, and most importantly -- he knew what she was talking about. The princess quickly fell in love with the hero. They hugged each other. Both of them were thinking, I hope my life could stay at this moment.";
            } else if (love>=30 && love < 60)
            {
                sm.romanceWord = "The hero saved her life. They had a great talk, but it seemed like neither of them were actually paying attention to their conversation. But at least the hug was warm and touching.";
            } else
            {
                sm.romanceWord = "The hero saved her life. She was appreciative, but she still felt that what he said was... lacking something. Does this person care about me? She couldn't help but think. But his hug was strong and warm, which made the princess relax a little.";
            }
            sm.love = love;
            sound.Stop();
            SceneManager.LoadScene("SceneHorror");
        }
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
                if (hit.collider && hit.collider.gameObject.GetComponent<Interactable>())
                {
                    Inspect(hit.collider.gameObject.GetComponent<Interactable>());
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
            waitingTap = false;

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
            hearts.SetActive(true);
        }
    }
}
