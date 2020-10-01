using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneEnd : GlobalManager
{
    public GameObject twa;
    public GameObject i;

    public GameObject table;
    public GameObject lamp;

    public GameObject need;

    public GameObject ring;

    public GameObject arm;
    public GameObject line;
    public GameObject editor;
    public GameObject editorBox;

    public GameObject spotlight;
    public GameObject isad;
    public GameObject notebookS;

    public List<GameObject> noteS;

    public GameObject stare1;
    public GameObject stare2;

    public GameObject trashcan;
    public GameObject myRoom;

    public GameObject bookShelf;
    public GameObject adventure;
    public GameObject romance;
    public GameObject horror;
    public GameObject mystery;


    public GameObject scrollbar;
    public GameObject likeit;
    public GameObject hateit;

    private bool rayBook;
    public int bookChosen;

    public GameObject endingPanel;
    public GameObject collections;
    // Start is called before the first frame update
    void Start()
    {
        sound.Stop();
        StartCoroutine(SceneStart());
    }


    public override void StateCheck()
    {
        if (state == 0)
        {
            print("no way");
        }
        else if (state == 1)
        {
            StartCoroutine(Wrote());
        } else if (state == 2)
        {
            StartCoroutine(ShowWork());
        }
        else if (state == 20)
        {
            StartCoroutine(Throw());
        }
        else if (state == 21)
        {
            StartCoroutine(Normal());
        }
        else if (state == 22)
        {
            StartCoroutine(InspectRoom());
        }
        else if (state == 23)
        {
            StartCoroutine(BookShelf());
        }
        else if (state == 24)
        {
            StartCoroutine(BookChoose());
        }
        else if (state == 25)
        {
            StartCoroutine(OpenBook());
        }
        else if (state == 26)
        {
            StartCoroutine(Transport());
        }
    }

    public override void Update()
    {
        if (rayBook)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.GetComponent<Books>())
                {
                    hit.collider.gameObject.GetComponent<Books>().ChooseBook();
                }
            }
            return;
        }
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
            //print("tya");
            waitingTap = false;
            state++;
            StateCheck();
            tm.ClearText();
        }
    }

    IEnumerator SceneStart()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        i.SetActive(true);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Wrote()
    {
        i.SetActive(false);
        stare2.SetActive(true);
        line.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(1f);
        notebookS.SetActive(true);
        noteS[0].SetActive(true);
        TapToContinue();
    }

    IEnumerator ShowWork()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        scrollbar.SetActive(true);

        string article;
        article = "Once upon a time, there was a hero." + "\n" +
            sm.fantasy + "\n";
        if (sm.milk != "")
        {
            article += sm.milk + "\n";
        }
        if (sm.adventure)
        {
            article += "\n" + "The hero reached a town. He knew from the people there that the princess was taken by the dragon. So he took the order and went out to find the dragon." + "\n" + sm.adventureWord + "\n";
        }
        if (sm.dragonWord!= "")
        {
            article += sm.dragonWord + "\n";
        }
        if (sm.romance)
        {
            article += "\n" + sm.romanceWord + "\n" + "\n" + "Out of the blue, an explosion attracted their attention. It was from the town. Both of them were worried. But in the second instance, a zombie popped out, and stopped their way." + "\n";
        }
        if (sm.horror)
        {
            article += sm.horrorWord1 + "\n" + "They decided to go to the dragon's cave, where they met a man and a boy. After a discussion, they grouped together and started their adventure towards the safe house." + "\n";
        }
        if (sm.horrorWord2 != "")
        {
            article += sm.horrorWord2 + "\n";
        }
        if (sm.mystery)
        {
            article += "\n" + "Different from the cave, the safe house had more suppliers. " + sm.mysteryWord1 + "\n";
        }
        if (sm.mysteryWord2 != "")
        {
            article += "The man did not believe her. Neither did the hero. So the hero started to investigate around and tried to figure out the truth." + "\n" + sm.mysteryWord2 + "\n";
        }
        article += "\n" + "The end.";

        scrollbar.GetComponentInChildren<Text>().text = article;
        scrollbar.GetComponentInChildren<Text>().gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1514.3f, scrollbar.GetComponentInChildren<Text>().preferredHeight);

        likeit.SetActive(true);
        hateit.SetActive(true);
    }

    public void CalculateEnding()
    {
        scrollbar.SetActive(false);
        likeit.SetActive(false);
        hateit.SetActive(false);
        endingPanel.SetActive(true);

        //calculate score
        int score = 0;
        if (!sm.adventure)
            score -= 50; // die first
        if (sm.hp <= 0)
            score -= 50;
        if (sm.coin > 0)
            score += 10;
        if (sm.catRoom == "milk")
            score += 50;
        if (sm.catRoom == "rotten")
            score -= 50;
        if (sm.milk != "")
            score -= 20;
        if (sm.romance)
            score += 50; //fight dragon
        if (sm.saveQTE == "none")
            score -= 70;
        if (sm.mysteryWord2 != "")
            score += 50;
        if (sm.mysteryWord2 != "" && sm.hp > 0)
        {
            score += 300; // finish
            sm.b1 = true;
        }
        if (sm.tragedy)
        {
            score += 200;
            sm.b2 = true;
        }
        if (sm.saveP >= 3)
        {
            score += 50;
            sm.b3 = true;
        }
        if (sm.noHurt)
        {
            score += 100;
            sm.b4 = true;
        }
            
        score += sm.love;
        score += sm.hp * 10;

        endingPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "You article is worth " + score + " dollars.";

        //calculate email and state
        string email = "";
        string writerS = "";
        if (score < -100)
        {
            email = "Maybe you should try a new job other than writing... What about a cashier?";
            writerS = "anxious to death.";
            sm.e1 = true;
        } else if (score >= -100 && score < 0)
        {
            email = "Hmm... You have to admit that this is just normal. I don't know if we can offer you any more chance before you show me something impressive.";
            writerS = "even more anxious.";
            sm.e2 = true;
        } else if (score >=0 && score < 150)
        {
            email = "I can see what you are trying to do. I think with your ideas you can come up with a better story... Maybe you need to work on it more.";
            writerS = "still anxious.";
            sm.e3 = true;
        } else if (score >= 150 && score < 300)
        {
            email = "This is good. But I know you can do far better than this. Keep up the good work.";
            writerS = "anxious about his life.";
            sm.e4 = true;
        } else if (score >= 300 && score < 400)
        {
            email = "I can see that you are trying something new. This is already great, but to make this extraordinary, you need to pay more attention to the details in it.";
            writerS = "anxious about his own skills instead of life.";
            sm.e5 = true;
        } else if (score >= 400 && score < 600)
        {
            email = "This is really great! I can see the shadow of your former works in it. I'm glad you are back.";
            writerS = "relieved, but still a little anxious about surpassing himself...";
            sm.e6 = true;
        } else if (score >= 600)
        {
            email = "This is extraordinary. I didn't even know you could complete something this great. It's going to be very successful, and I'm looking forward to your new work.";
            writerS = "no longer anxious.";
            sm.e7 = true;
        }
        if (sm.tragedy)
        {
            email += "\n" + "Nice tragedy, by the way.";
        }
        endingPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = email;
        endingPanel.transform.GetChild(4).gameObject.GetComponent<Text>().text = writerS;
    }

    public void ReStart()
    {
        sm.ResetAll();
        SceneManager.LoadScene("SceneStart");
    }

    public void ReWrite()
    {
        state= 20;
        StateCheck();
    }


    IEnumerator Next(int box = 0)
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(tm.ShowText(box));
    }

    IEnumerator Ineed()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(tm.ShowText());
        need.SetActive(true);
    }

    IEnumerator Ring()
    {
        yield return new WaitForSeconds(0.5f);
        need.SetActive(false);
        ring.SetActive(true);
        ring.tag = "current";
        TapToContinue(true);
    }


    IEnumerator Anxiety()
    {
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[0].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        noteS[1].SetActive(true);
        noteS[2].SetActive(true);
        TapWait();
    }

    IEnumerator WhatDo()
    {
        isad.GetComponent<Animator>().SetTrigger("more");
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[1].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        noteS[3].SetActive(true);
        TapToContinue();
    }


    IEnumerator Stare2()
    {
        //spotlight.GetComponent<Animator>().SetTrigger("change");
        yield return new WaitForSeconds(0.5f);
        stare1.SetActive(false);
        stare2.SetActive(true);
        //notebookS.GetComponent<Animator>().SetTrigger("turn");
        //yield return new WaitForSeconds(0.3f);
        noteS[4].SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        noteS[5].SetActive(true);
        noteS[5].tag = "current";
        TapToContinue(true);
    }
    
    IEnumerator Crumple1()
    {
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[5].SetActive(false);
        notebookS.GetComponent<Animator>().SetTrigger("move");
        stare2.GetComponent<Animator>().SetTrigger("move");
        line.GetComponent<Animator>().SetTrigger("move");
        yield return new WaitForSeconds(0.5f);
        noteS[6].SetActive(true);
        noteS[7].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        noteS[6].tag = "current";
        TapToContinue(true);
    }

    IEnumerator Crumple2()
    {
        noteS[7].GetComponent<Animator>().SetTrigger("crumple");
        noteS[6].tag = "current";
        yield return new WaitForSeconds(0.5f);
        TapToContinue(true);
        yield return null;
    }

    IEnumerator Throw()
    {
        endingPanel.SetActive(false);
        scrollbar.SetActive(false);
        likeit.SetActive(false);
        hateit.SetActive(false);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[0].SetActive(false);
        notebookS.GetComponent<Animator>().SetTrigger("move");
        stare2.GetComponent<Animator>().SetTrigger("move");
        line.GetComponent<Animator>().SetTrigger("move");
        yield return new WaitForSeconds(0.5f);
        trashcan.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(0.5f);
        noteS[1].SetActive(true);
        noteS[2].SetActive(true);
        TapWait();
        yield return null;
    }

    IEnumerator Normal()
    {
        notebookS.GetComponent<Animator>().SetTrigger("out");
        trashcan.GetComponent<Animator>().SetTrigger("back");
        yield return new WaitForSeconds(1f);
        notebookS.SetActive(false);
        myRoom.SetActive(true);
        StartCoroutine(tm.ShowText());
        yield return new WaitForSeconds(1f);
    }

    IEnumerator InspectRoom()
    {
        yield return new WaitForSeconds(0.5f);
        TapInspect();
    }

    public override void Inspect(Interactable i)
    {
        if (i.normal)
        {
            myRoom.GetComponent<Animator>().SetTrigger("normal");
            tm.textBoxes[0].GetComponent<Text>().text = i.intro;
        } else if (i.window)
        {
            myRoom.GetComponent<Animator>().SetTrigger("window");
            tm.textBoxes[0].GetComponent<Text>().text = i.intro;
        } else if (i.book)
        {
            myRoom.GetComponent<Animator>().SetTrigger("book");
            tm.textBoxes[0].GetComponent<Text>().text = "";
            rayInspect = false;
            StartCoroutine(tm.ShowText());
        }
    }

    IEnumerator BookShelf()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        myRoom.SetActive(false);
        bookShelf.SetActive(true);
        trashcan.SetActive(false);
        if (sm.adventure)
        {
            adventure.SetActive(true);
        }
        if (sm.romance)
        {
            romance.SetActive(true);
        }
        if (sm.horror)
        {
            horror.SetActive(true);
        }
        if (sm.mystery)
        {
            mystery.SetActive(true);
        }
        //some 判定 on what books to appear
        yield return new WaitForSeconds(0.5f);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        
        StartCoroutine(tm.ShowText());
    }

    IEnumerator BookChoose()
    {
        yield return new WaitForSeconds(0.5f);
        rayBook = true;
    }

    IEnumerator OpenBook()
    {
        rayBook = false;
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Transport()
    {
        if (bookChosen == 0)
        {
            SceneManager.LoadScene("SceneFantasy");
        } else if (bookChosen == 1)
        {
            SceneManager.LoadScene("SceneRPG");
        } else if (bookChosen == 2)
        {
            SceneManager.LoadScene("SceneRomance");
        } else if (bookChosen == 3)
        {
            SceneManager.LoadScene("SceneHorror");
        } else if (bookChosen == 4)
        {
            SceneManager.LoadScene("SceneMystery");
        }
        yield return null;
    }

    public void OpenCollections()
    {
        collections.SetActive(true);
        if (sm.e1)
        {
            collections.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e2)
        {
            collections.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e3)
        {
            collections.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e4)
        {
            collections.transform.GetChild(0).GetChild(3).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e5)
        {
            collections.transform.GetChild(0).GetChild(4).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(4).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e6)
        {
            collections.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(5).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.e7)
        {
            collections.transform.GetChild(0).GetChild(6).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(0).GetChild(6).GetChild(1).gameObject.SetActive(false);
        }

        if (sm.b1)
        {
            collections.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.b2)
        {
            collections.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.b3)
        {
            collections.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
        if (sm.b4)
        {
            collections.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
            collections.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(false);
        }

        endingPanel.SetActive(false);
    }

    public void BackToEnding()
    {
        collections.SetActive(false);
        endingPanel.SetActive(true);
    }
}
