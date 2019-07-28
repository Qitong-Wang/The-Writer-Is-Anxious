﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    /// <summary>
    /// 1 is coin
    /// </summary>
    public int markType;
    public Player player;
    public bool alreadyCollide;
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
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "PlayerHead")
        {
            if (alreadyCollide == false)
            {
                if (markType == 1)
                {
                    player.coins += 10;
                }
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                alreadyCollide = true;
            }

        }
    }
}