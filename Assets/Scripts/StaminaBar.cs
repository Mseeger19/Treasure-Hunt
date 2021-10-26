using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour
{

    public Slider timeBar; 

    private float maxTime = 100;
    private float currentTime; 
   // public bool isZero = false;

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

        currentTime = maxTime;
        timeBar.maxValue = maxTime;
        timeBar.value = maxTime; 
       
       
    }

    public void UseTimeRewind(float amount)
    {

        if (currentTime - amount >= 0)
        {
            currentTime -= amount;
            timeBar.value = currentTime;


            if (regen != null)
            
                StopCoroutine(regen);

                regen = StartCoroutine(RegenTimeBar());

        }
       
        else
        {
            Debug.Log("Not enough time");
            RewindTime.instance.StopRewind(); 
        }


        
        }

    private IEnumerator RegenTimeBar()
    {
        yield return new WaitForSeconds(4);

        while(currentTime < maxTime)
        {
            currentTime += maxTime / 100;
            timeBar.value = currentTime; 
            yield return regenTick; 
        }

        regen = null; 
    }

    
}
