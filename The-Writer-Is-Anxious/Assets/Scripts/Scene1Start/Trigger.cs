using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Scene1Manager scene1Manager;
    public int baseStep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (scene1Manager.step == baseStep)
        {
            scene1Manager.step++;
            scene1Manager.NextStep();
        }
    }
}
