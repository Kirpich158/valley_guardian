using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {
    public static UIManagerScript Instance { get; private set; }

    [SerializeField] private Health_UI _healthSrc;
    [SerializeField] private Inventory_UI _inventoryPanelSrc;
    [SerializeField] private DialogueScript _dialoguePanelSrc;
    [SerializeField] private TextMeshProUGUI _gameOverTxt; // ==> TODO make a panel instead with buttons/etc. <==

    private void Awake() {
        Instance = this;
    }

    public void AddHearts(int amount) {
        _healthSrc.AddHearts(amount);
    }
    public void RemoveHearts(int amount) {
        _healthSrc.RemoveHearts(amount);
    }

    public void ShowDialoguePanel() {
        _dialoguePanelSrc.ShowPanel();
    }
    public void HideDialoguePanel() {
        _dialoguePanelSrc.HidePanel();
    }
    
    public void ShowInventoryPanel() {
        _inventoryPanelSrc.ShowPanel();
    }
    public void HideInventoryPanel() {
        _inventoryPanelSrc.HidePanel();
    }

    public void ShowGameOverPanel() {
        _gameOverTxt.alpha = 1;
        Time.timeScale = 0;
    }
}
