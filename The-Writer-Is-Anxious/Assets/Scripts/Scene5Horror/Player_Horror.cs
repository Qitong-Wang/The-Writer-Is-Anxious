using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player script in Scene3Adventure
/// </summary>
public class Player_Horror : MonoBehaviour
{
    public float currentSpeed;
    public static Player_Horror instance;

    Rigidbody rigidBody;

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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {

    }


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
