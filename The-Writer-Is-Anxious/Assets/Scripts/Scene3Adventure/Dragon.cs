using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int hp;
    int phaseNumber = 1;
    /// <summary>
    /// qianyao
    /// </summary>
    public float fireCDBefore;
    /// <summary>
    /// houyao
    /// </summary>
    public float fireCDAfter;
    /// <summary>
    /// player is able to click the dragon and go into the phase
    /// </summary>
    bool ableClick = true;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (ableClick == true)
        {
            if(phaseNumber == 1)
            {
                StartCoroutine(Phase1());
            }
            else if (phaseNumber == 2)
            {
                StartCoroutine(Phase2());
            }
            else
            {
                StartCoroutine(Phase3());
            }
            phaseNumber++;
        }
    }
    /// <summary>
    /// Fire the ball to the certain aim
    /// </summary>
    /// <param name="firePosition">[0] is x direction. [1] is y direction</param>
    void FireLavaBall()
    {
        GameObject fireBall;
        int randomPosition = Random.Range(1, 4);
        Vector2 firePosition;
        if (randomPosition == 1)
        {
            firePosition = fire1Position;
        }
        else if (randomPosition == 2)
        {
            firePosition = fire2Position;
        }
        else
        {
            firePosition = fire3Position;
        }
        fireBall = Instantiate(dragonFirePrefab, transform.position, Quaternion.identity);
        fireBall.GetComponent<DragonFire>().dragon = gameObject.GetComponent<Dragon>();
        fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(firePosition[0], firePosition[1]);

    }
    IEnumerator Phase1()
    {
        ableClick = false;
        yield return new WaitForSeconds(fireCDBefore);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDAfter);
        ableClick = true;
        yield return null;
    }
    IEnumerator Phase2()
    {
        ableClick = false;
        yield return new WaitForSeconds(fireCDBefore);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDBefore);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDAfter);
        ableClick = true;
        yield return null;
    }
    IEnumerator Phase3()
    {
        ableClick = false;
        yield return new WaitForSeconds(fireCDBefore);
        weaknessObj.SetActive(true);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDBefore);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDBefore);
        FireLavaBall();
        yield return new WaitForSeconds(fireCDAfter);
        weaknessObj.SetActive(false);
        ableClick = true;
        yield return null;
    }
 

}
