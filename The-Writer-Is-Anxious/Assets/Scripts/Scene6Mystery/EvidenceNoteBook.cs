using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Everything is initialized in EvidenceBarControl.cs
/// </summary>
public class EvidenceNoteBook : MonoBehaviour
{
    public Text evidenceText;
    /// <summary>
    /// 0:Gunfire 1: News 2:Cap Boy 3: Blood 4: Immunity 5: (Back)
    /// </summary>
    public int evidenceIndex;
    public GameObject objEvidenceNoteBook;
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
        switch (evidenceIndex)
        {
            case 0:
                evidenceText.text = "You heard a gunfire in the smoke. It was a huge noise. No one could miss it.";
                break;
            case 1:
                evidenceText.text = "That is a newspaper with research reporting that the surrounding areas of safe houses were proved to be safe and zombie-free. Reasons to this phenomenon remained a mystery.";
                break;
            case 2:
                evidenceText.text = "He lied straight, face down to the ground. A lot of zombies surround him. It's even hard to recognize his face. He didn't seem to have brought any weapons with him.";
                break;
            case 3:
                evidenceText.text = "The blood is very fresh. Whose blood can it possibly be?";
                break;
            case 4:
                evidenceText.text = "As Man remembered, Cap Boy was bit once but didn’t transform. He said he was immune to the zombie virus.";
                break;
            case 5:
                objEvidenceNoteBook.SetActive(false);
                break;
        }
    }
}
