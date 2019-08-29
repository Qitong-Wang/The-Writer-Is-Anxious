using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishAnimation()
    {
        player.coins += 10;
        player.UpdateCoinText();
        Destroy(gameObject);
    }
}
