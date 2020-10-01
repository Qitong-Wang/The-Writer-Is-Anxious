using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDoor2 : InteractableMystery
{
    public override void Inspect()
    {
        gm.NextScene();
    }
}
