using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private Sprite sp;

    public Sprite small;
    public Sprite big;

    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            GetComponent<SpriteRenderer>().sprite = small;
        }
        else if (state == 2)
        {
            GetComponent<SpriteRenderer>().sprite = big;
        }
    }

    public void NextSprite()
    {
        state++;
        
    }
}
