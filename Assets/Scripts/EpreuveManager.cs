using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpreuveManager : MonoBehaviour
{

    public GameObject _prefabEpreuveCombatManager;
    public GameObject _timerTextPrefab;
    public GameObject _scoreTextPrefab;

    public Transform _canvasParent;

    private GameObject _canvasToHide;
    private GameObject _epreuveCombatManager;

    private EpreuveTimerManager _timerManager;
    private GameObject _timerText;
    private GameObject _scoreText;

    private void Awake()
    {
        _canvasToHide = GameObject.Find("CanvasInk");
        _timerManager = _timerTextPrefab.GetComponent<EpreuveTimerManager>();
    }
    public void ChooseEpreuve(string GroupeEpreuve)
    {
        string[] SplitEpreuve = GroupeEpreuve.Split("_");

        switch (SplitEpreuve[0])
        {
            case "Physique":
                switch (SplitEpreuve[1])
                {
                    case "Course Poursuite":
                        break;
                    case "Combat":
                        //instantie la première cible et lance la coroutine
                        GameObject epreuveCombatManager = Instantiate(_prefabEpreuveCombatManager, new Vector3(0,0,0), Quaternion.identity);
                        _prefabEpreuveCombatManager.GetComponent<EpreuveCombatManager>()._timerBeforeSpawningNextTarget = 4.0f;

                        //instantie le timer et set le timer
                        _timerText = Instantiate(_timerTextPrefab, _canvasParent);
                        _timerText.GetComponent<EpreuveTimerManager>().InitializeTimer(10.0f);

                        //instantie le score
                        _scoreText = Instantiate(_scoreTextPrefab, _canvasParent);

                        //cache l'UI de l'histoire
                        HideUI();
                        break;
                    case "Force Brut":
                        break;
                }
                break;
            case "Social":
                switch (SplitEpreuve[1])
                {
                    case "Persuasion":
                        break;
                    case "Mensonge":
                        break;
                    case "Troque":
                        break;
                }
                break;
            case "Mysticisme":
                switch (SplitEpreuve[1])
                {
                    case "Ritual Divin":
                        break;
                    case "Nettoyer la souillare":
                        break;
                }
                break;
            case "Commun":
                switch (SplitEpreuve[1])
                {
                    case "Crochetage":
                        break;
                    case "Perception":
                        break;
                }
                break;
        }
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
    public void ShowUi()
    {
        if (_canvasToHide != null && _timerManager._epreuveTimer <= 0)
        {
            _canvasToHide.GetComponent<Canvas>();
            _canvasToHide.gameObject.SetActive(true);

            Destroy(_epreuveCombatManager, 0.1f);
        }
    }

    public void DestroyTimerAndScore()
    {
        Destroy(_timerText, 0.1f);
        Destroy(_scoreText, 0.1f);
    }

}
