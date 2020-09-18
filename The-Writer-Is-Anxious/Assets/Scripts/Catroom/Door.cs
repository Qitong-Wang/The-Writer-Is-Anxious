using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Sprite opendoor;

    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor()
    {
        GetComponent<SpriteRenderer>().sprite = opendoor;
        originalImage = opendoor;
        open = true;
    }

    public override void Use()
    {
        if (!open)
        {
            return;
        }
        //transfer to the next scene
        GameObject.FindObjectOfType<GlobalManager>().rayInspect = false;
        GameObject.FindObjectOfType<GlobalManager>().state++;
        GameObject.FindObjectOfType<GlobalManager>().StateCheck();
    }
}
