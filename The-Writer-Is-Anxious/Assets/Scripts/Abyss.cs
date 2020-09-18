using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().StopPlayer();
            //FindObjectOfType<CameraFollow>().pause = true;
            StartCoroutine(collision.gameObject.GetComponent<Player>().Restart());
            collision.gameObject.GetComponent<Player>().DecreaseHP();
        }
        if (collision.gameObject.tag == "MushRoom")
        {
            Destroy(collision.gameObject);
        }
    }
}
