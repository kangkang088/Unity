using System.Collections.Generic;
using UnityEngine;

namespace Lesson23_Inspector_数组_List属性自定义显示
{
    public class Lesson23 : MonoBehaviour
    {
        //default draw
        public string[] strs;
        public int[] ints;
        public GameObject[] objs;
        public List<GameObject> objsList;

        //custom draw
        public List<GameObject> customObjsList;
    }
}