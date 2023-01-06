using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_EpreuveType : ActionNode
{
    public enum nameList
    {
        Athlétisme,
        Combat,
        ForceBrute,
        Persuasion,
        Mensonge,
        Marchandage,
        Exorcisme,
        Purification,
        PerceptionVisuelle,
        PerceptionAuditive
    };
    public nameList _nameList;

    private string[] _string;

    protected override void OnStart()
    {
        if (blackboard._groupeEpreuve != null)
        {
            _string = blackboard._groupeEpreuve.Split("_");
        }
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (_string[1] == _nameList.ToString())
        {
            return State.Success;
        }
        else return State.Failure;
    }
}
