using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Blullet : MonoBehaviour
{
    public float speedBullet, destroyBullet, destroyTarget;
    public string shieldTag, targetpoint, tagBoss, tagShieldEnemy,playerTag,enemyTag;
    public SpriteRenderer spriteRenderer;
    
    public PlayerController playerController;

    void Start()
    {
        destroyBullet = 0f;
        destroyTarget = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
        DestroyBullet();
        
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.down * speedBullet * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        destroyBullet = destroyBullet + 0.1f;        

        if (destroyBullet >= 100f)
        {
            Destroy(gameObject);           
        }
    }

    public void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.CompareTag(enemyTag))
        {
            
            Destroy(bullet.gameObject);           
            Destroy(gameObject);         
        }
        else
        {
            if (bullet.CompareTag(shieldTag))
            {
                Destroy(gameObject) ;
            }
        }

        if (bullet.CompareTag(playerTag))
        {            
            Destroy(gameObject);
            PlayerController.playerDead = true;
        }

        if (bullet.CompareTag("Barreira"))
        {
            Destroy(gameObject);
        }

        if (bullet.CompareTag(tagBoss))
        {
            Destroy(gameObject);            
        }

        if (bullet.CompareTag(tagShieldEnemy))
        {
            spriteRenderer.gameObject.SetActive(false);
        }
    }   
     
}
