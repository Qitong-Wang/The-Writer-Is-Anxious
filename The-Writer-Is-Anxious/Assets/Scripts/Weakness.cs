using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    private SceneThirdDragon gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<SceneThirdDragon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider && hit.collider.gameObject.transform == this.transform)
            {
                gm.weakness = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
