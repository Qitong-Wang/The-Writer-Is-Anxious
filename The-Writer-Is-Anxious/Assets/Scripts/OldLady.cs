using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldLady : InteractableRPG
{

    [TextArea]
    public string content;

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        base.Interact();
        tm.textBoxes[0].GetComponent<Text>().text = content;
        gm.TapFinish();
    }

}
