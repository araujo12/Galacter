using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public float timerExplosion;  

    void Start()
    {
        timerExplosion = 0f;        
    }

    // Update is called once per frame
    void Update()
    {        
        TimerEnd();
        
    }  
    
    void TimerEnd()
    {
        timerExplosion = timerExplosion + 0.1f;        
        if (timerExplosion >= 10f)
        {            
            Destroy(gameObject);            
        }
    }

    
    
}
