using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomPlay", menuName = "ScriptableObjects/AudioPlay/RandomPlay", order = 1)]
public class RandomPlay : AudioPlayBase
{
    public List<AudioClip> audioClips;
    
    public override void Play(AudioSource source)
    {
        if(audioClips.Count == 0)
            return;
        source.clip = audioClips[Random.Range(0, audioClips.Count)];
        source.Play();
    }
}
