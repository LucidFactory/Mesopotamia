using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using TMPro;
using UnityEngine;

public class EpreuveScoreManager : MonoBehaviour
{
    public float _score;
    private TMP_Text _scoreText;
    public float _scoreToObtain;

    private bool _stepNotFound;

    private GameObject _behaviourTree;
    private BehaviourTreeRunner _prefabBT;
    private int _i;

    private void Awake()
    {
        _scoreText = this.gameObject.GetComponent<TMP_Text>();

        _behaviourTree = GameObject.Find("BehaviourTree(Clone)");

        if (_behaviourTree != null)
        {
            _prefabBT = _behaviourTree.GetComponent<BehaviourTreeRunner>();
        }
    }

    public void InitializeScoreToObtain(float score)
    {
        _scoreToObtain = score;
        _scoreText.text =_score.ToString() + " / " + _scoreToObtain.ToString();
    }

    public void ChangeScoreToObtain()
    {
        if (_score >= _scoreToObtain && _prefabBT.tree.blackboard._epreuveScore.Count > _i)
        {
            _scoreToObtain = _prefabBT.tree.blackboard._epreuveScore[_i];
            _scoreText.text = _score.ToString() + "/" +  _scoreToObtain.ToString();
            _i++;
        }
    }

    public void UpdateScoreToObtainColor()
    {
        if (_score >= _scoreToObtain)
        {
            _scoreText.text = "<color=green>" + _score.ToString() + "</color>" + " / " + "<color=green>" + _scoreToObtain.ToString() + "</color>";
        }
    }

    public int FinishedStep(List<int> stepScore)
    {
        // Etape 1 : Je crée une boucle qui va parcourir l'ensemble des paliers de scores
        // Etape 2 : J'ai deux index, i qui va nous permettre de regarder le score le plus bas et j qui va regarder le score juste après
        // Etape 3 : Je regarde si mon score est entre ces deux fourchettes. J'incrémente tout de 1 si c'est pas le cas, sinon je sors de la boucle en connaissant l'étape de l'épreuve (qui est égal à l'index i)

        _stepNotFound = true;
        int stepFinish = -1;
        int i = 0;
        int j = 1;

        while (_stepNotFound)
        {
            Debug.Log("l'indice i est de : " + i);
            Debug.Log("L'indice j est de : " + j);
            Debug.Log("le score est de : " + _score);
            Debug.Log("StepScore est de : " + stepScore.Count);


            //                           1 >       3         ||     0  >=     300      &&    0   <=    400
            if (_score < stepScore[i] || j > stepScore.Count || _score >= stepScore[i] && _score <= stepScore[j])
            {
                _stepNotFound = false;
                Debug.Log("finished");
            }
            else
            {
                i++;
                j++;
            }
        }
        return stepFinish = i;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        _scoreText.text =_score.ToString() + " / " + _scoreToObtain.ToString();
    }

    private void Update()
    {
        ChangeScoreToObtain();
        UpdateScoreToObtainColor();
    }
}
