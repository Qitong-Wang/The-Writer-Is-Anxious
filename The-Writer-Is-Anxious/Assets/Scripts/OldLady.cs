using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : MonoBehaviour
{
    public Scene3Manager scene3Manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            scene3Manager.ReadDialogue("OldLady");
            scene3Manager.trigger = true;

        }
    }

}
