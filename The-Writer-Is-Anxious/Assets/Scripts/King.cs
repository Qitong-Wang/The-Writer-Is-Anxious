using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : InteractableRPG
{
    [TextArea]
    public List<string> contents;

    public override void Interact()
    {
        base.Interact();
        tm.textBoxes[0].GetComponent<Text>().text = contents[0];
        choiceB.SetActive(true);
        choiceB.GetComponentInChildren<Text>().text = "Next";
        choiceB.GetComponent<Button>().onClick.AddListener(NextDialogue);
        //gm.TapToContinue();
    }

    public void NextDialogue()
    {
        choiceB.SetActive(false);
        choiceB.GetComponentInChildren<Text>().text = "";
        choiceB.GetComponent<Button>().onClick.RemoveListener(NextDialogue);
        tm.textBoxes[0].GetComponent<Text>().text = contents[1];
        gm.TapFinish();
    }
}
