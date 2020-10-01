using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float delay = 0.03f;
    public string fullText;
    private string currentText = "";

    public List<GameObject> textBoxes;
    private GameObject textUI;
    public GameObject GM;

    [TextArea]
    public List<string> dialogues;
    public int dIndex;

    public bool finished;

    private bool waitingTap = false;
    private List<string> current;
    // Start is called before the first frame update
    void Start()
    {
        textUI = textBoxes[0];
        finished = true;
        dIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && waitingTap)
        {
            waitingTap = false;


        }
        if (finished)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            finished = true;
        }
    }

    //scene 0 = start
    public IEnumerator ShowText(int box = 0)
    {
        textUI = textBoxes[box];
        
        finished = false;
        fullText = dialogues[dIndex];
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;
        dIndex++;
        
        //finished blahblah
        GM.GetComponent<GlobalManager>().TapToContinue();
    }

    public IEnumerator ShowText(string txt, int box = 0, bool tap = true)
    {
        textUI = textBoxes[box];

        finished = false;
        fullText = txt;
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true && tap)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;

        if (tap == false){
            yield break;
        }
        //finished blahblah
        GM.GetComponent<GlobalManager>().TapToContinue();
    }

    public IEnumerator ShowText(List<string> txts, int box = 0)
    {
        textUI = textBoxes[box];

        finished = false;
        fullText = txts[0];

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;
        waitingTap = true;
        while (waitingTap)
        {
            yield return null;
        }

        fullText = txts[1];

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;
        

        if (txts.Count > 2)
        {
            waitingTap = true;
            while (waitingTap)
            {
                yield return null;
            }
            fullText = txts[2];

            for (int i = 0; i < fullText.Length + 1; i++)
            {
                if (finished == true)
                {
                    textUI.GetComponent<Text>().text = fullText;
                    break;
                }
                currentText = fullText.Substring(0, i);
                textUI.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            finished = true;
        }
        if (txts.Count > 3)
        {
            waitingTap = true;
            while (waitingTap)
            {
                yield return null;
            }
            fullText = txts[3];

            for (int i = 0; i < fullText.Length + 1; i++)
            {
                if (finished == true)
                {
                    textUI.GetComponent<Text>().text = fullText;
                    break;
                }
                currentText = fullText.Substring(0, i);
                textUI.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            finished = true;
        }

        GM.GetComponent<GlobalManager>().TapToContinue();
    }

    public IEnumerator ShowText(List<string> txts, int box,List<string> names, Text textBox, string s)
    {
        textUI = textBoxes[box];

        finished = false;
        fullText = txts[0];
        textBox.text = names[0];

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;
        waitingTap = true;
        while (waitingTap)
        {
            yield return null;
        }

        fullText = txts[1];
        textBox.text = names[1];
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            if (finished == true)
            {
                textUI.GetComponent<Text>().text = fullText;
                break;
            }
            currentText = fullText.Substring(0, i);
            textUI.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        finished = true;


        if (txts.Count > 2)
        {
            waitingTap = true;
            while (waitingTap)
            {
                yield return null;
            }
            fullText = txts[2];
            textBox.text = names[2];
            for (int i = 0; i < fullText.Length + 1; i++)
            {
                if (finished == true)
                {
                    textUI.GetComponent<Text>().text = fullText;
                    break;
                }
                currentText = fullText.Substring(0, i);
                textUI.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            finished = true;
        }
        if (txts.Count > 3)
        {
            waitingTap = true;
            while (waitingTap)
            {
                yield return null;
            }
            fullText = txts[3];
            textBox.text = names[3];
            for (int i = 0; i < fullText.Length + 1; i++)
            {
                if (finished == true)
                {
                    textUI.GetComponent<Text>().text = fullText;
                    break;
                }
                currentText = fullText.Substring(0, i);
                textUI.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            finished = true;
        }

        if (s == "state4new2")
        {
            FindObjectOfType<SceneSixth>().statements[3] = FindObjectOfType<SceneSixth>().statements[7];
            FindObjectOfType<SceneSixth>().state4 = FindObjectOfType<SceneSixth>().state4new2;
        } else if (s == "state3new")
        {
            FindObjectOfType<SceneSixth>().statements[2] = FindObjectOfType<SceneSixth>().statements[5];
            FindObjectOfType<SceneSixth>().state3 = FindObjectOfType<SceneSixth>().state3new;
        } else if (s == "state5")
        {
            FindObjectOfType<SceneSixth>().finalround = true;
            FindObjectOfType<SceneSixth>().stateInt = 8;
        } else if (s == "win")
        {
            FindObjectOfType<SceneSixth>().state++;
        } else if (s == "death")
        {
            StartCoroutine(FindObjectOfType<SceneSixth>().Die());
        }
        GM.GetComponent<GlobalManager>().TapToContinue();
    }



    public void ClearText()
    {
        currentText = "";
        textUI.GetComponent<Text>().text = "";
    }

    public void ClearAllText()
    {
        for (int i = 0; i < textBoxes.Count; i++)
        {
            textBoxes[i].GetComponent<Text>().text = "";
        }
    }

    public IEnumerator ShowTextCat()
    {
        textUI = textBoxes[1];
        fullText = dialogues[dIndex];
        textUI.GetComponent<Text>().text = fullText;
        textUI.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        dIndex++;

        //finished blahblah
        GM.GetComponent<GlobalManager>().TapContinueCat();
    }

    public IEnumerator ClearTextCat()
    {
        textUI.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1.1f);
        currentText = "";
        textUI.GetComponent<Text>().text = currentText;
        GM.GetComponent<GlobalManager>().state++;
        GM.GetComponent<GlobalManager>().StateCheck();
    }
}
