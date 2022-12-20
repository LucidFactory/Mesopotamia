using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Parsed;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Choice = Ink.Runtime.Choice;
using Story = Ink.Runtime.Story;

public class InkTest : MonoBehaviour
{
    //public static event Action<Story> OnCreateStory;

    public TextAsset _inkJson;
    private Story _story;

    public TMP_Text textPrefab;
    public Button buttonPrefab;
    public Canvas _CanvasToHide;
    public Canvas _CanvasMiniGameToShow;

    private Transform _titleTransform;
    private Transform _dialogueTransform;
    private Transform _buttonTransform;

    public bool _IsMiniGame = false;

    void Awake()
    {
        // Remove the default message
        ReinitialiseNode();
        StartStory();
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        _story = new Story(_inkJson.text);

        _titleTransform = GameObject.Find("Title").transform;
        _dialogueTransform = GameObject.Find("Dialogue").transform;
        _buttonTransform = GameObject.Find("Choix").transform;

        RefreshView();
    }
    
    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        ReinitialiseNode();

        // Read all the content until we can't continue any more
        while (_story.canContinue)
        {
            // Display the text on screen!
            CreateContentView();
        }

        // Display all the choices, if there are any!
        if (_story.currentChoices.Count > 0)
        {
            for (int i = 0; i < _story.currentChoices.Count; i++)
            {
                Choice choice = _story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                
                foreach (string tag in _story.currentTags)
                {
                    string[] tagSplitter = tag.Split(":");
                    switch (tagSplitter[0])
                    {
                        case "Title" :
                            ShowTitle(tagSplitter[1]);
                            break;
                        case "MiniGame" :
                            button.onClick.AddListener(() =>
                            {
                                _IsMiniGame = true;
                                StartMinigame(tagSplitter[1]);
                            });
                            break;
                        default:
                            break;  
                    }
                }

                if (!_IsMiniGame)
                {
                    // Tell the button what to do when we press it
                    button.onClick.AddListener(delegate
                    {
                        OnClickChoiceButton(choice);
                    });
                }
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate
            {
                StartStory();
            });
        }
    }
    // Creates a textbox showing the the line of text
    void CreateContentView()
    {
        TMP_Text storyText = Instantiate(textPrefab, _dialogueTransform, false);
        string _text = LoadStoryChunk();
        storyText.text = _text;
    }
    
    /// <summary>
    /// Fonction gérant le titre de l'histoire en cours. Dans Ink le Tag doit forcément commencer par #Title:
    /// </summary>
    /// <param name="titre">Le tag correspondant au titre en cours</param>
    private void ShowTitle(string titre)
    {
        
        TMP_Text title = Instantiate(textPrefab, _titleTransform, false);
        title.text = titre;
    }

    
    // When we click the choice button, tell the story to choose that choice!
    private void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab, _buttonTransform, false);
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
        choiceText.text = text;
        
        return choice;
    }

    void StartMinigame(string groupeEpreuve)
    {
        // Etape X : Apeller le MiniGameManager en lui passant groupeEpreuve dans son constructeur
        //           qui va spliter sur ';' et qui va envoyer le bon mini jeu du bon groupe
        Debug.Log("Est ce que j'ai bien passé mon épreuve ? => " + groupeEpreuve);
        _CanvasToHide.gameObject.SetActive(false);
        _CanvasMiniGameToShow.gameObject.SetActive(true);
        _IsMiniGame = false;
    }



    // Destroys all the children of this gameobject (all the UI)
    void ReinitialiseNode()
    {
        // Dans le doute, on considère que le noeud en cours n'est pas une épreuve.
        _IsMiniGame = false;
        
        foreach (Transform childTransform in gameObject.transform)
        {
            if (childTransform.name == "Title") continue;
            for (int i = childTransform.childCount - 1; i >= 0; --i)
            {
                Destroy(childTransform.GetChild(i).gameObject);
            }
        }
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
