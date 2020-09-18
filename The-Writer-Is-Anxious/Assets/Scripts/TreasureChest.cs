using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteractableRPG
{
    [TextArea]
    public string coin;

    [TextArea]
    public string empty;

    [TextArea]
    public string openedChest;

    public Sprite opened;
    private bool open = false;

    public override void Interact()
    {
        
        base.Interact();
        if (open == true)
        {
            tm.textBoxes[0].GetComponent<Text>().text = openedChest;
            gm.TapToContinue();
            return;
        }
        int i = Random.Range(0, 1);
        if (i == 0)
        {
            tm.textBoxes[0].GetComponent<Text>().text = coin;
            FindObjectOfType<Child>().chest = "coin";
            player.coins += 500;
            player.UpdateCoinText();
        }
        else if (i == 1)
        {
            tm.textBoxes[0].GetComponent<Text>().text = empty;
            FindObjectOfType<Child>().chest = "none";
        }
        GetComponent<SpriteRenderer>().sprite = opened;
        open = true;
        gm.TapFinish();
    }
}
