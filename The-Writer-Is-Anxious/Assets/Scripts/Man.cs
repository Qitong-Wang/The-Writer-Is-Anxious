using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Man : InteractableMystery
{
    [TextArea]
    public List<string> intros;
    public override void Inspect()
    {
        gm.rayInspect = false;
        gm.nameM.SetActive(true);
        gm.nameM.GetComponentInChildren<Text>().text = "Man";
        gm.diaMname.SetActive(true);
        StartCoroutine(tm.ShowText(intros,0));
        gm.immunity = true;
        //Destroy(this);
    }
}
