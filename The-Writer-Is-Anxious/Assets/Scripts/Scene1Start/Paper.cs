using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    /// <summary>
    /// Call by Notebook
    /// </summary>
    public bool beginDrag = false;
    public GameObject trushcan;
    public Vector3 trushPosition;
    public bool checkVector = false;
    float minX;
    float maxX;
    float minY;
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if (beginDrag == true)
        {

            if (checkVector == false)
            {
                minX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
                minY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
                maxX = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)).x;
                maxY = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)).y;
              
                checkVector = true;
            }
           
            
        }
    }
    private void OnMouseDrag()
    {
        if (beginDrag == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
          
            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
            }
            if (transform.position.x > maxX)
            {
                transform.position = new Vector2(maxX, transform.position.y);
            }
            if (transform.position.y < minY)
            {
                transform.position = new Vector2(transform.position.x, minY);
            }
            if (transform.position.y > maxY)
            {
                transform.position = new Vector2(transform.position.x, maxY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name.Equals("trashcan"))
        {
            beginDrag = false;
            transform.position = trushPosition;
            print("Finish!");
        }
    }
    
}