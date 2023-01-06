using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_ShowButton : ActionNode
{
    private GameObject _canvasChoix;
    private InkTest _inkTest;

    protected override void OnStart() {
        _canvasChoix = GameObject.Find("Choix");
        
        if (blackboard._inkTestScript != null)
        {
            _inkTest = blackboard._inkTestScript;
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_canvasChoix && _inkTest != null)
        {
            ShowButton();
            return State.Success;
        }
        else return State.Failure;
    }

    public void ShowButton()
    {
        int childcount = _canvasChoix.transform.childCount;
        for (int i = 0; i < childcount; i++)
        {
            if (_canvasChoix.transform.GetChild(i).gameObject.activeInHierarchy == false)
            {
                _canvasChoix.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if (_inkTest._epreuveButton != null)
        {
            _inkTest._epreuveButton.gameObject.SetActive(false);
        }
    }
}
