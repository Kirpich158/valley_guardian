using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {
    public static UIManagerScript Instance { get; private set; }

    public bool InventoryOpened { get; private set; }
    public bool DialogueOpened { get; private set; }
    public bool Fishing { get; private set; }

    [SerializeField] private Health_UI _healthSrc;
    [SerializeField] private Inventory_UI _inventoryPanelSrc;
    [SerializeField] private DialogueScript _dialoguePanelSrc;
    [SerializeField] private TextMeshProUGUI _gameOverTxt; // ==> TODO make a panel instead, with buttons, progress, etc. <==
    [SerializeField] private FishingGameScript _fishingGameSrc;

    private void Awake() {
        Instance = this;
        InventoryOpened = DialogueOpened = Fishing = false;
    }

    public void AddHearts(int amount) {
        _healthSrc.AddHearts(amount);
    }
    public void RemoveHearts(int amount) {
        _healthSrc.RemoveHearts(amount);
    }

    public void ShowDialoguePanel() {
        _dialoguePanelSrc.ShowPanel();
        DialogueOpened = true;
    }
    public void HideDialoguePanel() {
        _dialoguePanelSrc.HidePanel();
        DialogueOpened = false;
    }
    
    public void ShowInventoryPanel() {
        _inventoryPanelSrc.ShowPanel();
        InventoryOpened = true;
    }
    public void HideInventoryPanel() {
        _inventoryPanelSrc.HidePanel();
        InventoryOpened = false;
    }

    public void ShowFishingGame() {
        _fishingGameSrc.ShowGame();
        Fishing = true;
        PlayerMain.Instance.gameObject.GetComponent<PlayerControls>().IsMovementBlocked = true;
    }
    public void HideFishingGame() {
        _fishingGameSrc.HideGame();
        Fishing = false;
        PlayerMain.Instance.gameObject.GetComponent<PlayerControls>().IsMovementBlocked = false;
    }

    public void ShowGameOverPanel() {
        _gameOverTxt.alpha = 1;
        Time.timeScale = 0;
    }
}
