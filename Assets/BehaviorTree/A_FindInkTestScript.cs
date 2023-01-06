using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_FindInkTestScript : ActionNode
{
    public string _gameObjectName;
    protected GameObject _inkTestGameObject;
    protected InkTest _inkTest;

    protected override void OnStart() {
        _inkTestGameObject = GameObject.Find(_gameObjectName);
        _inkTest = _inkTestGameObject.GetComponent<InkTest>();
    }
    
    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_inkTest != null)
        {
            blackboard._inkTestScript = _inkTest;
            return State.Success;
        }
        else return State.Failure;
    }
}
