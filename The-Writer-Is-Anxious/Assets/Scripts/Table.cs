using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table: Interactable
{
    public SceneSecond GM;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        count++;
        if (count == 1)
        {
            intro = "Hmm.";
        } else if (count == 2)
        {
            intro = "You're using all your might to shove it.";
        } else if (count == 3)
        {
            intro = "It's moving, isn't it?";
        } else if (count == 4)
        {
            intro = "Maybe one more time.";
        } else if (count == 5)
        {
            intro = "A table.";
            GM.milkCountDown = true;
            StartCoroutine(GM.CountDown());
            choices.Clear();
        }
        FindObjectOfType<TextManager>().textBoxes[0].GetComponent<Text>().text = intro;
    }
}
