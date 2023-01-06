using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EpreuveManager : MonoBehaviour
{
    public GameObject _prefabBT;

    public GameObject _prefabEpreuveCombatManager;
    public GameObject _timerTextPrefab;
    public GameObject _scoreTextPrefab;

    public Transform _canvasParent;
    public InkTest _inkTest;
    public GameObject _canvasChoix;

    private GameObject _canvasToHide;
    private GameObject _epreuveCombatManager;

    private EpreuveTimerManager _timerManager;
    private GameObject _timerText;
    private GameObject _scoreText;
    private int _scoreToReach;

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
                        ////instantie la premi�re cible et lance la coroutine
                        //_epreuveCombatManager = Instantiate(_prefabEpreuveCombatManager, new Vector3(0,0,0), Quaternion.identity);
                        //_epreuveCombatManager.GetComponent<EpreuveCombatManager>()._timer = 4.0f;

                        //instantie le timer et set le timer
                        //int num = int.Parse(SplitEpreuve[2]);
                        //_timerText = Instantiate(_timerTextPrefab, _canvasParent);
                        //_timerText.GetComponent<EpreuveTimerManager>().InitializeTimer(num);

                        //instantie le score

                        //_scoreToReach = int.Parse(SplitEpreuve[3]);
                        //_scoreText = Instantiate(_scoreTextPrefab, _canvasParent);

                        // Instancier le prefab du behaviour Tree
                        //HideUI();
                        //GameObject BT = Instantiate(_prefabBT, new Vector3(0, 0, 0), Quaternion.identity);
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
        _inkTest._ButtonWasPressed = false;
    }

    public void DestroyTimerAndScore()
    {
        Destroy(_timerText, 0.1f);
        Destroy(_scoreText, 0.1f);
    }

    public void ShowButton()
    {
        int childcount = _canvasChoix.transform.childCount;
        for (int i = 0; i < childcount; i++)
        {
            if (_canvasChoix.transform.GetChild(i).gameObject.activeInHierarchy == false)
            {
                _canvasChoix.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        _inkTest._epreuveButton.gameObject.SetActive(false);
    }

    public void GetScoreAndSwitchCanvasPage()
    {
        float Score = _scoreText.GetComponent<EpreuveScoreManager>()._score;

        if (Score >= _scoreToReach)
        {
            _inkTest.OnClickChoiceButton(_inkTest._story.currentChoices[0]);
        }
        else
        {
            _inkTest.OnClickChoiceButton(_inkTest._story.currentChoices[1]);
        }
    }
}