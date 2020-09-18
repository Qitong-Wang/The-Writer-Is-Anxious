using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float maxleftx;
    public float maxrightx;
    public float miny;

    private float targetx;
    private float targety;

    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
        {
            return;
        }
        targetx = player.position.x + offset.x;
        targety = player.position.y + offset.y;
        if (targetx < maxleftx)
        {
            targetx = maxleftx;
        } else if (targetx > maxrightx){
            targetx = maxrightx;
        }
        if (targety< miny)
        {
            targety = miny;
        }
        transform.position = new Vector3(targetx, targety, offset.z); // Camera follows the player with specified offset position
    }
}
