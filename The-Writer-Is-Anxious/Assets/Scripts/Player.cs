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
    //public GameObject gameOverCanvas;
    //public GameOverManager gameOverManager;
    //public Scene3Manager scene3Manager;
    public Text coinsText;
    public GameObject hpObject;
    public int coins;
    public int hp;
    public bool immune;

    public float immunetTime;

    public bool jump = false;
    public bool left = false;
    public bool right = false;

    public bool stop = false;

    private GameObject buttons;

    public Transform startPos;
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateCoinText();
        //UpdateHPText();
        buttons = GameObject.Find("Buttons");
        if (GameObject.Find("StartPosition"))
            startPos = GameObject.Find("StartPosition").transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stop)
        {
            return;
        }
        Move();
    }

    public void StopPlayer()
    {
        right = false;
        left = false;
        jump = false;
        stop = true;
        buttons.SetActive(false);
    }

    public void ActivatePlayer()
    {
        if (FindObjectOfType<SceneThird>().death)
        {
            return;
        }
        stop = false;
        buttons.SetActive(true);
    }
    private void Update()
    {
        //Jump();
        if (immune == true && Time.time > immunetTime + 5f)
        {
            immune = false;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void SendJump()
    {
        jump = true;
        Jump();
    }

    public virtual void Jump()
    {
        if (OnGround() == true)
        {
            if (jump)
            {
                jump = false;
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
        if (right || Input.GetAxis("Horizontal")>0)
        {

            rigidBody.velocity = new Vector2(currentSpeed, rigidBody.velocity.y);
        }
        else if (left || Input.GetAxis("Horizontal") < 0)
        {

            rigidBody.velocity = new Vector2(-currentSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetKeyDown("space"))
        {
            SendJump();
        }
    }

    public void PressLeft()
    {
        left = true;
    }

    public void ReleaseLeft()
    {
        left = false;
    }

    public void PressRight()
    {
        right = true;
    }

    public void ReleaseRight()
    {
        right = false;
    }

    public void ChangeStart(int i)
    {
        startPos = GameObject.Find("StartPosition").transform.GetChild(i);
    }

    public IEnumerator Restart()
    {
        GameObject.Find("FadeWhite").GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        transform.position = startPos.position;
        //FindObjectOfType<CameraFollow>().pause = false;
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("FadeWhite").GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        ActivatePlayer();
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
        if (FindObjectOfType<SceneThird>())
        {
            stop = true;
            FindObjectOfType<SceneThird>().death = true;
            FindObjectOfType<SceneThird>().state++;
            FindObjectOfType<SceneThird>().StateCheck();
        }
        else
        {
            FindObjectOfType<SceneThirdDragon>().Death();
        }
        

        //gameOverCanvas.SetActive(true);
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
        coinsText.text = "Coins: " + coins;
    }
    public void UpdateHPText()
    {
        if (hp == 5)
        {
            hpObject.transform.GetChild(0).gameObject.SetActive(true);
            hpObject.transform.GetChild(1).gameObject.SetActive(true);
            hpObject.transform.GetChild(2).gameObject.SetActive(true);
            hpObject.transform.GetChild(3).gameObject.SetActive(true);
            hpObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (hp == 4)
        {
            hpObject.transform.GetChild(0).gameObject.SetActive(true);
            hpObject.transform.GetChild(1).gameObject.SetActive(true);
            hpObject.transform.GetChild(2).gameObject.SetActive(true);
            hpObject.transform.GetChild(3).gameObject.SetActive(true);
            hpObject.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (hp == 3)
        {
            hpObject.transform.GetChild(0).gameObject.SetActive(true);
            hpObject.transform.GetChild(1).gameObject.SetActive(true);
            hpObject.transform.GetChild(2).gameObject.SetActive(true);
            hpObject.transform.GetChild(3).gameObject.SetActive(false);
            hpObject.transform.GetChild(4).gameObject.SetActive(false);
        } else if (hp == 2)
        {
            hpObject.transform.GetChild(0).gameObject.SetActive(true);
            hpObject.transform.GetChild(1).gameObject.SetActive(true);
            hpObject.transform.GetChild(2).gameObject.SetActive(false);
            hpObject.transform.GetChild(3).gameObject.SetActive(false);
            hpObject.transform.GetChild(4).gameObject.SetActive(false);
        } else if (hp == 1)
        {
            hpObject.transform.GetChild(0).gameObject.SetActive(true);
            hpObject.transform.GetChild(1).gameObject.SetActive(false);
            hpObject.transform.GetChild(2).gameObject.SetActive(false);
            hpObject.transform.GetChild(3).gameObject.SetActive(false);
            hpObject.transform.GetChild(4).gameObject.SetActive(false);
        }
        //hpText.text = "HP:" + hp;
    }
    public void DecreaseHP()
    {
        if (immune == false)
        {
            FindObjectOfType<SaveManager>().noHurt = false;
            hp -= 1;
            UpdateHPText();
        }
        if (hp <= 0)
        {
            GameOver();
        }
    }
}
