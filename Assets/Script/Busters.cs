using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busters : MonoBehaviour
{
    public float speedBuster, destroyBuster;
    public string player,shield;
    public GameObject busterdSound, busterPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviBuster();
        DestroyBuster();
    }

    private void MoviBuster()
    {
        transform.Translate(Vector3.down * speedBuster * Time.deltaTime);
    }

    private void DestroyBuster()
    {
        destroyBuster = destroyBuster + 0.1f;

        if(destroyBuster >= 500f)
        {
            Destroy(gameObject);
        }        
    }

    public void OnTriggerEnter2D(Collider2D buster)
    {
        

        if (buster.CompareTag(player))
        {    
            Instantiate(busterdSound, buster.transform.position, Quaternion.identity);
            Destroy(gameObject) ;
        }

        if(buster.CompareTag(shield))
        {
            Instantiate(busterdSound, buster.transform.position, Quaternion.identity);
            Destroy(gameObject) ;
        }

        if (buster.CompareTag("Barreira"))
        {
            Destroy(gameObject);
        }

    }

}
