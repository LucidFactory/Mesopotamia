using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EpreuveCombatManager : MonoBehaviour
{
    public float _timer;
    public float _timerBeforeSpawningNextTarget;

    public GameObject _targetPrefab;

    private float _randomXPos;
    private float _randomYPos;

    // Start is called before the first frame update
    void Start()
    {
        _timerBeforeSpawningNextTarget = _timer;
        GetRandomNumber();
        GameObject target = Instantiate(_targetPrefab, new Vector3(_randomXPos, _randomYPos, 0), Quaternion.identity);
    }

    IEnumerator InstantiateTargetCoroutine(float timer)
    {
        yield return new WaitForSeconds(timer);
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

    private void Update()
    {
        _timerBeforeSpawningNextTarget -= Time.deltaTime;
        
        if(_timerBeforeSpawningNextTarget <= 0)
        {
            StartCoroutine(InstantiateTargetCoroutine(0.1f));
            _timerBeforeSpawningNextTarget = _timer;
        }
    }
}
