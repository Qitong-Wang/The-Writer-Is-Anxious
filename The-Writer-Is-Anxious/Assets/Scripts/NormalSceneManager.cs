using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class NormalSceneManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueObj;
    public bool trigger = true;
  
    public GameObject triggerObj;
    public List<string> dialogueList;
    public TextAsset textAsset;
    public int step;

    // Start is called before the first frame update
    void Start()
    {
        //dialogueList = new List<string>();
        //textAsset = Resources.Load("Scene1Start") as TextAsset;
        //ReadTextFile();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (trigger == true && Input.GetMouseButtonUp(0))
        {
            NextStep();
        }
     
    }
    public virtual void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();

    }
    public virtual void NextStep()
    {
       
    }

    public virtual void StepAction()
    {
       
       
    }
    public virtual Text GetSuitableText()
    {
        return null;
    }
    public void ClickAction()
    {
        string word = dialogueList[step];
        word = word.Substring(1, word.Length - 2);
        step++;
        NextStep();
        trigger = false;
        DrawTrigger(word);
    }
   
    public void DrawTrigger(string word)
    {
        triggerObj.SetActive(true);
        int startIndex = dialogueList[step - 1].IndexOf(word);
        int endIndex = startIndex + word.Length + 1;
        print(startIndex);
        print(endIndex);
        Vector3 startPosition = PrintPos(startIndex);
        Vector3 endPosition = PrintPos(endIndex);
        if (startPosition.x > endPosition.x)
        {
            startPosition = PrintPos(startIndex + 1); //Means it change the line at the beginning of the word.
        }
        new GameObject("point").transform.position = startPosition;
        new GameObject("poin2").transform.position = endPosition;
        float distance = endPosition.x - startPosition.x;
        triggerObj.SetActive(true);
        triggerObj.transform.position = new Vector3(startPosition.x + distance / 2, startPosition.y + distance / 2, 0);
        triggerObj.GetComponent<BoxCollider2D>().size = new Vector2(distance, distance);

    }

    public Vector3 PrintPos(int charIndex)
    {
        string text = GetSuitableText().text;

        TextGenerator textGen = new TextGenerator(text.Length);
        Vector2 extents = GetSuitableText().gameObject.GetComponent<RectTransform>().rect.size;
        textGen.Populate(text, GetSuitableText().GetGenerationSettings(extents));

        int newLine = text.Substring(0, charIndex).Split('\n').Length - 1;
        int whiteSpace = text.Substring(0, charIndex).Split(' ').Length - 1;
        int indexOfTextQuad = (charIndex * 4) + (newLine * 4) - 4;
        if (indexOfTextQuad < textGen.vertexCount)
        {
            Vector3 avgPos = (textGen.verts[indexOfTextQuad].position +
                textGen.verts[indexOfTextQuad + 1].position +
                textGen.verts[indexOfTextQuad + 2].position +
                textGen.verts[indexOfTextQuad + 3].position) / 4f;

            //print(avgPos);
            //PrintWorldPos(avgPos);
            return GetSuitableText().transform.TransformPoint(avgPos);
        }
        else
        {
            Debug.LogError("Out of text bound");
            return new Vector3(0, 0, 0);
        }
    }

    public IEnumerator ResetTriggerTrue()
    {
        yield return new WaitForSeconds(0.2f);
        trigger = true;
        yield return null;
    }



}
