using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates {
    Idle,
    Moving,
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
    
    private void Awake() {
        Instance = this;
        HealthVal = 3;
    }

    void Start() {
        Backpack = new Backpack();
        Equipment = new Equipment();
        _inventory_UI.SetupInventory(Backpack, Equipment);
        State = PlayerStates.Idle;

        DroppedItem.SpawnItem(new Vector3(0, -2, 0), new Item(ItemType.HealthPotion, 2));
        DroppedItem.SpawnItem(new Vector3(0, -4, 0), new Item(ItemType.HealthPotion, 1));
    }

    public void Update() {
        if (HealthVal <= 0) {
            UIManagerScript.Instance.ShowGameOverPanel();
        }

        if (playerTriggerScript.OnFishingSpot && Input.GetKeyDown(KeyCode.F) && Equipment.Equipments[6] != null) {
            UIManagerScript.Instance.ShowFishingGame();
        }

        Debug.Log(State);
    }
}
