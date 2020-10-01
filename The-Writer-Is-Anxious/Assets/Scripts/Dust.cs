using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : InteractableMystery
{
    public override void Inspect()
    {
        this.gameObject.SetActive(false);
    }
}
