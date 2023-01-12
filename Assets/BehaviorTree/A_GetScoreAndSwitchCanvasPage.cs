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
    private EpreuveScoreManager _epreuveScoreManager;


    protected override void OnStart() 
    {
        _scoreText = GameObject.Find("Score(Clone)");

        if (blackboard._inkTestScript != null)
        {
            _inkTest = blackboard._inkTestScript;
        }

        _epreuveScoreManager = _scoreText.GetComponent<EpreuveScoreManager>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        int etape = _epreuveScoreManager.FinishedStep(blackboard._epreuveScore);
        Debug.Log("je suis à l'étape numéro : " + etape);

        _inkTest.OnClickChoiceButton(_inkTest._story.currentChoices[etape]);
        return State.Success;
    }
}
