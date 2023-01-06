using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_ShowUI : ActionNode
{
    private GameObject _canvasToShow;

    protected override void OnStart() {
        _canvasToShow = blackboard._canvasToHide;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return ShowUi() ? State.Success : State.Failure;
    }

    protected bool ShowUi()
    {
        // Réafficher de canvas de l'histoire
        if (_canvasToShow != null)
        {
            _canvasToShow.GetComponent<Canvas>();
            _canvasToShow.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }
}
