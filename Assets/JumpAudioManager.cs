using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAudioManager : MonoBehaviour
{
    public class AudioClip jumpsound;
    static AudioSource audioSrc;

    void Start()
    {
        jumpsound = Resources.Load<AudioClip> ("jumpdbz");
        audioSrc =  GetComponent <AudioSource> ();
    }
    public static viod playSound()
    {
        audioSrc.PlayOneShot(jumpsound);
    }
}
