using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodstain : InteractableMystery
{
    [TextArea]
    public List<string> intros;
    public override void Inspect()
    {
        gm.rayInspect = false;
        gm.diaM.SetActive(true);
        StartCoroutine(tm.ShowText(intros, 1));
        gm.blood = true;
        //Destroy(this);
    }
}
