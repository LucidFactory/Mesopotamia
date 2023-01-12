using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EpreuveCombat : MonoBehaviour
{
    public float _lifeTime = 4.0f;
    public int _amountOfScoreToTakeAwayIfLifetimeIsExeeded;

    private bool _timeIsRunning = false;

    private EpreuveScoreManager _scoreManager;
    private float _x;
    private float _y;
    private Vector3 _randomPosition;
    private EpreuveCombatManager _epreuveCombatManager;

    private GameObject _behaviourTree;
    private BehaviourTreeRunner _prefabBT;

    private void Awake()
    {

        _behaviourTree = GameObject.Find("BehaviourTree(Clone)");

        if (_behaviourTree != null)
        {
            _prefabBT = _behaviourTree.GetComponent<BehaviourTreeRunner>();
        }

        //find the EpreuveScoreManager & EpreuveCombatManager script in order to use it later on
        _scoreManager = GameObject.Find("Score(Clone)").GetComponent<EpreuveScoreManager>();
        _epreuveCombatManager = GameObject.Find("EpreuveCombatManager(Clone)").GetComponent<EpreuveCombatManager>();

        //Starts the timer when the target is instantiated
        _timeIsRunning = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        _randomPosition = RandomPosition();
    }

    private Vector3 RandomPosition()
    {
        // Retourne une position aléatoire sur l'écran
        _x = Random.Range(-8f, 8f);
        _y = Random.Range(-3.5f, 3.5f);
        return new Vector3(_x, _y, 0);
    }

    private void Update()
    {
        //get the hit info depending on where we click on the target and increment the score
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // The object that was hit by the ray is hit.collider.gameObject
                //Debug.Log("Clicked on object: " + hit.collider.gameObject.name);
                // here we increment the variable Score for the target and increment the canvas showing the score
                switch (hit.collider.gameObject.name)
                {
                    case "AnneauBleu":
                        //Debug.Log("AnneauBleu was hit");
                        _scoreManager.UpdateScore(25);
                        //_epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager.StopAllCoroutines();
                        //_epreuveCombatManager._timeBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        _epreuveCombatManager.StartCoroutine(_epreuveCombatManager.InstantiateTargetCoroutine(_epreuveCombatManager._timeBeforeSpawningNextTarget));
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauRouge":
                        //Debug.Log("AnneauRouge was hit");
                        _scoreManager.UpdateScore(35);
                        //_epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager.StopAllCoroutines();
                        //_epreuveCombatManager._timeBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        _epreuveCombatManager.StartCoroutine(_epreuveCombatManager.InstantiateTargetCoroutine(_epreuveCombatManager._timeBeforeSpawningNextTarget));
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauJaune":
                        //Debug.Log("AnneauJaune was hit");
                        _scoreManager.UpdateScore(50);
                        //_epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager.StopAllCoroutines();
                        //_epreuveCombatManager._timeBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        _epreuveCombatManager.StartCoroutine(_epreuveCombatManager.InstantiateTargetCoroutine(_epreuveCombatManager._timeBeforeSpawningNextTarget));
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauNoir":
                        //Debug.Log("AnneauNoir was hit");
                        _scoreManager.UpdateScore(100);
                        //_epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager.StopAllCoroutines();
                        //_epreuveCombatManager._timeBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        _epreuveCombatManager.StartCoroutine(_epreuveCombatManager.InstantiateTargetCoroutine(_epreuveCombatManager._timeBeforeSpawningNextTarget));
                        Destroy(gameObject, 0.1f);
                        break;
                }
            }
        }

        //Make the target move continuously while lifeTime is > 0 
        if (_timeIsRunning)
        {
            _lifeTime -= Time.deltaTime;

            this.transform.position = Vector3.Lerp(transform.position, _randomPosition, 1 * Time.deltaTime);

            if (_lifeTime <= 0.0f)
            {
                _scoreManager.UpdateScore(-_amountOfScoreToTakeAwayIfLifetimeIsExeeded);
                _epreuveCombatManager._timeBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                Destroy(gameObject, 0.1f);
                _timeIsRunning = false;
            }
        }

        if (_prefabBT.tree.blackboard._timerIsFinished)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
