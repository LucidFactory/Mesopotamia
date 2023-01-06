using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_EpreuveButtonWasPressed : ActionNode
{
    public bool _buttonWasPressed;
    private InkTest _inkTest;
    protected override void OnStart() {
        _inkTest = blackboard._inkTestScript;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_inkTest != null)
        {
            _inkTest._ButtonWasPressed = _buttonWasPressed;
            return State.Success;
        }
        else return State.Failure;
    }
}
