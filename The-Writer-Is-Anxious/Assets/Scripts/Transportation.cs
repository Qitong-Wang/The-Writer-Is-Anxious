using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transportation : MonoBehaviour
{
    public TextManager tm;
    public Transform target;
    public float targetxleft;
    public float targetxright;
    public float targetymin;
    public GameObject choiceA;
    public GameObject choiceB;

    public int startpos;

    public string transportText;

    public bool last = false;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        choiceA = GameObject.Find("ChoicePanel").transform.GetChild(0).gameObject;
        choiceB = GameObject.Find("ChoicePanel").transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (last)
            {
                FindObjectOfType<SceneThird>().state++;
                FindObjectOfType<SceneThird>().StateCheck();
                return;
            }
            FindObjectOfType<Player>().StopPlayer();
            tm.textBoxes[0].GetComponent<Text>().text = transportText;
            choiceA.SetActive(true);
            choiceB.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = "Yes.";
            choiceB.GetComponentInChildren<Text>().text = "No.";

            choiceA.GetComponent<Button>().onClick.AddListener(Transport);
            choiceB.GetComponent<Button>().onClick.AddListener(Cancle);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<Player>().StopPlayer();
            tm.textBoxes[0].GetComponent<Text>().text = transportText;
            choiceA.SetActive(true);
            choiceB.SetActive(true);
            choiceA.GetComponentInChildren<Text>().text = "Yes.";
            choiceB.GetComponentInChildren<Text>().text = "No.";

            choiceA.GetComponent<Button>().onClick.AddListener(Transport);
            choiceB.GetComponent<Button>().onClick.AddListener(Cancle);
        }
    }

    public void Transport()
    {
        StartCoroutine(MovePlayer(target,targetxleft,targetxright, targetymin));
        FindObjectOfType<Player>().startPos = GameObject.Find("StartPosition").transform.GetChild(startpos);
    }

    public IEnumerator MovePlayer(Transform t, float maxleft, float maxright, float miny)
    {
        tm.textBoxes[0].GetComponent<Text>().text = "";
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceA.GetComponentInChildren<Text>().text = "";
        choiceB.GetComponentInChildren<Text>().text = "";
        choiceA.GetComponent<Button>().onClick.RemoveListener(Transport);
        choiceB.GetComponent<Button>().onClick.RemoveListener(Cancle);

        GameObject.Find("FadeWhite").GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Player>().transform.position = t.position;
        FindObjectOfType<CameraFollow>().maxleftx = maxleft;
        FindObjectOfType<CameraFollow>().maxrightx = maxright;
        FindObjectOfType<CameraFollow>().miny = miny;
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("FadeWhite").GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Player>().ActivatePlayer();
    }

    public void Cancle()
    {
        tm.textBoxes[0].GetComponent<Text>().text = "";
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceA.GetComponentInChildren<Text>().text = "";
        choiceB.GetComponentInChildren<Text>().text = "";
        choiceA.GetComponent<Button>().onClick.RemoveListener(Transport);
        choiceB.GetComponent<Button>().onClick.RemoveListener(Cancle);
        FindObjectOfType<Player>().ActivatePlayer();
    }

}
