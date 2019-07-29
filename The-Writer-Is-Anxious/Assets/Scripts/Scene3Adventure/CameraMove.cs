using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CameraMove in Scene3Adventure
/// </summary>
public class CameraMove : MonoBehaviour
{
    public GameObject player;
    
    public float speed = 20.0f;
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
       
            Vector3 position = transform.position;
            position.x = player.transform.position.x;
            /*
            if (position.x < minX)
            {
                position.x = minX;
            }
            if (position.x > maxX)
            {
                position.x = maxX;
            }
            */
            transform.position = position;
        }
       


   
}
