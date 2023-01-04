using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_FindCanvas : ActionNode
{
    public string _canvasName;
    protected GameObject _canvasToHide;

    protected override void OnStart() {
        _canvasToHide = GameObject.Find(_canvasName);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_canvasToHide != null)
        {
            blackboard._canvasToHide = _canvasToHide;
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
