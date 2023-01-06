using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_FindGameObjectByName : ActionNode
{
    public string _gameObjectName;

    private GameObject _gameObjectFound;

    protected override void OnStart() {
        _gameObjectFound = GameObject.Find(_gameObjectName);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_gameObjectFound != null)
        {
            blackboard._gameObjectToFind = _gameObjectFound;
            return State.Success;
        }
        else return State.Failure;
    }
}
