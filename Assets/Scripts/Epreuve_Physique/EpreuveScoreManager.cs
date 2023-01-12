using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EpreuveScoreManager : MonoBehaviour
{
    public float _score;
    private TMP_Text _scoreText;
    public float _scoreToObtain;

    private void Awake()
    {
        _scoreText = this.gameObject.GetComponent<TMP_Text>();
    }

    public void InitializeScoreToObtain(float score)
    {
        _scoreToObtain = score;
        _scoreText.text =_score.ToString() + " / " + _scoreToObtain.ToString();
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        //le score ne peux pas être négatif, on s'arrete à 0
        //_score = Mathf.Clamp(_score, 0, float.MaxValue);
        _scoreText.text =_score.ToString() + " / " + _scoreToObtain.ToString();
    }

    private void Update()
    {
        if (_score >= _scoreToObtain)
        {
            _scoreText.text = "<color=green>" + _score.ToString() + "</color>" + " / " + "<color=green>" + _scoreToObtain.ToString() + "</color>";
        }
    }
}
