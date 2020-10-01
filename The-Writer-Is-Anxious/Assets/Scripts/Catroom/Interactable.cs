using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatChoices
{
    public string intro;
    public string order = "text"; //text:显示字 death:死 door:开门方法
    [TextArea]
    public string newText;
}



public class Interactable : MonoBehaviour
{
    [TextArea]
    public string intro;
    public bool normal = false;
    public bool book = false;
    public bool window = false;

    //CATLEVEL
    public bool left = false;
    public bool right = false;

    public Sprite originalImage;
    public Sprite changedImage;
    public bool hasChoice = false;
    public List<CatChoices> choices;
    [TextArea]
    public string milkText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Use()
    {

    }
}
