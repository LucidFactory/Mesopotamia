using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_InstantiateEpreuveCombatManager : ActionNode
{
    public GameObject _prefabEpreuveCombatManager;

    private GameObject _epreuveCombatManager;

    protected override void OnStart() {
        _epreuveCombatManager = GameObject.Instantiate(_prefabEpreuveCombatManager, new Vector3(0, 0, 0), Quaternion.identity);
        _epreuveCombatManager.GetComponent<EpreuveCombatManager>()._timer = 4.0f;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (_epreuveCombatManager != null)
        {
            return State.Success;
        }
        else return State.Failure;
    }
}
