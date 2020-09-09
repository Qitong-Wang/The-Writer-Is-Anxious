using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSecond : GlobalManager
{

    public GameObject frames;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneStart());
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
    }
}
