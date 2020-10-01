using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantZombie : MonoBehaviour
{
    public bool start = false;
    private int attacked = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider && hit.collider.gameObject == this.gameObject)
            {
                attacked++;
                if (attacked >= 5)
                {
                    attacked = 0;
                    GetComponent<Animator>().SetTrigger("Far");
                }
            }
        }
    }
}
