using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_HideUI : ActionNode
{
    private GameObject _canvasToHide;

    protected override void OnStart() {
        _canvasToHide = blackboard._canvasToHide;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return HideUI() ? State.Success : State.Failure;
    }

    protected bool HideUI()
    {
        //Cache le canvas contenant l'histoire
        if (_canvasToHide != null)
        {
            _canvasToHide.GetComponent<Canvas>();
            _canvasToHide.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }
}
