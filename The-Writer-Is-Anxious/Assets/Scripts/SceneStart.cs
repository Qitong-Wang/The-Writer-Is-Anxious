using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStart : GlobalManager
{
    public GameObject twa;
    public GameObject i;

    public GameObject table;
    public GameObject lamp;
    public GameObject light;

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

    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleAppear());
    }


    public override void StateCheck()
    {
        if (state == 0)
        {
            print("no way");
        }
        else if (state == 1)
        {
            StartCoroutine(BiggerI());
        } else if (state == 2)
        {
            StartCoroutine(Realize());
        }
        else if (state == 3)
        {
            StartCoroutine(Next());
        } else if (state == 4)
        {
            StartCoroutine(Ineed());
        }
        else if (state == 5)
        {
            StartCoroutine(Next());
        } else if (state == 6)
        {
            StartCoroutine(Ring());
        } else if (state == 7)
        {
            StartCoroutine(Call());
        }
        else if (state == 8)
        {
            StartCoroutine(Next(1));
        }
        else if (state == 9)
        {
            StartCoroutine(Next(1));
        }
        else if (state == 10)
        {
            StartCoroutine(Next(1));
        }
        else if (state == 11)
        {
            StartCoroutine(CallOver());
        }
        else if (state == 12)
        {
            StartCoroutine(Anxiety());
        }
        else if (state == 13)
        {
            StartCoroutine(WhatDo());
        }
        else if (state == 14)
        {
            StartCoroutine(Stare1());
        }
        else if (state == 15)
        {
            StartCoroutine(Stare2());
        }
        else if (state == 16)
        {
            StartCoroutine(Crumple1());
        }
        else if (state == 17)
        {
            StartCoroutine(Crumple2());
        }
        else if (state == 18)
        {
            StartCoroutine(Crumple2());
        }
        else if (state == 19)
        {
            StartCoroutine(Crumple2());
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
        } else if (state == 26)
        {
            SceneManager.LoadScene("SceneFantasy");
        }
    }

    IEnumerator TitleAppear()
    {
        yield return new WaitForSeconds(1.5f);
        startButton.SetActive(true);
        //TapToContinue();
    }
    public void GameStart()
    {
        state++;
        StateCheck();
        startButton.SetActive(false);
    }

    IEnumerator BiggerI()
    {
        twa.GetComponent<Animator>().SetTrigger("drop");
        i.GetComponent<Animator>().SetTrigger("bigger");
        yield return new WaitForSeconds(2.2f);
        twa.SetActive(false);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator Realize()
    {
        table.GetComponent<Animator>().SetTrigger("appear");
        lamp.GetComponent<Animator>().SetTrigger("appear");
        yield return new WaitForSeconds(1f);
        light.SetActive(true);
        StartCoroutine(tm.ShowText());
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

    IEnumerator Call()
    {
        ring.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        light.SetActive(false);
        table.GetComponent<Animator>().SetTrigger("disappear");
        lamp.GetComponent<Animator>().SetTrigger("disappear");
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<Animator>().SetTrigger("call");
        yield return new WaitForSeconds(1f);
        table.SetActive(false);
        lamp.SetActive(false);
        arm.SetActive(true);
        arm.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(1f);
        line.GetComponent<Animator>().SetTrigger("in");
        editor.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(1f);
        editorBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(tm.ShowText(1));
    }

    IEnumerator CallOver()
    {
        editorBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        editor.GetComponent<Animator>().SetTrigger("out");
        yield return new WaitForSeconds(1.5f);
        arm.GetComponent<Animator>().SetTrigger("out");
        yield return new WaitForSeconds(0.5f);
        arm.SetActive(false);
        spotlight.SetActive(true);
        spotlight.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(1.5f);
        i.SetActive(false);
        isad.SetActive(true);

        light.SetActive(true);
        light.GetComponent<Animator>().SetTrigger("move");
        yield return new WaitForSeconds(0.5f);
        notebookS.SetActive(true);
        noteS[0].SetActive(true);
        //notebookS.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(1.5f);
        notebookS.tag = "current";
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

    IEnumerator Stare1()
    {
        spotlight.GetComponent<Animator>().SetTrigger("change");
        yield return new WaitForSeconds(0.5f);
        isad.SetActive(false);
        light.SetActive(false);
        stare1.SetActive(true);
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[3].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        noteS[4].SetActive(true);
        noteS[4].tag = "current";
        TapToContinue(true);
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
        notebookS.GetComponent<Animator>().SetTrigger("turn");
        yield return new WaitForSeconds(0.3f);
        noteS[6].SetActive(false);
        noteS[7].SetActive(false);
        trashcan.GetComponent<Animator>().SetTrigger("in");
        yield return new WaitForSeconds(0.5f);
        noteS[8].SetActive(true);
        noteS[9].SetActive(true);
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
        //some 判定 on what books to appear
        yield return new WaitForSeconds(0.5f);
        fadeWhite.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        StartCoroutine(tm.ShowText());
    }

    IEnumerator BookChoose()
    {
        yield return new WaitForSeconds(0.5f);
        bookShelf.transform.GetChild(0).gameObject.tag = "current";
        TapToContinue(true);
    }

    IEnumerator OpenBook()
    {
        fadeWhite.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(tm.ShowText());
    }
}
