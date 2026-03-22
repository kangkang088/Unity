using System;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    public AudioPlayBase audioPlayBase;
    
    private AudioSource audioSource;

    private void Start()
    {
        if(audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            audioPlayBase.Play(audioSource);
    }
}
