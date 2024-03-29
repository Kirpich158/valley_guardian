using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {

    [SerializeField] private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPanel() {
        _canvasGroup.alpha = 1; // ==> TODO change for animation clip <==
        Time.timeScale = 0;
    }
    public void HidePanel() {
        Time.timeScale = 1; 
        _canvasGroup.alpha = 0; // ==> TODO change for animation clip <==
    }
}
