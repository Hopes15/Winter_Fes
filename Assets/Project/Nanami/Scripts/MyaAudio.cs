using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyaAudio : MonoBehaviour
{
    private AudioSource audioSource = null;
    public AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNeko(int index)
    {
        audioSource.clip = audioClip[index];
        audioSource.PlayOneShot(audioClip[index]);
    }
}
