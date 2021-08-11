using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playAudio();
        }
    }

    public void playAudio()
    {
        sound.Play();
    }

    
}
