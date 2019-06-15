using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbleTrigger : MonoBehaviour
{
    public int inputTime = 0;
    public SpriteRenderer paper;
    public Scene1Manager scene1Manager;
    public Sprite paper2;
    public Sprite paper3;
    public Sprite paper4;
    public Notebook notebook;
    /// <summary>
    /// Call by notebook
    /// </summary>
    public bool beginCrumble = false;
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
        if (beginCrumble == true)
        {
            if (inputTime == 0)
            {
                paper.sprite = paper2;
                inputTime++;
            }
            else if (inputTime == 1)
            {
                paper.sprite = paper3;
                inputTime++;
            }
            else if (inputTime == 2)
            {
                paper.sprite = paper4;
                paper.gameObject.transform.parent = null;
                inputTime++;
                notebook.moveLeft2 = true;

            }
          
        }


    }
}
