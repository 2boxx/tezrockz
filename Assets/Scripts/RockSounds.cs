using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RockSounds : MonoBehaviour
{
      public AudioClip hitSound;
     AudioSource _audioSource;
     Rigidbody2D _rb;

     private void Awake()
     {
         _audioSource = GetComponent<AudioSource>();
         _rb = GetComponent<Rigidbody2D>();
     }


     public void ReproduceSound()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.clip = hitSound;
         _audioSource.pitch = Random.Range(0.9f, 1.1f);
         _audioSource.volume = Mathf.Clamp01(_rb.velocity.magnitude/ 20);
         _audioSource.Play();
     }

     private void OnCollisionEnter2D(Collision2D other)
     {
         ReproduceSound();

     }

}
