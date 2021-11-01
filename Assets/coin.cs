using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    //public GameObject endScreen; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
            CoinScore.instance.coins -= 1;
            FindObjectOfType<audioManager>().Play("Coin");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
