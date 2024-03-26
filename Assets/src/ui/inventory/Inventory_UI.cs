using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private Transform _backpack_section;

    public void SetInventory(Inventory inventory) {
        _inventory = inventory;

        UpdateItems();
    }

    private void UpdateItems() {
        for (int i = 0; i < _inventory.Items.Count; i++) {
            Image slot_icon = _backpack_section.GetChild(i).transform.Find("Item_Icon").GetComponentInChildren<Image>();
            slot_icon.sprite = _inventory.Items[i].GetSprite();

            // alpha change to show new item sprite
            Color tmpColor = slot_icon.color;
            tmpColor.a = 1;
            slot_icon.color = tmpColor;
        }
    }
}
