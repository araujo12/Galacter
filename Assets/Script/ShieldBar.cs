using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Image shieldbar;   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeShildBar(int shieldA, int shieldMax )
    {
        shieldbar.fillAmount = (float) shieldA / shieldMax;
    }
    
}
