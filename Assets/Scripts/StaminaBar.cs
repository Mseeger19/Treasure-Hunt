using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; 

public class StaminaBar : MonoBehaviour
{

    //public Slider timeBar;

    public Text timeBar; 

    private float startingTime = 100.0f;
    private float currentTime;
    public bool isZero = false;

    public static StaminaBar instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    private Coroutine regen; 

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        timeBar = GetComponent<Text>();

        currentTime = startingTime;
        timeBar.text = currentTime.ToString(); 
       
    }

    public void UseTimeRewind(float amount)
    {

        currentTime -= amount;
           

        if(currentTime <= 0)
        {
            currentTime = 0;
            StartCoroutine(RegenTimeBar());
            isZero = true;
            Debug.Log("Not enough");
        }

        timeBar.text = currentTime.ToString("0");




        Debug.Log(currentTime); 

            if(regen != null)
            {
                StopCoroutine(regen); 
            }

          regen = StartCoroutine(RegenTimeBar()); 
        }

       
    

    private IEnumerator RegenTimeBar()
    {
        yield return new WaitForSeconds(2);

        while(currentTime < startingTime)
        {
            currentTime += startingTime / 100;
            timeBar.text = currentTime.ToString("0");
            if (currentTime > 100) currentTime = 100;
            yield return regenTick; 
        }

        regen = null; 
    }

    
}
