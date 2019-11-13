using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollide : MonoBehaviour
{
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myAudioSource.Play();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAudioSource.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
