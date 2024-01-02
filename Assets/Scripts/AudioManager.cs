using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!aud.isPlaying)
        {
            aud.Play();
        }
    }
}
