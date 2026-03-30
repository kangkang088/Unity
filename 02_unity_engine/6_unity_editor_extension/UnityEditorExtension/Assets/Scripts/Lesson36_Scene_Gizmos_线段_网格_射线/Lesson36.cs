using System;
using UnityEngine;

namespace Lesson36_Scene_Gizmos_线段_网格_射线
{
    public class Lesson36 : MonoBehaviour
    {
        public Mesh mesh;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.right * 2);

            Gizmos.color = Color.yellow;
            if (mesh)
                Gizmos.DrawMesh(mesh, transform.position, transform.rotation, Vector3.one);

            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(transform.position, transform.forward * 2);
        }
    }
}