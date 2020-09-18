using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mushroom : MonoBehaviour
{
    public Player player;
    [TextArea]
    public string content;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.StopPlayer();
            FindObjectOfType<TextManager>().textBoxes[0].GetComponent<Text>().text = content;
            GameObject.Find("ChoicePanel").transform.GetChild(2).gameObject.SetActive(false);
            FindObjectOfType<SceneThird>().TapToContinue();
            Destroy(gameObject);
        }

    }
}