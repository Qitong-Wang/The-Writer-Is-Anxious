using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceBarControl : MonoBehaviour
{
    
    /// <summary>
    /// 0: SceneButton. Click to open EvidenceBar. 1: Click to close EvidenceBar. 2: Click to Show EvidenceNotebook
    /// </summary>
    public int evidenceIndex;
    public Scene6Manager scene6Manager;
    public GameObject objEvidenceNoteBook;
    public GameObject[] objEvidenceNotebookTag;
    public GameObject objEvidenceBar;
    public GameObject objSceneEvidenceBar;
    public Text evidenceNoteBookText;
    
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
                objEvidenceNoteBook.SetActive(false);
                objSceneEvidenceBar.SetActive(false);
                objEvidenceBar.SetActive(true);
                break;
            case 1:
                objSceneEvidenceBar.SetActive(true);
                objEvidenceNoteBook.SetActive(false);
                objEvidenceBar.SetActive(false);
                break;
            case 2:
                evidenceNoteBookText.text = "";
                objEvidenceNoteBook.SetActive(true);
                CheckEvidence();
                break;
        }
    }

    private void CheckEvidence()
    {
       
        for (int i =0; i < scene6Manager.evidenceUnlock.Length; i++)
        {
            if (scene6Manager.evidenceUnlock[i] == true)
            {
                objEvidenceNotebookTag[i].SetActive(true);
            }
            else
            {
                objEvidenceNotebookTag[i].SetActive(false);
            }
        }
    }
}
