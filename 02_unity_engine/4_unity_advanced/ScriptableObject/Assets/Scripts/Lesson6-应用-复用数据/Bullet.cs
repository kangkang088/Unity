using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletInfo bulletInfo;

    private void Start()
    {
        Debug.Log("Bullet created with atk: " + bulletInfo.atk);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (bulletInfo. moveSpeed * Time.deltaTime));
    }
}