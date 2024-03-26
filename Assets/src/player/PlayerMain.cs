using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private Inventory_UI _inventory_UI;
    
    void Start() {
        _inventory = new Inventory();
        _inventory_UI.SetInventory(_inventory);
    }
}
