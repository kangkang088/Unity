using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoleInfo", menuName = "ScriptableObjects/RoleInfo", order = 1)]
public class RoleInfo : ScriptableObject
{
    [Serializable]
    public class RoleData
    {
        public int id;
        public string res;
        public int atk;
        public string tips;
        public int lockMoney;
        public int type;
        public string hitEff;
        
        public void ShowInfo()
        {
            Debug.Log($"id: {id}, res: {res}, atk: {atk}, tips: {tips}, lockMoney: {lockMoney}, type: {type}, hitEff: {hitEff}");
        }
    }

    public List<RoleData> roleLists;
}
