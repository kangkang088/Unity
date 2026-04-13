using UnityEngine;

namespace _2Shader开发知识.Lesson82_高级纹理_渲染纹理_镜面效果_原理和准备工作
{
    public class Lesson82 : MonoBehaviour
    {
        private void Start()
        {
            #region 知识点一 镜面效果原理

            //镜面效果的原理
            //就是将摄像机看到的画面渲染到渲染纹理当中
            //再在Shader中利用该渲染纹理进行翻转渲染即可

            #endregion

            #region 知识点二 镜面效果准备工作

            //1.创建测试场景
            //2.创建一个摄像机用来得到镜子看到的画面
            //3.创建Custom Render Texture 将其和摄像机关联

            #endregion

            #region 知识点三 自定义渲染纹理参数

            //Xmind

            #endregion
        }
    }
}