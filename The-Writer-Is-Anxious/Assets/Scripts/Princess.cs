using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : InteractableMystery
{
    public override void Inspect()
    {
        gm.rayInspect = false;
        gm.diaM.SetActive(true);
        StartCoroutine(tm.ShowText("Are you ready for the cross-examination?", 1,false));
        gm.SetChoice(0, true);
        gm.SetChoice(1, false);
    }
}
