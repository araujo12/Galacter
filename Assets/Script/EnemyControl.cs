using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speedEnemy, speedEnemyMin, speedEnemyMax, intervalShoot;    
    public Transform target;
    public bool enemyGuide, shootAble, dead;
    public GameObject shootEnemy, shootSpawn, enemyPosition, explosionEnemy;
    public string bullet;
    public AudioSource audioSouce;
    public AudioClip shoot;    
    void Start()
    {
        intervalShoot = 0;
        speedEnemy = Random.Range(speedEnemyMin, speedEnemyMax);        
        dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        MoviEnemy();
        IntervalShoot();
        
    }

    void MoviEnemy()
    {

        if (enemyGuide == true)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speedEnemy * Time.deltaTime;
        }

        else
        {
            transform.Translate(Vector3.down * speedEnemy * Time.deltaTime);
        }


    }

    private void IntervalShoot()
    {
        intervalShoot += Time.deltaTime;
        if (intervalShoot >= 2)
        {
            ShootEnemy();
            intervalShoot = 0;
        }

    }

    public void ShootEnemy()
    {
        if (shootAble == true)
        {
            Instantiate(shootEnemy, shootSpawn.transform.position, Quaternion.identity);
            audioSouce.PlayOneShot(shoot);
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyBD)
    {
        if (enemyBD.CompareTag(bullet))
        {
            EnemyExplosion();
            ScoreGame.destroyed = true;
        }
    }
    void EnemyExplosion()
    {        
        Instantiate(explosionEnemy, enemyPosition.transform.position, Quaternion.identity);        
    }
}