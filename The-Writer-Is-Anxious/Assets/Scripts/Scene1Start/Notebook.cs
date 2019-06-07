using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public Scene1Manager scene1Manager;
    public Vector3 left1Position;
    public bool moveLeft1 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft1 == true)
        {
            if (transform.position.x >left1Position.x+0.01f)
            {
                transform.position = Vector3.Lerp(transform.position, left1Position, Time.deltaTime);

            }
            else
            {
                moveLeft1 = false;
               
            }
        }
    }
}
