using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InteractableHorror
{
    public override void Inspect()
    {
        base.Inspect();
        gm.Team[0] = 5;
        gm.SetAllHealth();
    }
}
