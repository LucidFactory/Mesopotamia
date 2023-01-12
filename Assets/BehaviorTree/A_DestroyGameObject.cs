using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_DestroyGameObject : ActionNode
{

    private GameObject _gameObjectToDestroy;

    protected override void OnStart()
    {
        if (blackboard != null)
        {
            _gameObjectToDestroy = blackboard._gameObjectToFind;
        }
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate() 
    {
        if (_gameObjectToDestroy != null)
        {
            Object.Destroy(_gameObjectToDestroy);
            return State.Success;
        }
        else return State.Failure;
    }
}
