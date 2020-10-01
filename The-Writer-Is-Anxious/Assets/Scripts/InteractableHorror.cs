using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableHorror : MonoBehaviour
{
    public TextManager tm;
    public SceneFifth gm;

    [TextArea]
    public string intro;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        gm = FindObjectOfType<SceneFifth>();
    }

    public virtual void Inspect()
    {
        tm.textBoxes[3].GetComponent<Text>().text = intro;
    }
}
