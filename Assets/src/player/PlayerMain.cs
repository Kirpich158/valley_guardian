using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {
    public static PlayerMain Instance { get; private set; }
    public int HealthVal { get; set; }

    public Backpack Backpack { get; set; }
    public Equipment Equipment { get; set; }
    [SerializeField] private Inventory_UI _inventory_UI;
    
    private void Awake() {
        Instance = this;
        HealthVal = 3;
    }

    void Start() {
        Backpack = new Backpack();
        Equipment = new Equipment();
        _inventory_UI.SetupInventory(Backpack, Equipment);

        DroppedItem.SpawnItem(new Vector3(2, 0, 0), new Item(ItemType.Sword, 1));
        DroppedItem.SpawnItem(new Vector3(-2, 0, 0), new Item(ItemType.Helmet, 1));
        DroppedItem.SpawnItem(new Vector3(0, 2, 0), new Item(ItemType.Armor, 1));
        DroppedItem.SpawnItem(new Vector3(0, 4, 0), new Item(ItemType.Armor, 1));
        DroppedItem.SpawnItem(new Vector3(0, 6, 0), new Item(ItemType.Armor, 1));
        DroppedItem.SpawnItem(new Vector3(0, -2, 0), new Item(ItemType.HealthPotion, 2));
        DroppedItem.SpawnItem(new Vector3(0, -4, 0), new Item(ItemType.HealthPotion, 1));
    }

    public void Update() {
        if (HealthVal <= 0) {
            UIManagerScript.Instance.ShowGameOverPanel();
        }
    }
}
