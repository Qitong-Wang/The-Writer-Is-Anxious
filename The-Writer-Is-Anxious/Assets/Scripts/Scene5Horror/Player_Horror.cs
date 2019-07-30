using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player script in Scene3Adventure
/// </summary>
public class Player_Horror : MonoBehaviour
{
    /// <summary>
    /// Test
    /// </summary>
    public float currentSpeed;
    Rigidbody rigidBody;

    public static Player_Horror instance;
    /// <summary>
    /// HP is from 0 to 1
    /// </summary>
    public float hpKnight;
    public float hpPrincess;
    public Image imageKnightHP;
    public Image imagePrincessHP;
    public HorrorDialogue horrorDialogue;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        UpdateHP();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {

    }
    public void DealDamage()
    {
        int result = Random.Range(0, 4);
        if (result == 0)//No damage
        {
            
        }
        else if (result == 1) //Damage to Knight
        {
            hpKnight -= 0.05f;
        }
        else if (result == 2) //Damage to Princess
        {
            hpPrincess -= 0.05f;
        }
        else if (result == 3) //Damage to Both
        {
            hpKnight -= 0.05f;
            hpPrincess -= 0.05f;
        }
        UpdateHP();
    }
    public void UpdateHP()
    {
        imageKnightHP.fillAmount = hpKnight;
        imagePrincessHP.fillAmount = hpPrincess;
    }
    /// <summary>
    /// Test
    /// </summary>
    public virtual void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {

            rigidBody.velocity = new Vector3(currentSpeed, 0, rigidBody.velocity.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {

            rigidBody.velocity = new Vector3(-currentSpeed, 0, rigidBody.velocity.z);
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
        }

        if (Input.GetAxis("Vertical") > 0)
        {

            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, currentSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {

            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, -currentSpeed);
        }
        else
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, 0);
        }



    }
   

}
