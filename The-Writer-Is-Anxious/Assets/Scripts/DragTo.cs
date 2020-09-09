using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTo : MonoBehaviour
{
    public float lerpTime = 1.0f; 

    public bool isBeingHeld = false;
    private Vector3 startPos;

    private bool lerping = false;

    public GameObject destination;

    public bool collided = false;

    private GlobalManager GM;
    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
        GM = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lerping)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, lerpTime * Time.deltaTime);
            if (transform.position == startPos)
            {
                lerping = false;
            }
        }
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos.z = 10f; //because camera transform.z = -10f qikexiu
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(mousePos.x, mousePos.y, -0.2f);

        }
    }

    public void OnMouseDown()
    {
        lerping = false;
        isBeingHeld = true;
    }

    public void OnMouseUp()
    {
        isBeingHeld = false;
        lerping = true;
        if (collided)
        {
            GM.state++;
            GM.StateCheck();
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("hey");
        if (isBeingHeld && collision.gameObject.transform == destination.transform)
        {
            collided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == destination)
        {
            collided = false;
        }
    }
}
