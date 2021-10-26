using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    public bool isRewinding = false;

    List<Vector3> positions;

    Rigidbody2D rb;

    public static RewindTime instance;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();

        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
           // StaminaBar.instance.isZero = false;

     
        }

        else if (Input.GetKeyUp(KeyCode.R)) 
        {
            StopRewind();
        }
    }

    void FixedUpdate()
    {

        if (isRewinding)
            Rewind(); 


        else
            RecordThing(); 
        
    }

    void Rewind()
    {

        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
            StaminaBar.instance.UseTimeRewind(Time.deltaTime * 20); 
        }

        else
        {
            StopRewind(); 
        }
     
             
    }
    
    

    void RecordThing()
    {
        positions.Insert(0, transform.position); 
    }

    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true; 
    }

   public void StopRewind()
    {

        isRewinding = false;
        rb.isKinematic = false; 
    }

}
