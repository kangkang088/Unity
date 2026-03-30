using UnityEngine;

namespace Lesson35_Scene_Gizmos_贴图_图标
{
    public class Lesson35 : MonoBehaviour
    {
        public Texture texture;

        private void OnDrawGizmos()
        {
            if (texture)
                Gizmos.DrawGUITexture(new Rect(0, 0, -16, -9), texture);

            Gizmos.DrawIcon(transform.position, "icon");
        }
    }
}