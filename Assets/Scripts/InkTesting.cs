using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkTesting : MonoBehaviour
{
    public TextAsset inkJson;
    private Story _story;

    public TMP_Text textPrefab;
    public Button buttonPrefab;

    private Transform _titleTransform;
    private Transform _dialogueTransform;
    private Transform _buttonTransform;
    /// <summary>
    /// Au start du projet, nous récupéront le texte ink pour pouvoir l'exploiter par la suite
    /// </summary>
    void Awake()
    {
        InitStory();
        RefreshUI();
    }
    /// <summary>
    /// Récupération des transforms des GO pour optimiser
    /// </summary>
    private void InitStory()
    {
        _story = new Story(inkJson.text);
        _titleTransform = GameObject.Find("Title").transform;
        _dialogueTransform = GameObject.Find("Dialogue").transform;
        _buttonTransform = GameObject.Find("Choix").transform;
    }

    private void RefreshUI()
    {
        EraseUI();
        ShowDialogues();
        SearchingTags();
        ShowChoices();
    }
    /// <summary>
    /// Fonction permettant d'afficher le dialogue en cours
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void ShowDialogues()
    {
        TMP_Text storyText = Instantiate(textPrefab, _dialogueTransform , false);
        string text = LoadStoryChunk();
        storyText.text = text;
    }

    /// <summary>
    /// Gestion dynamique des tags contenue dans le dialogue en cours.
    ///     - Si il y a un titre alors on laisse ShowTitle gérer sa partie
    /// </summary>
    private void SearchingTags()
    {
        foreach (string s in _story.currentTags.Where(s => s.Contains("Title")))
        {
            ShowTitle(s);
        }
    }
    /// <summary>
    /// Fonction gérant le titre de l'histoire en cours. Dans Ink le Tag doit forcément commencer par #Title:
    /// </summary>
    /// <param name="tag">Le tag correspondant au titre en cours</param>
    private void ShowTitle(string tag)
    {
        TMP_Text title = Instantiate(textPrefab, _titleTransform, false);
        title.text = tag.Replace("Title:", "");
    }
    /// <summary>
    /// Affiche les différents choix possible sur le dialogue en cours
    /// </summary>
    private void ShowChoices()
    {
        foreach (Choice choice in _story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab,_buttonTransform , false);
            TMP_Text choiceText = buttonPrefab.GetComponentInChildren<TMP_Text>();
            choiceText.text = choice.text;
            Debug.Log("Le titre du choix est => " + choice.text);
            Debug.Log("Le text du Text est => " + choiceText.text);
            
            choiceButton.onClick.AddListener(() => ChooseStoryChoice(choice));
        }
    }
    /// <summary>
    /// Efface l'ensemble des Text et Button contenu dans le GO Dialogue & Choix pour afficher la suite.
    /// </summary>
    private void EraseUI()
    {
        foreach (Transform childTransform in gameObject.transform)
        {
            if (childTransform.name == "Title") continue;
            for (int i = 0; i < childTransform.childCount; i++)
            {
                Destroy(childTransform.GetChild(i).gameObject);
            }
        }
    }
    /// <summary>
    /// Fonction permettant de stocker le choix de l'utilisateur pour pouvoir récupérer la bonne suite de l'histoire dans RefreshUI
    /// </summary>
    /// <param name="choice"></param>
    private void ChooseStoryChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);   
        RefreshUI();
    }
    /// <summary>
    /// Fonction récupérant le prochain morceau d'histoire à afficher. Comprenant l'ensemble des tags, les choix et le dialogue.
    /// </summary>
    /// <returns></returns>
    private string LoadStoryChunk()
    {
        return (_story.canContinue) ? _story.ContinueMaximally() : "";
    }
}
