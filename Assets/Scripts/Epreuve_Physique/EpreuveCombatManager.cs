using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;

public class EpreuveCombatManager : MonoBehaviour
{
    public float _timer;
    public float _timeBeforeSpawningNextTarget;

    public GameObject _targetPrefab;

    private float _randomXPos;
    private float _randomYPos;
    //private bool _spawnTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        _timeBeforeSpawningNextTarget = _timer;
        GetRandomNumber();

        StartCoroutine(InstantiateTargetCoroutine(_timeBeforeSpawningNextTarget));
    }
    private void GetRandomNumber()
    {
        _randomXPos = Random.Range(-9f, 9f);
        _randomYPos = Random.Range(-3.5f, 3.5f);
    }

    public IEnumerator InstantiateTargetCoroutine(float timer)
    {
        Debug.Log("Start coroutine");

        InstantiateTarget();
        yield return new WaitForSeconds(timer);
        StartCoroutine(InstantiateTargetCoroutine(timer));
        //_spawnTarget = true;
    }

    public void InstantiateTarget()
    {
        GetRandomNumber();
        GameObject target = Instantiate(_targetPrefab, new Vector3(_randomXPos, _randomYPos, 0), Quaternion.identity);

        float localScale = Random.Range(1, 3);
        target.transform.localScale = new Vector3(localScale,localScale,0);
    }


    private void Update()
    {
        //_timeBeforeSpawningNextTarget -= Time.deltaTime;

        //if (_timeBeforeSpawningNextTarget <= 0)
        //{
        //    StartCoroutine(InstantiateTargetCoroutine(0.1f));
        //    _timeBeforeSpawningNextTarget = _timer;
        //}

        //if (_spawnTarget)
        //{
        //    Debug.Log("hello");
        //    InstantiateTarget();
        //    _spawnTarget = false;
        //}
    }
}
