using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool waitingTap = false;
    public bool rayTap = false;
    public bool rayInspect = false;
    public int state;
    public TextManager tm;

    public SaveManager sm;
    public SoundManager sound;

    public GameObject fadeWhite;
    public GameObject fadeBlack;

    //for scene cat
    private bool catStart = false;
    // Start is called before the first frame update
    void Awake()
    {
        state = 0;
        tm = FindObjectOfType<TextManager>();
        sm = FindObjectOfType<SaveManager>();
        sound = FindObjectOfType<SoundManager>();
        fadeWhite = GameObject.Find("FadeWhite");
        fadeBlack = GameObject.Find("FadeBlack");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (rayInspect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.GetComponent<Interactable>())
                {
                    Inspect(hit.collider.gameObject.GetComponent<Interactable>());
                }
            }
            return;
        }
        if (rayTap)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider && hit.collider.gameObject.tag == "current")
                {
                    hit.collider.gameObject.tag = "Untagged";
                    rayTap = false;
                    state++;
                    StateCheck();
                    tm.ClearText();
                    

                }
            }
            return;
        }
        if (!waitingTap)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            //print("tya");
            waitingTap = false;
            
            if (catStart)
            {
                StartCoroutine(tm.ClearTextCat());
                catStart = false;
                return;
            }
            state++;
            StateCheck();
            tm.ClearText();
        }
    }

    public virtual void TapToContinue(bool ray = false)
    {
        if (ray)
        {
            rayTap = true;
            return;
        }
        waitingTap = true;
    }

    public void TapContinueCat()
    {
        waitingTap = true;
        catStart = true;
        
    }

    public void TapInspect()
    {
        rayInspect = true;
    }

    public void TapWait()
    {

    }
    public virtual void StateCheck()
    {

    }

    public virtual void Inspect(Interactable i)
    {

    }

    public virtual void TapFinish()
    {

    }
}
