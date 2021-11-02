using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class CoinScore : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsRemaining;

    public static CoinScore instance; 

    public Collider2D colliderPlayer;
    public Collider2D colliderCoin; 

    private BoxCollider2D boxCollider; 

    // Start is called before the first frame update
    void Awake()
    {
        instance = this; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(colliderPlayer.IsTouching(colliderCoin))
        {

            coins -= 1;

         
        }
    }


    void coinsText()
    {
        coinsRemaining.text = "Remaining: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText();

        if(coins <= 0)
        {
            SceneManager.LoadScene(3); 
        }
     
    }
}
