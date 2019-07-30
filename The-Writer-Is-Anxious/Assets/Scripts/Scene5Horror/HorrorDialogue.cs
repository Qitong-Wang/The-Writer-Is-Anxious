using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorrorDialogue : MonoBehaviour
{
    public Text dialogueText;
    public float dialogueDuration;
    float dialogueTime;
    public List<string> normalDialogue;
    public List<string> enemyAlarmDialogue;
    public List<string> princessHurtDialogue;
    public List<string> princessKillDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text!="" && Time.time > dialogueTime + dialogueDuration)
        {
            dialogueText.text = "";
        }
    }
    public void NormalDialogue()
    {
        if (dialogueText.text == "")
        {
            int randomNumber = Random.Range(0, normalDialogue.Count);
            dialogueText.text = normalDialogue[randomNumber];
            dialogueTime = Time.time;
        }
    }
    public void EnemyAlarmDialogue()
    {
        
        int randomNumber = Random.Range(0, enemyAlarmDialogue.Count);
        dialogueText.text = enemyAlarmDialogue[randomNumber];
        dialogueTime = Time.time; 
    }
    public void PrincessHurtDialogue()
    {

        int randomNumber = Random.Range(0, princessHurtDialogue.Count);
        dialogueText.text = princessHurtDialogue[randomNumber];
        dialogueTime = Time.time;
    }
    public void PrincessKillDialogue()
    {

        int randomNumber = Random.Range(0, princessKillDialogue.Count);
        dialogueText.text = princessKillDialogue[randomNumber];
        dialogueTime = Time.time;
    }
}
