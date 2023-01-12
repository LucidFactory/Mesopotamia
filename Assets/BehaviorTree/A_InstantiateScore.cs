using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_InstantiateScore : ActionNode
{
    public GameObject _scoreTextPrefab;

    private string[] _string;
    private GameObject _scoreText;
    private Transform _canvasParent;

    protected override void OnStart() 
    {
        //if (blackboard._groupeEpreuve != null)
        //{
        //    _string = blackboard._groupeEpreuve.Split("_");
        //}
        _canvasParent = GameObject.Find("CanvasTimerAndScore").transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        _scoreText = GameObject.Instantiate(_scoreTextPrefab, _canvasParent);

        if (_scoreText != null)
        {
            _scoreText.GetComponent<EpreuveScoreManager>().InitializeScoreToObtain(blackboard._epreuveScore[0]);
            return State.Success;
        }
        else return State.Failure;
    }
}
