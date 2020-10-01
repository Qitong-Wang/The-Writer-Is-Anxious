using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidencePanel : MonoBehaviour
{
    public int state = 0;
    public TextManager tm;
    public SceneSixth gm;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        gm = FindObjectOfType<SceneSixth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            GetComponentInChildren<Text>().text = gm.gunfireT[1];
        } else if (state == 1)
        {
            GetComponentInChildren<Text>().text = gm.newsT;
        } else if (state == 2)
        {
            GetComponentInChildren<Text>().text = gm.cboyT;
        }
        else if (state == 3)
        {
            GetComponentInChildren<Text>().text = gm.bloodT;
        }
        else if (state == 4)
        {
            GetComponentInChildren<Text>().text = gm.immunityT;
        }
    }
}
