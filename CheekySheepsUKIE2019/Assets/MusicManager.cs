using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = FindObjectOfType<AudioSource>();
        AudioSource.loop = false;
    }

    private AudioClip RandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        if(!AudioSource.isPlaying)
        {
            AudioSource.clip = RandomClip();
            AudioSource.Play();
        }
    }
}
