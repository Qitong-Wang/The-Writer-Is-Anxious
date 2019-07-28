using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWeakness : MonoBehaviour
{
    public GameObject dragon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        Destroy(dragon);
    }

}
