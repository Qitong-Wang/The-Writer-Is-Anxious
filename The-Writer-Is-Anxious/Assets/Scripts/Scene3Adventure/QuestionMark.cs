using System.Collections;
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
    public GameObject mushRoomPrefab;
    public GameObject coinPrefab;
    public Animator animator;
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
        
        if (collision.gameObject.tag == "PlayerHead")
        {
            if (alreadyCollide == false)
            {
               
                if (markType == 1) //coin
                {
                    
                    GameObject coin;
                    Vector2 summonPosition = new Vector2(transform.position.x, transform.position.y + 0.9f);
                    coin = Instantiate(coinPrefab, summonPosition, Quaternion.identity);
                    coin.GetComponent<Coin>().player = player;
                    coin.transform.SetParent(gameObject.transform);
                    
                }
                else if (markType == 2) //immune
                {
                    GameObject mushRoom;
                    Vector2 summonPosition = new Vector2(transform.position.x, transform.position.y+0.9f);
                    mushRoom = Instantiate(mushRoomPrefab, summonPosition, Quaternion.identity);
                    mushRoom.GetComponent<Mushroom>().player = player;
                    
                }
                animator.SetTrigger("jump");
                alreadyCollide = true;
            }

        }
    }
}
