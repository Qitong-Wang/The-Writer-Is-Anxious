using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //check if scene ever reached
    public bool adventure;
    public bool romance;
    public bool horror;
    public bool mystery;

    [TextArea]
    public string currentArticle;
    public int state;

    public string catRoom; //save for food in bowl

    public int hp;
    public int coin;
    public int love;

    public string saveQTE;

    public bool tragedy;
    public int saveP;
    public bool noHurt = true;

    //for articles
    public string fantasy;
    public string milk;
    public string adventureWord;
    public string dragonWord;
    public string romanceWord;
    public string horrorWord1;
    public string horrorWord2;
    public string mysteryWord1;
    public string mysteryWord2;

    //for collections
    public bool e1;
    public bool e2;
    public bool e3;
    public bool e4;
    public bool e5;
    public bool e6;
    public bool e7;

    public bool b1;
    public bool b2;
    public bool b3;
    public bool b4;

    private void Awake()
    {
        ResetAll();
        currentArticle = "";
        state = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetAll()
    {
        adventure = false;
        romance = false;
        horror = false;
        mystery = false;


    }
}
