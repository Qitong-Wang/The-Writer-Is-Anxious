using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public float damageCD;
    float touchTime;
    bool touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touch == true && Time.time>= touchTime+damageCD)
        {
            Player_Horror.instance.DealDamage();
            Player_Horror.instance.horrorDialogue.PrincessHurtDialogue();
            touchTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touch = true;
            
        }
    }
}
