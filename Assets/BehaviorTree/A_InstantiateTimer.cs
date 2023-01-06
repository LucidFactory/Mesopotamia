using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_InstantiateTimer : ActionNode
{
    public GameObject _timerTextPrefab;
    private Transform _canvasParent;

    private string[] _string;
    private GameObject _timerText;

    protected override void OnStart()
    {
        if (blackboard._groupeEpreuve != null)
        {
            _string = blackboard._groupeEpreuve.Split("_");
        }
        _canvasParent = GameObject.Find("CanvasTimerAndScore").transform;
    }
 
    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        int num = int.Parse(_string[2]);

        _timerText = GameObject.Instantiate(_timerTextPrefab, _canvasParent);
        _timerText.GetComponent<EpreuveTimerManager>().InitializeTimer(num);

        if (_timerText != null)
        {
            return State.Success;
        }
        else return State.Failure;
    }
}
