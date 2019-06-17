using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene2Background : MonoBehaviour
{
    public List<string> sentences;
    int sentenceCount;
    int sentenceCurrentIndex = 0;
    public GameObject[] objSentences;
    public GameObject prefabSentence;
    public Canvas canvas;
    public float waitTime;
    bool ableClick = true;
    public GameObject objScene2Manager;
    public GameObject objBackground;
    // Start is called before the first frame update
    void Start()
    {
        sentenceCount = sentences.Count;
        objSentences = new GameObject[sentenceCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ableClick == true)
            {
                StartCoroutine(Animate());
                ableClick = false;
                
            }
        }
    }

    IEnumerator Animate()
    {
        if (sentenceCurrentIndex != 0)
        {
            //Let last sentence disappear
            objSentences[sentenceCurrentIndex-1].GetComponent<Animator>().SetTrigger("End");
            yield return new WaitForSeconds(0.75f);
        }
        if (sentenceCurrentIndex < sentenceCount)
        {
            //Create current sentence
            GameObject sentence = Instantiate(prefabSentence, new Vector3(0, 0, 0), Quaternion.identity);
            sentence.transform.SetParent(canvas.transform, false);
            sentence.GetComponent<Text>().text = sentences[sentenceCurrentIndex];
            objSentences[sentenceCurrentIndex] = sentence;
        }
        //Waiting time and destroy last sentence. Player cannot click.
        if (sentenceCurrentIndex != 0)
        {
            yield return new WaitForSeconds(waitTime - 0.75f);
            objSentences[sentenceCurrentIndex - 1].SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(waitTime);
        }
        //Player is able to click
        ableClick = true;
        sentenceCurrentIndex++;

        if (sentenceCurrentIndex > sentenceCount)
        {
            yield return new WaitForSeconds(1f);
            Camera.main.backgroundColor = Color.white;
            objScene2Manager.SetActive(true);
            objBackground.SetActive(false);
        }
        yield return null;
    }
}
