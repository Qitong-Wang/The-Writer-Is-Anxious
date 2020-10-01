using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    public int i;
    
    public void ChooseBook()
    {
        FindObjectOfType<SceneEnd>().bookChosen = i;
        FindObjectOfType<SceneEnd>().state++;
        FindObjectOfType<SceneEnd>().StateCheck();
    }
}
