using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Manager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueObj;
    List<string> dialogues;
    public GameObject[] objects;
    public int step = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialogues = new List<string>();
        dialogues.Add("The Writer is anxious.");
        dialogues.Add("Twelve hours ago, he suddenly realized there was a table in front of him, with only a shabby twinkling lamp and a piece of paper landing on it.");
        dialogues.Add("But it is not just a piece of paper.");
        dialogues.Add("I need to figure this out, the writer tells himself. The truth is that he has been telling this to himself for the entire past twelve hours, since he received his editor's 100th call.");
        dialogues.Add("Editor: "+"\""+"The situation is not optimistic."+"\"");
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (step == 0 || step == 1|| step == 2|| step ==3)
            {
                step++;
                NextStep();

            }
        }
    }
    public void NextStep()
    {
        if (step == 1)
        {
            objects[0].SetActive(false); //I
            objects[1].SetActive(true); //I_table
            dialogueText.text = dialogues[1];

        }
        else if (step == 2)
        {
            dialogueText.text = dialogues[2];
        }
        else if (step == 3)
        {
            objects[2].SetActive(true); //I_table_dialogue
            dialogueText.text = dialogues[3];
        }
        else if (step == 4)
        {
            dialogueObj.SetActive(false);
            objects[2].SetActive(false);
            objects[3].SetActive(true); //I_table_ring

        }
        else if (step == 5)
        {
            dialogueObj.SetActive(true);
            dialogueText.text = dialogues[4];
        }
      
    }
    
}
