using System;
using UnityEngine;

namespace Lesson33_Scene_Gizmos公共类
{
    public class Lesson33 : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Debug.Log("OnDrawGizmos");
        }

        private void OnDrawGizmosSelected()
        {
            Debug.Log("OnDrawGizmosSelected");
        }
    }
}