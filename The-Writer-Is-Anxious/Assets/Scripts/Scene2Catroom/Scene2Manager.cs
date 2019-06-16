using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Scene2Manager : NormalSceneManager
{

    /// <summary>
    /// Default is 0, at dialogueText. 1 is at Idialogue. 2 is at editorDialogue. 3 is at sadDialogue
    /// </summary>
    int dialogueType = 0;
    Dictionary<string, int> dialogueIndexDictionary;
    


    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<string>();
        textAsset = Resources.Load("Scene2Start") as TextAsset;
        ReadTextFile();
        dialogueIndexDictionary = new Dictionary<string, int>();
    }
    public override void ReadTextFile()
    {
        dialogueList = textAsset.text.Split('\n').ToList();
        for (int i = 0; i < dialogueList.Count; i++)
        {
            if (dialogueList[i][0] == '#')
            {
                
            }
        }
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //Begin memory
       
        //End memory. Begin Sad

    }

    public override void NextStep()
    {
       
    }

    public override void StepAction()
    {

       

    }


    public override Text GetSuitableText()
    {
        return null;
    }



}
