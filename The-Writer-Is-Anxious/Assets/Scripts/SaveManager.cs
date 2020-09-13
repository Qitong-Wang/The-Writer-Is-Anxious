using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [TextArea]
    public string currentArticle;
    public int state;

    public string catRoom;

    private void Awake()
    {
        currentArticle = "";
        state = 0;
        DontDestroyOnLoad(this.gameObject);
    }
}
