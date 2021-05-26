using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyWalkFootstepControl : MonoBehaviour
{
    private AudioSource sound;

    public void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    public void play()
    {
        sound.Stop();
        sound.Play();
    }

    public void pause()
    {
        sound.Stop();
    }
}
