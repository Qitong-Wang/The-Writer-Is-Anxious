using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player script in Scene3Adventure
/// </summary>
public class Player_Boss : MonoBehaviour
{
    
    public GameObject gameOverCanvas;
    public GameOverManager gameOverManager;
    public Text coinsText;
    public Text hpText;
    public int coins;
    public int hp;
  

    // Start is called before the first frame update
    void Start()
    {
      
        //UpdateCoinText();
        //UpdateHPText();

    }

    // Update is called once per frame
   
   
  
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOverManager.PauseGame();
    }
  
    public void UpdateCoinText()
    {
        coinsText.text = "Coins:" + coins;
    }
    public void UpdateHPText()
    {
        hpText.text = "HP:" + hp;
    }
    public void DecreaseHP()
    {
         hp -= 1;
         UpdateHPText();
        
        if (hp <= 0)
        {
            GameOver();
        }
    }
}
