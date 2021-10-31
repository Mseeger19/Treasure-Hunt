using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;

    private float maxHealth = 100;
    private float currentHealth;
    // public bool isZero = false;

    public static HealthBar instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    private Coroutine regen;

    PlayerController script; 

    private void Awake()
    {
        instance = this;

        script = FindObjectOfType<PlayerController>(); 
    }

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeHealth(float amount)
    {

        if (script.isHit == true)
        {
            currentHealth -= amount;
            healthBar.value = currentHealth;


            if (regen != null)

                StopCoroutine(regen);

            regen = StartCoroutine(RegenHealthBar());

        }

        else
        {
        
        }

    }

    public IEnumerator RegenHealthBar()
    {
        yield return new WaitForSeconds(4);

        while (currentHealth < maxHealth)
        {
            currentHealth += maxHealth / 100;
            healthBar.value = currentHealth;
            yield return regenTick;
        }

        regen = null;
    }


}
