using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player script in Scene3Adventure
/// </summary>
public class Player : MonoBehaviour
{
    public float currentSpeed;
    public float jumpSpeed;
    Rigidbody2D rigidBody;
    public float rayLength;
    public bool onGround;
    public LayerMask groundLayer;
    public GameObject gameOverCanvas;
    //public GameOverManager gameOverManager;
    public Scene3Manager scene3Manager;
    public Text coinsText;
    public Text hpText;
    public int coins;
    public int hp;
    public bool immune;

    public float immunetTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateCoinText();
        UpdateHPText();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Jump();
        if (immune == true && Time.time > immunetTime + 5f)
        {
            immune = false;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
    public virtual void Jump()
    {
        if (OnGround() == true && scene3Manager.otherObjActive == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

            }
        }
    }
    public virtual bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (hit.collider != null)
        {

            return true;
        }
        return false;
    }
    public virtual void Move()
    {
        if (Input.GetAxis("Horizontal") > 0 && scene3Manager.otherObjActive == true)
        {

            rigidBody.velocity = new Vector2(currentSpeed, rigidBody.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0 && scene3Manager.otherObjActive == true)
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
        gameOverCanvas.SetActive(true);
        //gameOverManager.PauseGame();
    }
    public void Immune()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        immune = true;
        immunetTime = Time.time;
    }
    public void UpdateCoinText()
    {
        coinsText.text = "Coins:" + coins;
    }
    public void UpdateHPText()
    {
        hpText.text = "HP:" + hp;
    }
    public void DecreaseHP()
    {
        if (immune == false)
        {
            hp -= 1;
            UpdateHPText();
        }
        if (hp <= 0)
        {
            GameOver();
        }
    }
}
