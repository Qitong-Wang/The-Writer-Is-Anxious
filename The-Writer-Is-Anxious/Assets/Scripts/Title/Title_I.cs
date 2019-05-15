using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Title_I : MonoBehaviour, IPointerClickHandler
{
   
    public Animator title_I;
    public GameObject buttons;
    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (clicked == false)
        {
            title_I.SetTrigger("Title_I_Trigger");
            buttons.SetActive(true);
            clicked = true;
        }
        
    }
   
}
