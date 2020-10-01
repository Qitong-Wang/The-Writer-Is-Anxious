using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidMystery : InteractableMystery
{
    public override void Inspect()
    {
        gm.hp = 5;
        base.Inspect();
        
    }
}
