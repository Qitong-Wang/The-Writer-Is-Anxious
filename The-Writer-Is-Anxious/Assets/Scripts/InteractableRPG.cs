using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableRPG: MonoBehaviour
{
    public Player player;
    public TextManager tm;
    public SceneThird gm;

    [TextArea]
    public string intro;
    public string interactText;
    public GameObject interactButton;
    public GameObject choiceA;
    public GameObject choiceB;

    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<SceneThird>();
        choiceA = GameObject.Find("ChoicePanel").transform.GetChild(0).gameObject;
        choiceB = GameObject.Find("ChoicePanel").transform.GetChild(1).gameObject;
        interactButton = GameObject.Find("ChoicePanel").transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            tm.textBoxes[0].GetComponent<Text>().text = intro;
            if (interactText != "")
            {
                interactButton.SetActive(true);
                interactButton.GetComponentInChildren<Text>().text = interactText;
                interactButton.GetComponent<Button>().onClick.AddListener(Interact);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            tm.textBoxes[0].GetComponent<Text>().text = "";
            if (interactText != "")
            {
                interactButton.SetActive(false);
                interactButton.GetComponentInChildren<Text>().text = "";
                interactButton.GetComponent<Button>().onClick.RemoveListener(Interact);
            }
        }
    }

    public virtual void Interact()
    {
        player.StopPlayer();
        interactButton.SetActive(false);
    }
}
