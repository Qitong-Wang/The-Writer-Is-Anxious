using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Player player;
    public float speed;
    public Rigidbody2D rg;
    /// <summary>
    /// After the appear animaiton. 
    /// </summary>
    bool beginMoving = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beginMoving == true)
        {

            rg.velocity = new Vector2(2, 0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (beginMoving == true && collision.gameObject.tag == "Player")
        {

            player.Immune();
            Destroy(gameObject);
        }
    }

    public void BeginMoving()
    {
        beginMoving = true;
        rg.bodyType = RigidbodyType2D.Dynamic;
    }
}
