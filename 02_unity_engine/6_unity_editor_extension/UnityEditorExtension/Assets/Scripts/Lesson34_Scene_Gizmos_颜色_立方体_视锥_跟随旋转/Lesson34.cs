using UnityEngine;

namespace Lesson34_Scene_Gizmos_颜色_立方体_视锥_跟随旋转
{
    public class Lesson34 : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 2);
            Gizmos.DrawFrustum(transform.position, 30f, 100f, 0.5f, 2);

            // Gizmos.matrix = Matrix4x4.TRS(transform.position,transform.rotation,transform.localScale);
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 4);
        }
    }
}