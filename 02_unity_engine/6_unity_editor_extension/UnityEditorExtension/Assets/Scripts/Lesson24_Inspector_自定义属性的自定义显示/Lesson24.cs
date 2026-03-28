using System;
using UnityEngine;

namespace Lesson24_Inspector_自定义属性的自定义显示
{
    public class Lesson24 : MonoBehaviour
    {
        public CustomProperty customProperty;
    }

    [Serializable]
    public class CustomProperty
    {
        public int i;
        public float f;
    }
}