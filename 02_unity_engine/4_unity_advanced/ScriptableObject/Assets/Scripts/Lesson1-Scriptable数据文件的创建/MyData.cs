using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "MyData", menuName = "ScriptableObjects/MyData", order = 1)]
public class MyData : ScriptableObject
{
    public int id;
    public string playerName;
    public int age;
    public GameObject prefab;
    public Material material;
    public AudioClip audioClip;
    public VideoClip videoClip;
}
