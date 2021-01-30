using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class JumpSound : MonoBehaviour
{
    public AudioSource jumpSound;
 
    void Start()
    {
 
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
        }
    }
}