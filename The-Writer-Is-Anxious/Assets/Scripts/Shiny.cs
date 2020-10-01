using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiny : InteractableHorror
{
    public Sprite scales;

    public override void Inspect()
    {
        base.Inspect();
        GetComponent<SpriteRenderer>().sprite = scales;
        //save something
    }
}
