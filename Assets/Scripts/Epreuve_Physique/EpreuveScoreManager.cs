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

    public void FinishedStep(int[] stepScore)
    {
        // Etape 1 : Je crée une boucle qui va parcourir l'ensemble des paliers de scores
        // Etape 2 : J'ai deux index, i qui va nous permettre de regarder le score le plus bas et j qui va regarder le score juste après
        // Etape 3 : Je regarde si mon score est entre ces deux fourchettes. J'incrémente tout de 1 si c'est pas le cas, sinon je sors de la boucle en connaissant l'étape de l'épreuve (qui est égal à l'index i)
        bool stepNotFound = true;
        int stepFinish = -1;
        int i = 0;
        int j = 1;
        while (stepNotFound)
        {
            if (stepScore[i] >= _score && stepScore[j] <= _score)
            {
                stepFinish = i;
                stepNotFound = false;
            }
            else
            {
                i++;
                j++;
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        //le score ne peux pas �tre n�gatif, on s'arrete � 0
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
