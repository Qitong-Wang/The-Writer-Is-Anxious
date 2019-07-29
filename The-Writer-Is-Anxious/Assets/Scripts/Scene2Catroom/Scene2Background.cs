using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene2Background : MonoBehaviour
{
    public List<string> sentences;
    int sentenceCount;
    public int sentenceCurrentIndex = 0;
    public GameObject[] objSentences;
    public GameObject prefabSentence;
    public Canvas canvas;
    public float waitTime;
    bool ableClick = true;
    public GameObject objScene2Manager;
    public GameObject objBackground;
    public GameObject backgroundMask;
    public GameObject objCatroom;
    public GameObject objArrow;
    public GameObject objWhiteBG;
 
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
                ableClick = false;
                StartCoroutine(Animate());
                
                
            }
        }
    }

    IEnumerator Animate()
    {

        if (sentenceCurrentIndex != 0 && sentenceCurrentIndex<= sentenceCount)
        {
            //Let last sentence disappear
           
            objSentences[sentenceCurrentIndex - 1].GetComponent<Animator>().SetTrigger("End");
            
            
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
        if (sentenceCurrentIndex != 0 && sentenceCurrentIndex <= sentenceCount)
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
            StartCoroutine(FadeTo(0f, 1.0f));
            yield return new WaitForSeconds(1f);
            objScene2Manager.SetActive(true);
            objBackground.SetActive(false);
            objCatroom.SetActive(true);
            objArrow.SetActive(true);
            objWhiteBG.SetActive(true);
            backgroundMask.SetActive(false);

        }
        yield return null;
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = backgroundMask.GetComponent<Image>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            backgroundMask.GetComponent<Image>().color = newColor;
            yield return null;
        }
    }
}
