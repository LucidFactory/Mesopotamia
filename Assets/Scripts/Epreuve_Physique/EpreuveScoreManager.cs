using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EpreuveScoreManager : MonoBehaviour
{
    public float _score;
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = this.gameObject.GetComponent<TMP_Text>();
        _scoreText.text = "Your score is : " + _score.ToString();
    }

    public void InitializeScore(float score)
    {
        _score = score;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _score = Mathf.Clamp(_score, 0, float.MaxValue);
        _scoreText.text = "Your score is : " + _score.ToString();
    }
}
