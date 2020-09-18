using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : Interactable
{
    public GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        cat = GameObject.Find("normalcat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        if (FindObjectOfType<SceneSecond>().doorOpened)
        {
            FindObjectOfType<TextManager>().textBoxes[0].GetComponent<Text>().text = "Ah! The bowl is full.";
            return;
        }

        if (FindObjectOfType<SceneSecond>().milkCountDown)
        {
            FindObjectOfType<SceneSecond>().milkCountDown = false;
        }
    }

    public void FillBowl(int i)
    {
        transform.GetChild(i).gameObject.SetActive(true);
        if (i == 0)
        {
            intro = "Doratos.";
            cat.GetComponent<Interactable>().intro = "Cat is staring at the bowl.";
        } else if (i == 1)
        {
            intro = "You do not want to approach it.";
            cat.GetComponent<Interactable>().intro = "Scared? Angry? You cannot read Cat's face.";
        } else if (i == 2)
        {
            intro = "Yummy milk.";
            cat.GetComponent<Interactable>().intro = "Cat looks happy. You are relieved.";
        }
    }
}
