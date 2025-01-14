using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource = null;
    public AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "SCENE_GAME") 
            PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(int index)
    {
        audioSource.clip = audioClip[index];
        audioSource.PlayOneShot(audioClip[index]);
    }

    public void PlaySE(int index)
    {
        audioSource.clip = audioClip[index];
        audioSource.PlayOneShot(audioClip[index]);
    }
}
