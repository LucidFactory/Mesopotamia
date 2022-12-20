using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniJeuPOC : MonoBehaviour
{
    public Button _TargetButton;
    public Canvas _targetCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        _targetCanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
