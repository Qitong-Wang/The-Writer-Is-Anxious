using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Princess2 : InteractableMystery
{
    [TextArea]
    public List<string> intros;
    public override void Inspect()
    {
        gm.rayInspect = false;
        gm.nameM.SetActive(true);
        gm.nameM.GetComponentInChildren<Text>().text = "Princess";
        gm.diaMname.SetActive(true);
        StartCoroutine(tm.ShowText(intros, 0));
        //Destroy(this);
    }
}
