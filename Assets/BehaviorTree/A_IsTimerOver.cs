using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_IsTimerOver : ActionNode
{
    private bool _timerIsOver;

    protected override void OnStart() 
    {
        _timerIsOver = blackboard._timerIsFinished;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_timerIsOver)
        {
            return State.Success;
        }
        else return State.Failure;
    }
}
