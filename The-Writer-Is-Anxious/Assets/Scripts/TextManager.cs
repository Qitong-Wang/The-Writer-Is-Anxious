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

    public void ClearText()
    {
        currentText = "";
        textUI.GetComponent<Text>().text = currentText;
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
