using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speedBoss, intervalShoot, endEspecial, timerShield, timerSpawnEnemy, timerSpawnEnemyEnd, timerEspecial;
    public GameObject pointA, pointB, pointC, spawnBoss,bulletBoss,spawnShootA,spawmShootB,especialA, 
                      especialB, especialC, especialD, especialE, especialBoss, shieldBoss, spawnEnemy, bossBD, explosionBoss;

    public Transform bossPosition;
    public int lifeBoss, lifeBossMax = 500, lifeShield, lifeShieldMax = 100;
    public bool shootCO, shootES;
    public AudioSource audioSource;
    public AudioClip shootClip, especialClip;

    private Vector2 postAT;
    public static bool bossDead;

    void Start()
    {
        postAT = spawnBoss.transform.position;
        shootCO = false;
        shootES = false;

        lifeBoss = lifeBossMax;
        lifeShield = lifeShieldMax;
        spawnEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoviBoss();
        ShootBoss();
        ShieldOFF();
        BossSecondFase();
    }
    

    void MoviBoss()
    {
        if(transform.position == pointA.transform.position)
        {
            postAT = pointB.transform.position;
        }

        if(transform.position == pointB.transform.position)
        {
            postAT = pointA.transform.position;
        }

        if(transform.position == spawnBoss.transform.position)
        {
            postAT = pointC.transform.position;
            
        }
        if (transform.position == pointC.transform.position)
        {
            postAT = pointA.transform.position;
            shootCO = true;
            pointC.SetActive(false);
        }

        transform.position = Vector2.MoveTowards(transform.position, postAT, speedBoss * Time.deltaTime);
    }
    

    public void ShootBoss()
    {
        if(shootCO == true)
        {
            intervalShoot += Time.deltaTime;
            if(intervalShoot >= 1)
            {
                Instantiate(bulletBoss, spawnShootA.transform.position, Quaternion.identity);
                Instantiate(bulletBoss, spawmShootB.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(shootClip);
                intervalShoot = 0;
            }            
        }
        
        if(shootES == true)
        {
            shootCO = false;
            intervalShoot += Time.deltaTime;
            endEspecial += Time.deltaTime;
            if (intervalShoot >= 0.5)
            {
                Instantiate(especialBoss, especialA.transform.position, Quaternion.identity);
                Instantiate(especialBoss, especialB.transform.position, Quaternion.identity);
                Instantiate(especialBoss, especialC.transform.position, Quaternion.identity);
                Instantiate(especialBoss, especialD.transform.position, Quaternion.identity);
                Instantiate(especialBoss, especialE.transform.position, Quaternion.identity);                

                if(endEspecial >= 2)
                {
                    shootES = false;
                    shootCO = true;
                    endEspecial = 0;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D boss)
    {
        if (boss.CompareTag("Bullet"))
        {
            lifeShield -= 1;

           if(lifeShield <= 0)
            {   
                lifeBoss -= 1;
                shieldBoss.gameObject.SetActive(false);                
            }
        }
    }

    void ShieldOFF()
    {        
        if(lifeShield <= 0)
        {
            timerEspecial += Time.deltaTime;
            if(timerEspecial >= 10)
            {
                shootES = true;
                audioSource.PlayOneShot(especialClip);
                timerEspecial = 0;                
            }

            timerShield += Time.deltaTime;
            if (timerShield >= 25)
            {
                lifeShield = lifeShieldMax;
                timerShield = 0;
                shieldBoss.gameObject.SetActive(true);
            }
        }
    }

    void BossSecondFase()
    {
        if(lifeBoss <= 250)
        {
            timerSpawnEnemy += Time.deltaTime;
            if(timerSpawnEnemy >= 25)
            {
                spawnEnemy.gameObject.SetActive(true);                
            }

            timerSpawnEnemyEnd += Time.deltaTime;
            if (timerSpawnEnemyEnd >= 30)
            {
                spawnEnemy.gameObject.SetActive(false);
                timerSpawnEnemyEnd = 0;
                timerSpawnEnemy = 0;
            }
        }

        if(lifeBoss <= 0)
        {
            Instantiate(explosionBoss, bossPosition.transform.position, Quaternion.identity);
            bossDead = true;
            bossBD.SetActive(false);
            
        }
    }




}
