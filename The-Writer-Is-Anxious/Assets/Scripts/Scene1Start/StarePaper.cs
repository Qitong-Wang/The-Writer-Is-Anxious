using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarePaper : MonoBehaviour
{
    public Scene1Manager scene1Manager;
    public bool enlarge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enlarge == true) {
            if (transform.localScale.x < 0.59f)
            {
                transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 0.6f, Time.deltaTime), Mathf.Lerp(transform.localScale.y, 0.6f, Time.deltaTime), 1);

            }
            else
            {
                
                scene1Manager.NextStep();
                scene1Manager.step++;
                enlarge = false;
            }
        }
    }
}
