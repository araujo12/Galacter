using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
