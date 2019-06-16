using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookShelfRoomTrigger : MonoBehaviour
{
    public Text mainText;
    /// <summary>
    /// 0 is close window. 1 is clock. 2 is trashcan. 3  is bookshelf
    /// </summary>
    public int trigger_number;
    public GameObject i;
    public GameObject i_byWindow;
    public GameObject i_byshelf;
    public GameObject closeWindow;
    public Sprite openWindow;
    public GameObject shelfBooks;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (trigger_number == 0)
        {
            closeWindow.GetComponent<SpriteRenderer>().sprite = openWindow;
            i.SetActive(false);
            i_byshelf.SetActive(false);
            i_byWindow.SetActive(true);
            mainText.text = "The moon is beautiful, isn't it?";
           
        }
        else if (trigger_number == 1)
        {
            i.SetActive(true);
            i_byshelf.SetActive(false);
            i_byWindow.SetActive(false);
            mainText.text = "It is 10pm. And yes, it is.";
           
        }
        else if (trigger_number == 2)
        {
            i.SetActive(true);
            i_byshelf.SetActive(false);
            i_byWindow.SetActive(false);
            mainText.text = "NEVER look back to old drafts.";
        }
        else if (trigger_number == 3)
        {
            i.SetActive(false);
            i_byWindow.SetActive(false);
            i_byshelf.SetActive(true);
            mainText.text = "Right! The books! Always the best solution, aren't they?\nThe writer goes to the bookshelf, and picks up a...";
            shelfBooks.SetActive(true);
        }
    }
}
