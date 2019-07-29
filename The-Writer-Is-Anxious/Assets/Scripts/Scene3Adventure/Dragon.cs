using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int hp;
    public bool showWeakness = false;
    public GameObject weaknessObj;
    public GameObject dragonFirePrefab;
    public float fireCD;
    public Vector2 fire1Position;
    public Vector2 fire2Position;
    public Vector2 fire3Position;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Fire the ball to the certain aim
    /// </summary>
    /// <param name="firePosition">[0] is x direction. [1] is y direction</param>
    void FireLavaBall(Vector2 firePosition)
    {
        GameObject fireBall;
        fireBall = Instantiate(dragonFirePrefab, transform.position, Quaternion.identity);
        fireBall.GetComponent<DragonFire>().dragon = gameObject.GetComponent<Dragon>();
        fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(firePosition[0], firePosition[1]);

    }
   
    IEnumerator Fire()
    {
        while (hp>0)
        {
            showWeakness = true;
            if (hp > 0)
            {
                FireLavaBall(fire2Position);
            }

            yield return new WaitForSeconds(fireCD);
            if (hp > 0)
            {
                FireLavaBall(fire1Position);
                FireLavaBall(fire3Position);
            }

            yield return new WaitForSeconds(fireCD);
            if (hp > 0)
            {
                FireLavaBall(fire1Position);
                FireLavaBall(fire2Position);
                FireLavaBall(fire3Position);
            }

            yield return new WaitForSeconds(fireCD);
            if (showWeakness == true)
            {
                weaknessObj.SetActive(true);
                yield return new WaitForSeconds(10f);
                weaknessObj.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(fireCD);
            }
           
        }
       
        
    }



}
