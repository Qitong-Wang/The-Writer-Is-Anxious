using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMystery : MonoBehaviour
{
    public TextManager tm;
    public SceneSixth gm;

    [TextArea]
    public string intro;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        gm = FindObjectOfType<SceneSixth>();
    }

    public virtual void Inspect()
    {
        gm.rayInspect = false;
        gm.diaM.SetActive(true);
        StartCoroutine(tm.ShowText(intro,1));
        //Destroy(this);
    }
}
