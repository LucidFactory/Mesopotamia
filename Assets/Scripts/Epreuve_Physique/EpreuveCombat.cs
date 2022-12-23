using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EpreuveCombat : MonoBehaviour
{
    public float _lifeTime = 4.0f;

    private bool _timeIsRunning = false;

    private EpreuveScoreManager _scoreManager;
    private float _x;
    private float _y;
    private Vector3 _randomPosition;
    private EpreuveCombatManager _epreuveCombatManager;

    private void Awake()
    {
        //find the EpreuveScoreManager script in order to use it later on
        _scoreManager = GameObject.Find("Score(Clone)").GetComponent<EpreuveScoreManager>();
        _epreuveCombatManager = GameObject.Find("EpreuveCombatManager(Clone)").GetComponent<EpreuveCombatManager>();

        //Starts the timer when the target is instantiated
        _timeIsRunning = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        _x = Random.Range(-9f, 9f);
        _y = Random.Range(-3.5f, 3.5f);

        _randomPosition = new Vector3(_x, _y ,0);
    }
    /// <summary>
    /// cacher le canvas 
    /// lancer le timer et afficher le score
    /// instantier la cible, avec une durée de vie, a une position aléatoire et bouge un peu 
    /// si cliquer avatn la fin d ela durée de vie, elle disparait piui reprendre la boucle     => ligne du dessus
    /// 
    /// instatiate avec un scale différent aléatoire 
    /// 
    /// variable temps de vie 
    /// taile de la cible 
    /// 
    /// 
    /// si la cible exède al durée de vie on perd des points 
    /// </summary>
    /// 

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
                Debug.Log("Clicked on object: " + hit.collider.gameObject.name);
                // here we increment the variable Score for the target and increment the canvas showing the score
                switch (hit.collider.gameObject.name)
                {
                    case "AnneauBleu":
                        Debug.Log("AnneauBleu was hit");
                        _scoreManager.UpdateScore(25);
                        _epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager._timerBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauRouge":
                        Debug.Log("AnneauRouge was hit");
                        _scoreManager.UpdateScore(35);
                        _epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager._timerBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauJaune":
                        Debug.Log("AnneauJaune was hit");
                        _scoreManager.UpdateScore(50);
                        _epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager._timerBeforeSpawningNextTarget = _epreuveCombatManager._timer;
                        Destroy(gameObject, 0.1f);
                        break;
                    case "AnneauNoir":
                        Debug.Log("AnneauNoir was hit");
                        _scoreManager.UpdateScore(100);
                        _epreuveCombatManager.InstantiateTarget(); //
                        _epreuveCombatManager._timerBeforeSpawningNextTarget = _epreuveCombatManager._timer;
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
                Debug.Log("Timer is finihsed");
                _scoreManager.UpdateScore(-10);
                Destroy(gameObject, 0.1f);
                _timeIsRunning = false;
            }
        }
    }
}
