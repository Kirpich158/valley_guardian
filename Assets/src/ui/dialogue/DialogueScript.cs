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
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }
    public void HidePanel() {
        Time.timeScale = 1;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0; // ==> TODO change for animation clip <==
    }
}
