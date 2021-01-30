using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadackScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        SoundManagerScript.playsound();
    }
}
