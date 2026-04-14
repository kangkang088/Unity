using UnityEngine;

namespace _2Shader开发知识.Lesson83_高级纹理_渲染纹理_镜面效果_效果实现
{
    public class Lesson83 : MonoBehaviour
    {
        private void Start()
        {
            #region 知识点 实现镜面效果Shader
            //1.新建Shader，复制 Lesson48 单张纹理_纹理颜色显示Shader
            //2.在顶点着色器中，让UV坐标的X轴反向（坐标范围0~1，想要反向直接用 1 - uv.x 即可
            //3.将渲染纹理应用到该Shader的纹理中
            #endregion
        }
    }
}
