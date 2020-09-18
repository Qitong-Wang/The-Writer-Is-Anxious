using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Child : InteractableRPG
{

    public string chest;

    [TextArea]
    public string normal;

    [TextArea]
    public string coin;

    [TextArea]
    public string empty;

    public override void Interact()
    {
        base.Interact();
        if (chest == "")
        {
            tm.textBoxes[0].GetComponent<Text>().text = normal;
        } else if (chest == "coin")
        {
            tm.textBoxes[0].GetComponent<Text>().text = coin;
        } else if (chest == "empty")
        {
            tm.textBoxes[0].GetComponent<Text>().text = empty;
        }
        
        gm.TapFinish();
    }
}
