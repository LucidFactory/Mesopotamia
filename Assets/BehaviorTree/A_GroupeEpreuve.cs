using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor;
using UnityEditor.TerrainTools;

[System.Serializable]
public class A_GroupeEpreuve : ActionNode
{
    public enum nameList
    {
        Physique,
        Social,
        Mystique,
        Commun
    };
    public nameList _nameList;

    private string[] _string;
    
    protected override void OnStart()
    {
        //if (blackboard._groupeEpreuve != null)
        //{
        //    _string = blackboard._groupeEpreuve.Split("_");
        //}
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (blackboard._groupeEpreuve == _nameList.ToString())
        {
            return State.Success;
        }
        else return State.Failure;
    }
}
