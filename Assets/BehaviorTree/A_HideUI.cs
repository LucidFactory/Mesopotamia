using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_HideUI : ActionNode
{
    public GameObject _canvasToHide;

    protected override void OnStart() {
        _canvasToHide = blackboard._canvasToHide;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        HideUI();
        return State.Success;
    }

    private void HideUI()
    {
        //Cache le canvas contenant l'histoire
        if (_canvasToHide != null)
        {
            _canvasToHide.GetComponent<Canvas>();
            _canvasToHide.gameObject.SetActive(false);
        }
    }
}
