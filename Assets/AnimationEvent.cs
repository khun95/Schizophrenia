using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource[] audioSource;
    private AudioSource[] audioSources1;
    private AudioSource audioSources2;
    void Start()
    {
        audioSource = GameObject.Find("DoorSoundManager").GetComponents<AudioSource>();
        audioSources1 = GameObject.Find("BoxSlideSoundManager").GetComponents<AudioSource>();
        audioSources2 = GameObject.Find("SwitchSoundManager").GetComponent<AudioSource>();
        
    }
    public void SwitchAudioPlay()
    {
        audioSources2.Play();
    }
    public void AudioPlayOpen()
    {
        audioSource[0].Play();
    }
    public void AudioPlayClose ()
    {
        audioSource[1].Play();
    }
    public void BoxAudioPlayOpen()
    {
        audioSources1[0].Play();
    }
    public void BoxAudioPlayClose()
    {
        audioSources1[1].Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
