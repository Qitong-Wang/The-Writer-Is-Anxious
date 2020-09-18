using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPicture : Interactable
{
    public Sprite doratoPic;
    public Sprite rottenPic;
    public Sprite milkPic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePic(int i)
    {
        if (i == 0)
        {
            //GetComponent<SpriteRenderer>().sprite = doratoPic;
            changedImage = doratoPic;
        } else if (i == 1)
        {
            //GetComponent<SpriteRenderer>().sprite = rottenPic;
            changedImage = rottenPic;
        } else if (i == 2)
        {
            //GetComponent<SpriteRenderer>().sprite = milkPic;
            changedImage = milkPic;
        }
    }
}
