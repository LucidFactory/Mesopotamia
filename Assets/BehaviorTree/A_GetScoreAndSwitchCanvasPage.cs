using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;

[System.Serializable]
public class A_GetScoreAndSwitchCanvasPage : ActionNode
{
    private GameObject _scoreText;
    private int _scoreToReach;
    private InkTest _inkTest;
    private string[] _string;


    protected override void OnStart() 
    {
        _scoreText = GameObject.Find("Score(Clone)");

        if (blackboard._inkTestScript != null)
        {
            _inkTest = blackboard._inkTestScript;
        }

        if (blackboard._groupeEpreuve != null)
        {
            _string = blackboard._groupeEpreuve.Split("_");
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        float Score = _scoreText.GetComponent<EpreuveScoreManager>()._score;
        _scoreToReach = int.Parse(_string[3]);

        if (Score >= _scoreToReach)
        {
            _inkTest.OnClickChoiceButton(_inkTest._story.currentChoices[0]);
            return State.Success;
        }
        else
        {
            _inkTest.OnClickChoiceButton(_inkTest._story.currentChoices[1]);
            return State.Failure;
        }
    }
}
