using System;
using UnityEngine;

namespace Lesson37_Scene_Gizmos_球体_网格线
{
    public class Lesson37 : MonoBehaviour
    {
        public Mesh mesh;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 2);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 4);

            Gizmos.color = Color.blue;
            if (mesh)
                Gizmos.DrawWireMesh(mesh, transform.position, transform.rotation, Vector3.one);
        }
    }
}