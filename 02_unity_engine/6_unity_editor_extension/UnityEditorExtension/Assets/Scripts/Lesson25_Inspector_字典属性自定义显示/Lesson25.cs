using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson25_Inspector_字典属性自定义显示
{
    public class Lesson25 : MonoBehaviour, ISerializationCallbackReceiver
    {
        public Dictionary<int, string> dic = new() { { 1, "123" }, { 2, "234" } };

        [SerializeField] private List<int> keys = new();
        [SerializeField] private List<string> values = new();

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var item in dic)
            {
                keys.Add(item.Key);
                values.Add(item.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            dic.Clear();

            for (var i = 0; i < keys.Count; i++)
            {
                if (!dic.ContainsKey(keys[i]))
                    dic.Add(keys[i], values[i]);
                else
                    Debug.LogWarning("Dictionary key had repeated!!!");
            }
        }

        private void Start()
        {
            foreach (var item in dic)
            {
                Debug.Log("Key: " + item.Key + " | Value: " + item.Value);
            }
        }
    }
}