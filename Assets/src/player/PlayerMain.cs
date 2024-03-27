using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Inventory Inventory { get; set; }
    [SerializeField] private Inventory_UI _inventory_UI;
    
    void Start() {
        Inventory = new Inventory();
        _inventory_UI.SetInventory(Inventory);

        DroppedItem.SpawnItem(new Vector3(2, 0, 0), new Item(ItemType.Sword, 1));
        DroppedItem.SpawnItem(new Vector3(-2, 0, 0), new Item(ItemType.Helmet, 1));
        DroppedItem.SpawnItem(new Vector3(0, 2, 0), new Item(ItemType.Armor, 1));
        DroppedItem.SpawnItem(new Vector3(0, -2, 0), new Item(ItemType.HealthPotion, 2));
        DroppedItem.SpawnItem(new Vector3(0, -4, 0), new Item(ItemType.HealthPotion, 1));
    }
}
