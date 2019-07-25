using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player script in Scene3Adventure
/// </summary>
public class Player : MonoBehaviour
{
    public float currentSpeed;
    public float jumpSpeed;
    Rigidbody2D rigidBody;
    public bool onGround;
    public LayerMask groundLayer;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Jump();
    }
    public virtual void Jump()
    {
        if (OnGround() == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

            }
        }
    }
    public virtual bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.5f, groundLayer);

        if (hit.collider != null)
        {

            return true;
        }
        return false;
    }
    public virtual void Move()
    {
        if (Input.GetAxis("Horizontal")>0)
        {

            rigidBody.velocity = new Vector2(currentSpeed, rigidBody.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {

            rigidBody.velocity = new Vector2(-currentSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            GameOver();


        }
        if (collision.gameObject.tag == "Water")
        {
            GameOver();
        }
    }
    public void GameOver()
    {
       // gameOverCanvas.SetActive(true);
    }

}
