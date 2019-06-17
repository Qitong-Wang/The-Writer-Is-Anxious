using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public Scene1Manager scene1Manager;
    public Vector3 left1Position;
    public Vector3 left2Position;
    public List<GameObject> left1Disappear;
    public CrumbleTrigger crumbleTrigger;
    public bool moveLeft1 = false;
    public bool moveLeft2 = false;
    public List<GameObject> left2Disappear;
    public Paper paper;
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
                for (int i = 0; i < left1Disappear.Count; i++)
                {
                    left1Disappear[i].SetActive(false);
                }
                crumbleTrigger.beginCrumble = true;
               
            }
        }
        if (moveLeft2 == true)
        {
            if (transform.position.x > left2Position.x + 0.01f)
            {
                transform.position = Vector3.Lerp(transform.position, left2Position, Time.deltaTime);

            }
            else
            {
                moveLeft2 = false;
                for (int i = 0; i < left2Disappear.Count; i++)
                {
                    left2Disappear[i].SetActive(false);
                }
                paper.beginDrag = true;

            }
        }
    }
}
