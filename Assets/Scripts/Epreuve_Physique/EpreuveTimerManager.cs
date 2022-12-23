using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EpreuveTimerManager : MonoBehaviour
{
    public float _epreuveTimer;
    private TMP_Text _timerText;
    private GameObject _epreuveManager;

    private void Awake()
    {
        _timerText = this.gameObject.GetComponent<TMP_Text>();

        _epreuveManager = GameObject.Find("EpreuveManager");
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

        if(_epreuveTimer <= 0 && _epreuveManager != null)
        {
           EpreuveManager epreuveManager = _epreuveManager.GetComponent<EpreuveManager>();
            epreuveManager.ShowUi();
            epreuveManager.DestroyTimerAndScore();
        }

    }
}
