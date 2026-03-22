using UnityEngine;

[CreateAssetMenu(fileName = "SurePlay", menuName = "ScriptableObjects/AudioPlay/SurePlay", order = 1)]
public class SurePlay : AudioPlayBase
{
    public AudioClip audioClip;
    
    public override void Play(AudioSource source)
    {
        source.clip = audioClip;
        source.Play();
    }
}
