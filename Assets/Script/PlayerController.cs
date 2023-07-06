using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer, intervalShoot;
    public int shieldEnergy, shieldEnergyMax = 100;
    public string targetName, busterShield;
    public GameObject spawnShoot, bulletPlayer, shiedPlayer, bulletEnemy, playerPosition, playerExplosion, gameOverObj;
    public ShieldBar shieldBar;
    public AudioSource audioSource;
    public AudioClip shootPlayer;
    public Event evento;
    
    public static bool playerDead;
    public static bool endGame;

    void Start()
    {
        intervalShoot = 0;
        shieldEnergy = shieldEnergyMax;
        shiedPlayer.gameObject.SetActive(true);
        shieldBar.ChangeShildBar(shieldEnergy, shieldEnergyMax);
        gameOverObj.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();   
        Interval();
        PlayerExplosion();
    }

    void MovePlayer()
    {        
        var x = Input.GetAxisRaw("Horizontal") * speedPlayer * Time.deltaTime;
        var y = Input.GetAxisRaw("Vertical") * speedPlayer * Time.deltaTime;
        
        transform.Translate(x, y, 0);      
    }

    void Interval()
    {
        intervalShoot += Time.deltaTime;
        if(intervalShoot >= 0.2f)
        {
            intervalShoot = 0;
            ShootPlayer();
        }        
    }

    void ShootPlayer()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bulletPlayer, spawnShoot.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shootPlayer);
        }
    }

    public void PlayerExplosion()
    {
        if(playerDead == true)
        {
            Instantiate(playerExplosion, playerPosition.transform.position, Quaternion.identity);
            playerDead = false;
            gameObject.SetActive(false);
            gameOverObj.SetActive(true);
            endGame = true;        

        }
               
    }

    public void OnTriggerEnter2D(Collider2D shield)
    {
        if (shield.CompareTag(targetName))
        {
            shieldEnergy -= 10;
            shieldBar.ChangeShildBar(shieldEnergy, shieldEnergyMax);

            if (shieldEnergy <= 0)
            {
                shiedPlayer.gameObject.SetActive(false);
            }
        }

        if (shield.CompareTag(busterShield))
        {
            
            if(shieldEnergy < shieldEnergyMax)
            {
                shieldEnergy += 10;
                shiedPlayer.gameObject.SetActive(true);
                shieldBar.ChangeShildBar(shieldEnergy, shieldEnergyMax);
            }            
        }
        
        
    }

    

}
