using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{

    public float timeAmt = 3f;
    public float time;

    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        time = timeAmt;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            this.transform.parent.gameObject.SetActive(false);
            FindObjectOfType<SceneFifth>().SaveQTE(2);
        }
        if (start)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                GetComponent<Image>().fillAmount = time / timeAmt;
            }
        }
    }
}
