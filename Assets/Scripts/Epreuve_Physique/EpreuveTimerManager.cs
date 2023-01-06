using System.Collections;
using System.Collections.Generic;
using System.Text;
using TheKiwiCoder;
using TMPro;
using UnityEngine;

public class EpreuveTimerManager : MonoBehaviour
{
    public float _epreuveTimer;
    private bool _epreuveIsOver;
    private TMP_Text _timerText;
    private GameObject _behaviourTree;
    private BehaviourTreeRunner _prefabBT;
    //private GameObject _epreuveManager;

    private void Awake()
    {
        _timerText = this.gameObject.GetComponent<TMP_Text>();
        _behaviourTree = GameObject.Find("BehaviourTree(Clone)");

        if (_behaviourTree != null)
        {
            _prefabBT = _behaviourTree.GetComponent<BehaviourTreeRunner>();
        }

        //_epreuveManager = GameObject.Find("EpreuveManager");
        _epreuveIsOver = true;
    }

    public void InitializeTimer(float time)
    {
        _epreuveTimer = time;  
    }

    // Update is called once per frame
    void Update()
    {
        _epreuveTimer -= Time.deltaTime;
        _timerText.text = "Time Remaining " + _epreuveTimer.ToString();

        if(_epreuveIsOver && _epreuveTimer <= 0 /*&& _epreuveManager != null*/)
        {
            //EpreuveManager epreuveManager = _epreuveManager.GetComponent<EpreuveManager>();
            //epreuveManager.ShowUi();
            //epreuveManager.DestroyTimerAndScore();
            //epreuveManager.ShowButton();
            //epreuveManager.GetScoreAndSwitchCanvasPage();
            _prefabBT.tree.blackboard._timerIsFinished = true;

            _epreuveIsOver = false;
        }

    }
}
