using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public AudioSource sound;
    public Animator doorAnimator;
    private bool doorOpen;

    private void Update()
    {
        doorAnimator.SetBool("In Range", doorOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        doorOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        doorOpen = false;
    }
}
