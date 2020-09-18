using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameObject spawnPoint;
    private Sprite original;
    public Sprite question;

    public GameObject coin;
    public GameObject mushroom;

    public string content;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.GetChild(0).gameObject;
        original = GetComponent<SpriteRenderer>().sprite;
        if (content != "")
        {
            GetComponent<SpriteRenderer>().sprite = question;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerHead")
        {
            if (content == "coin")
            {
                Instantiate(coin, spawnPoint.transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().sprite = original;
            } else if (content == "mushroom")
            {
                Instantiate(mushroom, spawnPoint.transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().sprite = original;
            }
            
        }
    }
}
