using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonFire : MonoBehaviour
{
    public Dragon dragon;
    public Text dialogueText;
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
        dialogueText.text = "Knight successfully avoids Dragon's fire attack!";
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Boss>().DecreaseHP();
            dialogueText.text = "Knight takes 1 point of damage.";
            Destroy(gameObject);
        }
    }
}
