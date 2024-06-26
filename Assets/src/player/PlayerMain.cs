using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerStates {
    Idle,
    Moving,
    Dashing,
    Attacking
}

public class PlayerMain : MonoBehaviour {
    public static PlayerMain Instance { get; private set; }

    public PlayerStates State {  get; set; }
    public int HealthVal { get; set; }
    public Backpack Backpack { get; set; }
    public Equipment Equipment { get; set; }

    [SerializeField] private Inventory_UI _inventory_UI;
    [SerializeField] private PlayerTrigger playerTriggerScript;
    [SerializeField] private InputActionReference _interactionInput;
    
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        HealthVal = 3;
        State = PlayerStates.Idle;
    }

    void Start() {
        Backpack = new Backpack();
        Equipment = new Equipment();
        _inventory_UI.SetupInventory(Backpack, Equipment);

        DroppedItem.SpawnItem(new Vector3(0, -2, 0), new Item(ItemType.HealthPotion, 2));
        DroppedItem.SpawnItem(new Vector3(0, -4, 0), new Item(ItemType.HealthPotion, 1));
    }

    public void Update() {
        if (HealthVal <= 0) {
            UIManagerScript.Instance.ShowGameOverPanel();
        }

        if (playerTriggerScript.OnFishingSpot && _interactionInput.action.WasPressedThisFrame() && Equipment.Equipments[6] != null) {
            UIManagerScript.Instance.ShowFishingGame();
        }

        // Debug.Log(State);
    }
}
