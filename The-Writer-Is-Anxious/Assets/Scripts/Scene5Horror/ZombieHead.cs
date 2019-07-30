using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject.transform.parent.gameObject);
   
    }
}
