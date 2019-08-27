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
                    player.UpdateCoinText();
                }
                else if (markType == 2)
                {
                    GameObject mushRoom;
                    Vector2 summonPosition = new Vector2(transform.position.x, transform.position.y+0.9f);
                    mushRoom = Instantiate(mushRoomPrefab, summonPosition, Quaternion.identity);
                    mushRoom.GetComponent<Mushroom>().player = player;
                    
                }
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                alreadyCollide = true;
            }

        }
    }
}
