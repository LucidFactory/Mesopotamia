using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpreuveCombatManager : MonoBehaviour
{
    public float _timerBeforeSpawningNextTarget;

    public GameObject _targetPrefab;

    private float _randomXPos;
    private float _randomYPos;

    // Start is called before the first frame update
    void Start()
    {
        GetRandomNumber();
        GameObject target = Instantiate(_targetPrefab, new Vector3(_randomXPos, _randomYPos, 0), Quaternion.identity);

        StartCoroutine(InstantiateTargetCoroutine());
    }

    IEnumerator InstantiateTargetCoroutine()
    {
        yield return new WaitForSeconds(_timerBeforeSpawningNextTarget);
        InstantiateTarget();
    }

    public void InstantiateTarget()
    {
        GetRandomNumber();
        GameObject target = Instantiate(_targetPrefab, new Vector3(_randomXPos, _randomYPos, 0), Quaternion.identity);

        float test = Random.Range(0, 3);
        target.transform.localScale = new Vector3(test,test,0);
    }
    private void GetRandomNumber()
    {
        _randomXPos = Random.Range(-9f, 9f);
        _randomYPos = Random.Range(-3.5f, 3.5f);
    }
}
